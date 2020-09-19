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
            set;
        }

        public ushort MaxLocals
        {
            get;
            set;
        }

        public IList<byte> Bytecode
        {
            get;
            set;
        }

        public IList<JvmExceptionHandler> ExceptionHandlers
        {
            get;
            set;
        }

        public IList<Attribute> Attributes
        {
            get;
            set;
        }
    }
}