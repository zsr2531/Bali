using System;

namespace Bali.IO.Descriptors
{
    /// <summary>
    /// An exception that is used within descriptor parsers.
    /// </summary>
    public sealed class DescriptorParserException : Exception
    {
        /// <summary>
        /// Creates a new <see cref="DescriptorParserException"/> with the given <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message to give to the exception.</param>
        public DescriptorParserException(string message)
            : base(message) { }
        
        /// <summary>
        /// Throws a <see cref="DescriptorParserException"/> with an unexpected token message.
        /// </summary>
        /// <param name="token">The <see cref="DescriptorToken"/> that wasn't expected.</param>
        /// <param name="expected">The token that was expected.</param>
        public static void ThrowUnexpectedToken(DescriptorToken token, DescriptorTokenKind expected) =>
            throw new DescriptorParserException($"Unexpected token <{token.Kind}>, expected <{expected}>.");
    }
}