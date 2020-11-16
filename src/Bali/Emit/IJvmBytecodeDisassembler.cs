using System.Collections.Generic;
using System.IO;
using Bali.Metadata.Attributes;

namespace Bali.Emit
{
    /// <summary>
    /// Provides a contract for parsing JVM bytecode from a <see cref="CodeAttribute"/>.
    /// </summary>
    public interface IJvmBytecodeDisassembler
    {
        /// <summary>
        /// Parses JVM bytecode from the given <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to read data from.</param>
        /// <param name="count">The number of bytes to consume.</param>
        /// <returns>The list of parsed JVM instructions.</returns>
        IList<JvmInstruction> Disassemble(Stream stream, uint count);
    }
}