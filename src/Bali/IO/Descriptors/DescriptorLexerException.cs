using System;

namespace Bali.IO.Descriptors
{
    /// <summary>
    /// An exception that is used within the <see cref="DescriptorLexer"/>.
    /// </summary>
    public sealed class DescriptorLexerException : Exception
    {
        /// <summary>
        /// Creates a new <see cref="DescriptorLexerException"/> with the given <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message to give to the exception.</param>
        public DescriptorLexerException(string message)
            : base(message) { }
    }
}