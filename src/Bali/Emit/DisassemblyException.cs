using System;

namespace Bali.Emit
{
    /// <summary>
    /// An exception that is used in the <see cref="IJvmBytecodeDisassembler"/>.
    /// </summary>
    public class DisassemblyException : Exception
    {
        /// <summary>
        /// Creates a new <see cref="DisassemblyException"/>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        public DisassemblyException(string message)
            : base(message) { }
    }
}