using System;
using System.Diagnostics;

namespace Bali.IO.Descriptors
{
    /// <summary>
    /// Represents a token in a Java field/method descriptor string.
    /// </summary>
    [DebuggerDisplay("{" + nameof(Debug) + ",nq}")]
    public readonly struct DescriptorToken
    {
        /// <summary>
        /// Creates a new <see cref="DescriptorToken"/>.
        /// </summary>
        /// <param name="span">The <see cref="TextSpan"/> indicating the start and the end positions.</param>
        /// <param name="kind">The type of the token.</param>
        /// <param name="value">The raw text.</param>
        public DescriptorToken(TextSpan span, DescriptorTokenKind kind, ReadOnlyMemory<char> value)
        {
            Span = span;
            Kind = kind;
            Value = value;
        }

        /// <summary>
        /// The start and end positions of the <see cref="DescriptorToken"/>.
        /// </summary>
        public TextSpan Span
        {
            get;
        }

        /// <summary>
        /// The type of the <see cref="DescriptorToken"/>.
        /// </summary>
        public DescriptorTokenKind Kind
        {
            get;
        }
        
        /// <summary>
        /// The text that the <see cref="DescriptorToken"/> was lexed from.
        /// </summary>
        public ReadOnlyMemory<char> Value
        {
            get;
        }

        private string Debug => $"({Span.Start},{Span.End})<{Kind}>:{string.Join("", Value.ToArray())}";
    }
}