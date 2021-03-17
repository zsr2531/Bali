using System.Collections.Generic;
using Bali.IO;

namespace Bali.Emit
{
    /// <summary>
    /// Provides a contract for serializing JVM bytecode.
    /// </summary>
    public interface IJvmBytecodeAssembler
    {
        /// <summary>
        /// Assembles the given <paramref name="instructions"/> and writes the result to the <paramref name="writer"/>.
        /// </summary>
        /// <param name="instructions">The list of <see cref="JvmInstruction"/>s to assemble.</param>
        /// <param name="writer">The <see cref="IBigEndianWriter"/> to write the assembled <see cref="JvmInstruction"/>s to.</param>
        void Assemble(IList<JvmInstruction> instructions, IBigEndianWriter writer);
    }
}