using System.Collections.Generic;
using System.IO;

namespace Bali.Emit
{
    /// <summary>
    /// Provides a contract for disassembling JVM bytecode.
    /// </summary>
    public interface IJvmBytecodeDisassembler
    {
        /// <summary>
        /// Disassembles JVM bytecode from the given <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to read data from.</param>
        /// <param name="count">The number of bytes to consume.</param>
        /// <returns>The list of parsed JVM instructions.</returns>
        IList<JvmInstruction> Disassemble(Stream stream, uint count);
    }
}