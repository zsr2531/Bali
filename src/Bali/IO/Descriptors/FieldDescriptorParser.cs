using System;
using System.Collections.Generic;

namespace Bali.IO.Descriptors
{
    public readonly struct FieldDescriptorParser
    {
        private readonly IEnumerable<DescriptorToken>? _tokenStream;

        public FieldDescriptorParser(IEnumerable<DescriptorToken> tokenStream) => _tokenStream = tokenStream;

        public FieldDescriptor Parse()
        {
            if (_tokenStream is null)
            {
                // ReSharper disable once NotResolvedInText
                throw new ArgumentException("No token stream was provided.", "tokenStream");
            }

            int arrayRank = 0;
            FieldDescriptor descriptor = null;

            foreach (var token in _tokenStream)
            {
                var type = token.Kind;
                if (type == DescriptorTokenKind.EndOfFile)
                    break;

                switch (type)
                {
                    case DescriptorTokenKind.Bad:
                        throw new Exception($"Bad token: '{token.Value}'.");

                    case DescriptorTokenKind.LeftParenthesis:
                    case DescriptorTokenKind.RightParenthesis:
                    case DescriptorTokenKind.Void:
                        throw new Exception($"Unexpected token: <{type}>.");

                    case DescriptorTokenKind.LeftBracket when descriptor is null:
                    {
                        arrayRank++;
                        break;
                    }

                    default:
                    {
                        if (descriptor is {})
                            throw new Exception($"Unexpected token: <{type}>.");

                        if (type == DescriptorTokenKind.ClassName)
                        {
                            // Skip 'L' from the beginning and ';' from the end.
                            var className = token.Value.Slice(1, token.Value.Length - 2);
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
                                _ => throw new Exception($"Unexpected token: <{type}>.")
                            };

                            descriptor = new PrimitiveFieldDescriptor(arrayRank, primitive);
                        }

                        break;
                    }
                }
            }
            
            if (descriptor is null)
                throw new Exception("Invalid field descriptor.");

            return descriptor;
        }
    }
}