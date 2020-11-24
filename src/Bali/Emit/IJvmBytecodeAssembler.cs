using System.Collections.Generic;
using System.IO;

namespace Bali.Emit
{
    public interface IJvmBytecodeAssembler
    {
        void Assemble(IList<JvmInstruction> instructions, Stream stream);
    }
}