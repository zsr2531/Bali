using System.Collections.Generic;
using Bali.Emit;

namespace Bali.Metadata.Attributes
{
    public sealed class CodeAttribute : Attribute
    {
        public CodeAttribute(ushort nameIndex)
            : base(nameIndex) { }

        public ushort MaxStack
        {
            get;
        }

        public ushort MaxLocals
        {
            get;
        }

        public IReadOnlyList<byte> Bytecode
        {
            get;
        }

        public IReadOnlyList<ExceptionHandler> ExceptionHandlers
        {
            get;
        }

        public IReadOnlyList<Attribute> Attributes
        {
            get;
        }
    }
}