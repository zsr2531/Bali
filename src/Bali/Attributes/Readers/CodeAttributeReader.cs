using System.Collections.Generic;
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
        public override JvmAttribute Read(IBigEndianReader reader, ushort nameIndex, uint length)
        {
            ushort maxStack = reader.ReadU2();
            ushort maxLocals = reader.ReadU2();
            var instructions = ReadInstructions(reader);
            var exceptionHandlers = ReadExceptionHandlers(reader);

            ushort attributeCount = reader.ReadU2();
            var attributes = new List<JvmAttribute>(attributeCount);

            for (int i = 0; i < attributeCount; i++)
                attributes.Add(AttributeReaderFacade.ReadAttribute());

            return new CodeAttribute(nameIndex, maxStack, maxLocals, instructions, exceptionHandlers, attributes);
        }

        private IList<JvmInstruction> ReadInstructions(IBigEndianReader reader)
        {
            uint codeLength = reader.ReadU4();
            return _disassembler.Disassemble(reader, codeLength);
        }

        private static IList<JvmExceptionHandler> ReadExceptionHandlers(IBigEndianReader reader)
        {
            ushort count = reader.ReadU2();
            var result = new List<JvmExceptionHandler>(count);

            for (uint i = 0; i < count; i++)
            {
                ushort
                    tryStart = reader.ReadU2(),
                    tryEnd = reader.ReadU2(),
                    handlerStart = reader.ReadU2(),
                    catchType = reader.ReadU2();
                
                result.Add(new JvmExceptionHandler(tryStart, tryEnd, handlerStart, catchType));
            }

            return result;
        }
    }
}