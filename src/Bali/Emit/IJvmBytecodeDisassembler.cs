using System.Collections.Generic;
using Bali.IO;

namespace Bali.Emit
{
    /// <summary>
    /// Provides a contract for disassembling JVM bytecode.
    /// </summary>
    public interface IJvmBytecodeDisassembler
    {
        /// <summary>
        /// Disassembles JVM bytecode from the given <paramref name="reader"/>.
        /// </summary>
        /// <param name="reader">The <see cref="IBigEndianReader"/> to read data from.</param>
        /// <param name="count">The number of bytes to consume.</param>
        /// <returns>The list of parsed JVM instructions.</returns>
        IList<JvmInstruction> Disassemble(IBigEndianReader reader, uint count);
    }
}