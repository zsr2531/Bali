using System.Collections.Generic;
using System.IO;
using Bali.Emit;
using Bali.IO;

namespace Bali.Attributes.Readers
{
    /// <summary>
    /// Provides an implementation of the <see cref="JvmAttributeReaderBase"/> contract that can read <see cref="CodeAttribute"/>s.
    /// </summary>
    public class CodeAttributeReader : JvmAttributeReaderBase
    {
        private readonly IJvmBytecodeDisassembler _disassembler;
        
        /// <summary>
        /// Creates a new <see cref="CodeAttributeReader"/>.
        /// </summary>
        /// <param name="attributeReaderFacade">The attribute factory that can be used to create other types of attributes.</param>
        public CodeAttributeReader(IJvmAttributeReaderFacade attributeReaderFacade)
            : this(attributeReaderFacade, JvmBytecodeDisassembler.Instance)
        {
        }

        /// <summary>
        /// Creates a new <see cref="CodeAttributeReader"/>.
        /// </summary>
        /// <param name="attributeReaderFacade">The attribute factory that can be used to create other types of attributes.</param>
        /// <param name="disassembler">The disassembler that is used to parse instructions.</param>
        public CodeAttributeReader(
            IJvmAttributeReaderFacade attributeReaderFacade,
            IJvmBytecodeDisassembler disassembler)
            : base(attributeReaderFacade)
        {
            _disassembler = disassembler;
        }

        /// <inheritdoc />
        public override string Name => "Code";

        /// <inheritdoc />
        public override JvmAttribute Read(Stream stream, ushort nameIndex)
        {
            _ = stream.ReadU4();
            ushort maxStack = stream.ReadU2();
            ushort maxLocals = stream.ReadU2();
            var instructions = ReadInstructions(stream);
            var exceptionHandlers = ReadExceptionHandlers(stream);

            ushort attributeCount = stream.ReadU2();
            var attributes = new List<JvmAttribute>(attributeCount);

            for (int i = 0; i < attributeCount; i++)
                attributes.Add(AttributeReaderFacade.ReadAttribute());

            return new CodeAttribute(nameIndex, maxStack, maxLocals, instructions, exceptionHandlers, attributes);
        }

        private IList<JvmInstruction> ReadInstructions(Stream stream)
        {
            uint codeLength = stream.ReadU4();
            return _disassembler.Disassemble(stream, codeLength);
        }

        private static IList<JvmExceptionHandler> ReadExceptionHandlers(Stream stream)
        {
            ushort count = stream.ReadU2();
            var result = new List<JvmExceptionHandler>(count);

            for (uint i = 0; i < count; i++)
            {
                ushort
                    tryStart = stream.ReadU2(),
                    tryEnd = stream.ReadU2(),
                    handlerStart = stream.ReadU2(),
                    catchType = stream.ReadU2();
                
                result.Add(new JvmExceptionHandler(tryStart, tryEnd, handlerStart, catchType));
            }

            return result;
        }
    }
}