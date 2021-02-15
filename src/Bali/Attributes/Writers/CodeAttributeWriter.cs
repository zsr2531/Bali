using System.IO;
using Bali.Emit;
using Bali.IO;

namespace Bali.Attributes.Writers
{
    /// <summary>
    /// Provides an implementation of the <see cref="JvmAttributeWriterBase{T}"/> contract which can write <see cref="CodeAttribute"/>s.
    /// </summary>
    public class CodeAttributeWriter : JvmAttributeWriterBase<CodeAttribute>
    {
        private readonly IJvmBytecodeAssembler _assembler;

        /// <summary>
        /// Creates a new <see cref="CodeAttributeWriter"/>.
        /// </summary>
        /// <param name="director">The underlying <see cref="IJvmAttributeDirector"/>.</param>
        public CodeAttributeWriter(IJvmAttributeDirector director)
            : this(director, JvmBytecodeAssembler.Instance)
        {
        }

        /// <summary>
        /// Creates a new <see cref="CodeAttributeWriter"/>.
        /// </summary>
        /// <param name="director">The underlying <see cref="IJvmAttributeDirector"/>.</param>
        /// <param name="assembler">The <see cref="IJvmBytecodeAssembler"/> to assemble bytecode with.</param>
        public CodeAttributeWriter(IJvmAttributeDirector director, IJvmBytecodeAssembler assembler)
            : base(director)
        {
            _assembler = assembler;
        }

        /// <inheritdoc />
        public override string Name => "Code";

        /// <inheritdoc />
        protected override void WriteBody(Stream stream, CodeAttribute attribute)
        {
            stream.WriteU2(attribute.MaxStack);
            stream.WriteU2(attribute.MaxLocals);
            
            WriteBytecode(stream, attribute);
            WriteExceptionHandlers(stream, attribute);
            
            stream.WriteU2((ushort) attribute.Attributes.Count);
            foreach (var nestedAttribute in attribute.Attributes)
                Director.WriteAttribute(nestedAttribute, stream);
        }

        private void WriteBytecode(Stream stream, CodeAttribute attribute)
        {
            using var ms = new MemoryStream();
            _assembler.Assemble(attribute.Instructions, ms);

            stream.WriteU4((uint) ms.Length);
            ms.WriteTo(stream);
        }

        private static void WriteExceptionHandlers(Stream stream, CodeAttribute attribute)
        {
            stream.WriteU2((ushort) attribute.ExceptionHandlers.Count);
            foreach (var exceptionHandler in attribute.ExceptionHandlers)
            {
                stream.WriteU2(exceptionHandler.TryStart);
                stream.WriteU2(exceptionHandler.TryEnd);
                stream.WriteU2(exceptionHandler.HandlerStart);
                stream.WriteU2(exceptionHandler.CatchType);
            }
        }
    }
}