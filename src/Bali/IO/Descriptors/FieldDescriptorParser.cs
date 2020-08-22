using System;

namespace Bali.IO.Descriptors
{
    /// <summary>
    /// Parses a stream of <see cref="DescriptorToken"/>s into
    /// a <see cref="NonPrimitiveFieldDescriptor"/> or a <see cref="PrimitiveFieldDescriptor"/>.
    /// </summary>
    public readonly struct FieldDescriptorParser
    {
        private readonly DescriptorTokenStream _tokenStream;

        /// <summary>
        /// Creates a new <see cref="FieldDescriptorParser"/>.
        /// </summary>
        /// <param name="tokenStream">The stream of <see cref="DescriptorToken"/>s to parse.</param>
        public FieldDescriptorParser(DescriptorTokenStream tokenStream) => _tokenStream = tokenStream;

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
            int arrayRank = 0;

            while (true)
            {
                var token = _tokenStream.Next();
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

                    case DescriptorTokenKind.LeftBracket:
                    {
                        arrayRank++;
                        break;
                    }

                    default:
                    {
                        if (type == DescriptorTokenKind.ClassName)
                        {
                            var className = token.Value.Span[token.Value.Length - 1] == ';'
                                ? token.Value.Slice(1, token.Value.Length - 2) // Skip 'L' from the beginning and ';' from the end.
                                : token.Value;
                            
                            return new NonPrimitiveFieldDescriptor(arrayRank, className.ToString());
                        }

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

                        return new PrimitiveFieldDescriptor(arrayRank, primitive);
                    }
                }
            }
            
            throw new DescriptorParserException("Invalid field descriptor.");
        }
    }
}