using System.Collections.Generic;
using System.IO;

namespace Bali.Emit
{
    public interface IJvmBytecodeDisassembler
    {
        IList<JvmInstruction> Disassemble(Stream stream, uint count);
    }
}