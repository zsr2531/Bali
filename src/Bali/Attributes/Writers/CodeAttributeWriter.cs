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
        protected override void WriteBody(CodeAttribute attribute, IBigEndianWriter writer)
        {
            writer.WriteU2(attribute.MaxStack);
            writer.WriteU2(attribute.MaxLocals);
            
            WriteBytecode(writer, attribute);
            WriteExceptionHandlers(writer, attribute);
            
            writer.WriteU2((ushort) attribute.Attributes.Count);
            foreach (var nestedAttribute in attribute.Attributes)
                Director.WriteAttribute(nestedAttribute, writer);
        }

        private void WriteBytecode(IBigEndianWriter writer, CodeAttribute attribute)
        {
            using var segment = writer.WithU4Length();
            _assembler.Assemble(attribute.Instructions, segment);
        }

        private static void WriteExceptionHandlers(IBigEndianWriter writer, CodeAttribute attribute)
        {
            writer.WriteU2((ushort) attribute.ExceptionHandlers.Count);
            foreach (var exceptionHandler in attribute.ExceptionHandlers)
            {
                writer.WriteU2(exceptionHandler.TryStart);
                writer.WriteU2(exceptionHandler.TryEnd);
                writer.WriteU2(exceptionHandler.HandlerStart);
                writer.WriteU2(exceptionHandler.CatchType);
            }
        }
    }
}