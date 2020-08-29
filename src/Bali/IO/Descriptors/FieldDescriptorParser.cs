using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Bali.IO.Descriptors
{
    /// <summary>
    /// Parses a stream of <see cref="DescriptorToken"/>s into
    /// a <see cref="NonPrimitiveFieldDescriptor"/> or a <see cref="PrimitiveFieldDescriptor"/>.
    /// </summary>
    public readonly struct FieldDescriptorParser
    {
        private readonly DescriptorTokenStream? _tokenStream;

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
            if (_tokenStream is null)
                throw new ArgumentException("No input stream was provided.");
            
            int arrayRank = ArrayRank();
            var typeToken = _tokenStream.Next();
            if (typeToken.Kind != DescriptorTokenKind.L)
                return new PrimitiveFieldDescriptor(arrayRank, Primitive(typeToken));

            string className = NonPrimitive();
            var genericParameters = _tokenStream.Lookahead().Kind == DescriptorTokenKind.LeftAngledBracket
                ? GenericParameters()
                : Array.Empty<FieldDescriptor>();
            
            return new NonPrimitiveFieldDescriptor(arrayRank, className, genericParameters);
        }

        private int ArrayRank()
        {
            int bracketCount = 0;
            while (_tokenStream!.Lookahead().Kind == DescriptorTokenKind.LeftBracket)
            {
                _tokenStream.Next();
                bracketCount++;
            }

            return bracketCount;
        }

        private string NonPrimitive()
        {
            var sb = new StringBuilder();
            DescriptorToken token;

            while ((token = _tokenStream!.Lookahead()).Kind != DescriptorTokenKind.Semicolon &&
                token.Kind != DescriptorTokenKind.LeftAngledBracket)
            {
                if (token.Kind == DescriptorTokenKind.EndOfFile)
                    throw new DescriptorParserException("Unexpected end of input.");

                _tokenStream.Next();
                sb.Append(token.Value.ToString());
            }

            if (token.Kind == DescriptorTokenKind.Semicolon)
                _tokenStream.Next();

            return sb.ToString();
        }

        private IReadOnlyList<FieldDescriptor> GenericParameters()
        {
            var parameters = new List<FieldDescriptor>();
            _tokenStream!.Next(); // Consume left angled bracket token.
            
            while (_tokenStream.Lookahead().Kind != DescriptorTokenKind.RightAngledBracket)
                parameters.Add(Parse());

            _tokenStream.Next(); // Consume right angled bracket token.
            return parameters.AsReadOnly();
        }

        [SuppressMessage("ReSharper", "SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault")]
        private static PrimitiveKind Primitive(DescriptorToken token)
        {
            return token.Kind switch
            {
                DescriptorTokenKind.B => PrimitiveKind.Byte,
                DescriptorTokenKind.C => PrimitiveKind.Char,
                DescriptorTokenKind.D => PrimitiveKind.Double,
                DescriptorTokenKind.F => PrimitiveKind.Float,
                DescriptorTokenKind.I => PrimitiveKind.Int,
                DescriptorTokenKind.J => PrimitiveKind.Long,
                DescriptorTokenKind.S => PrimitiveKind.Short,
                DescriptorTokenKind.Z => PrimitiveKind.Boolean,
                DescriptorTokenKind.V => PrimitiveKind.Void,
                _ => throw new DescriptorParserException($"Unexpected token <{token.Kind}>.")
            };
        }
    }
}