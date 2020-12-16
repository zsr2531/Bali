using System.Collections.Generic;
using System.IO;

namespace Bali.Emit
{
    /// <summary>
    /// Provides a contract for serializing JVM bytecode.
    /// </summary>
    public interface IJvmBytecodeAssembler
    {
        /// <summary>
        /// Assembles the given <paramref name="instructions"/> to the output <paramref name="stream"/>.
        /// </summary>
        /// <param name="instructions">The list of <see cref="JvmInstruction"/>s to assemble.</param>
        /// <param name="stream">The output <see cref="Stream"/> to write data to.</param>
        void Assemble(IList<JvmInstruction> instructions, Stream stream);
    }
}