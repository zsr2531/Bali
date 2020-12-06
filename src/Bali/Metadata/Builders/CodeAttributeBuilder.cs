using System.IO;
using Bali.Emit;
using Bali.IO;
using Bali.Metadata.Attributes;

namespace Bali.Metadata.Builders
{
    public class CodeAttributeBuilder : JvmAttributeBuilderBase<CodeAttribute>
    {
        private readonly IJvmBytecodeAssembler _assembler;

        public CodeAttributeBuilder(IJvmAttributeDirector director)
            : this(director, JvmBytecodeAssembler.Instance) { }

        public CodeAttributeBuilder(IJvmAttributeDirector director, IJvmBytecodeAssembler assembler)
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
            
            BuildBytecode(stream, attribute);
            BuildExceptionHandlers(stream, attribute);
            
            stream.WriteU2((ushort) attribute.Attributes.Count);
            foreach (var nestedAttribute in attribute.Attributes)
                Director.ConstructAttribute(nestedAttribute);
        }

        private void BuildBytecode(Stream stream, CodeAttribute attribute)
        {
            using var ms = new MemoryStream();
            _assembler.Assemble(attribute.Instructions, ms);

            stream.WriteU4((uint) ms.Length);
            ms.CopyTo(stream);
        }

        private static void BuildExceptionHandlers(Stream stream, CodeAttribute attribute)
        {
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