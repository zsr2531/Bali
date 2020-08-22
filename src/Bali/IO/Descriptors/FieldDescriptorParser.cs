using System;
using System.Collections.Generic;

namespace Bali.IO.Descriptors
{
    /// <summary>
    /// Parses a stream of <see cref="DescriptorToken"/>s into
    /// a <see cref="NonPrimitiveFieldDescriptor"/> or a <see cref="PrimitiveFieldDescriptor"/>.
    /// </summary>
    public readonly struct FieldDescriptorParser
    {
        private readonly IEnumerable<DescriptorToken>? _tokenStream;

        /// <summary>
        /// Creates a new <see cref="FieldDescriptorParser"/> with the given <paramref name="tokenStream"/>.
        /// </summary>
        /// <param name="tokenStream">The stream of <see cref="DescriptorToken"/>s to parse.</param>
        public FieldDescriptorParser(IEnumerable<DescriptorToken> tokenStream) => _tokenStream = tokenStream;

        /// <summary>
        /// Parse the token stream into a <see cref="FieldDescriptor"/>.
        /// </summary>
        /// <returns>
        /// Either a <see cref="PrimitiveFieldDescriptor"/> or a <see cref="NonPrimitiveFieldDescriptor"/>
        /// depending on the input.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// When no stream of <see cref="DescriptorToken"/>s was provided.
        /// </exception>
        /// <exception cref="DescriptorParserException">
        /// When the input contains a bad token or the input is invalid.
        /// </exception>
        public FieldDescriptor Parse()
        {
            if (_tokenStream is null)
                throw new ArgumentException("No token stream was provided.");

            int arrayRank = 0;
            FieldDescriptor? descriptor = null;

            foreach (var token in _tokenStream)
            {
                var type = token.Kind;
                if (type == DescriptorTokenKind.EndOfFile)
                    break;

                switch (type)
                {
                    case DescriptorTokenKind.Bad:
                    {
                        DescriptorParserException.ThrowBadToken(token);
                        break;
                    }

                    case DescriptorTokenKind.LeftParenthesis:
                    case DescriptorTokenKind.RightParenthesis:
                    case DescriptorTokenKind.Void:
                    {
                        DescriptorParserException.ThrowUnexpectedToken(token);
                        break;
                    }

                    case DescriptorTokenKind.LeftBracket when descriptor is null:
                    {
                        arrayRank++;
                        break;
                    }

                    default:
                    {
                        if (descriptor is {})
                            DescriptorParserException.ThrowUnexpectedToken(token, DescriptorTokenKind.EndOfFile);

                        if (type == DescriptorTokenKind.ClassName)
                        {
                            var className = token.Value.Span[token.Value.Length - 2] == ';'
                                ? token.Value.Slice(1, token.Value.Length - 2) // Skip 'L' from the beginning and ';' from the end.
                                : token.Value;
                            descriptor = new NonPrimitiveFieldDescriptor(arrayRank, className.ToString());
                        }
                        else
                        {
                            var primitive = type switch
                            {
                                DescriptorTokenKind.Byte => PrimitiveKind.Byte,
                                DescriptorTokenKind.Boolean => PrimitiveKind.Boolean,
                                DescriptorTokenKind.Char => PrimitiveKind.Char,
                                DescriptorTokenKind.Int => PrimitiveKind.Int,
                                DescriptorTokenKind.Long => PrimitiveKind.Long,
                                DescriptorTokenKind.Float => PrimitiveKind.Float,
                                DescriptorTokenKind.Double => PrimitiveKind.Double,
                                _ => default // Unreachable.
                            };

                            descriptor = new PrimitiveFieldDescriptor(arrayRank, primitive);
                        }

                        break;
                    }
                }
            }
            
            if (descriptor is null)
                throw new DescriptorParserException("Invalid field descriptor.");

            return descriptor;
        }
    }
}