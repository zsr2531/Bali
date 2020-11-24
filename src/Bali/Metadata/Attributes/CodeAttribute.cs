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

        /// <inheritdoc />
        public override byte[] GetData()
        {
            using var ms = Serialize();
            return ms.ToArray();
        }

        /// <inheritdoc />
        public override void WriteTo(Stream stream)
        {
            using var ms = Serialize();
            
            stream.WriteU2(NameIndex);
            stream.WriteU4((uint) ms.Length);
            ms.WriteTo(stream);
        }

        private MemoryStream Serialize()
        {
            var ms = new MemoryStream();
            
            ms.WriteU2(MaxStack);
            ms.WriteU2(MaxLocals);
            
            // TODO: Serialize instructions, need to add an assembler first

            foreach (var eh in ExceptionHandlers)
            {
                ms.WriteU2(eh.TryStart);
                ms.WriteU2(eh.TryEnd);
                ms.WriteU2(eh.HandlerStart);
                ms.WriteU2(eh.CatchType);
            }

            foreach (var attribute in Attributes)
                attribute.WriteTo(ms);
            
            return ms;
        }
    }
}