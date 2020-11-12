using System.Collections.Generic;
using System.IO;
using Bali.Emit;
using Bali.IO;

namespace Bali.Metadata.Attributes
{
    public sealed class CodeAttribute : JvmAttribute
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

        public IList<JvmInstruction> Bytecode
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

        public static CodeAttribute Create(Stream stream, ushort nameIndex)
        {
            ushort maxStack = stream.ReadU2();
            ushort maxLocals = stream.ReadU2();
            var bytecode = new JvmBytecodeDisassembler().Disassemble(stream, stream.ReadU4());
            var exceptionHandlers = ReadExceptionHandlers(stream);
            ushort attributeCount = stream.ReadU2();
            
            return new CodeAttribute(nameIndex);
        }

        private static IList<JvmExceptionHandler> ReadExceptionHandlers(Stream stream)
        {
            ushort count = stream.ReadU2();
            var result = new List<JvmExceptionHandler>(count);
            
            for (int i = 0; i < count; i++)
                result.Add(new JvmExceptionHandler(stream.ReadU2(), stream.ReadU2(), stream.ReadU2(), stream.ReadU2()));

            return result;
        }
    }
}