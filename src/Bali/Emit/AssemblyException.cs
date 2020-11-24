using System;

namespace Bali.Emit
{
    /// <summary>
    /// An exception that is used in the <see cref="IJvmBytecodeAssembler"/>.
    /// </summary>
    public class AssemblyException : Exception
    {
        /// <summary>
        /// Creates a new <see cref="AssemblyException"/>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        public AssemblyException(string message)
            : base(message) { }
    }
}