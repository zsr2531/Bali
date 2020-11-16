using System.Collections.Generic;
using System.IO;
using Bali.Emit;
using Bali.IO;

namespace Bali.Metadata.Attributes
{
    public sealed class CodeAttribute : JvmAttribute
    {
        public CodeAttribute(
            ushort nameIndex,
            ushort maxStack,
            ushort maxLocals,
            IList<JvmInstruction> instructions,
            IList<JvmExceptionHandler> exceptionHandlers,
            IList<JvmAttribute> attributes)
            : base(nameIndex)
        {
            MaxStack = maxStack;
            MaxLocals = maxLocals;
            Instructions = instructions;
            ExceptionHandlers = exceptionHandlers;
            Attributes = attributes;
        }

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

        public IList<JvmInstruction> Instructions
        {
            get;
            set;
        }

        public IList<JvmExceptionHandler> ExceptionHandlers
        {
            get;
            set;
        }

        public IList<JvmAttribute> Attributes
        {
            get;
            set;
        }
    }
}