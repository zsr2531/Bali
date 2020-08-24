using System;

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
            if (typeToken.Kind == DescriptorTokenKind.ClassName)
                return new NonPrimitiveFieldDescriptor(arrayRank, NonPrimitive(typeToken));
            
            return new PrimitiveFieldDescriptor(arrayRank, Primitive(typeToken));
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

        private static string NonPrimitive(DescriptorToken token)
        {
            var value = token.Value;

            return value.Slice(1, value.Length - 2).ToString();
        }

        private static PrimitiveKind Primitive(DescriptorToken token)
        {
            // ReSharper disable once SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
            return token.Kind switch
            {
                DescriptorTokenKind.Byte => PrimitiveKind.Byte,
                DescriptorTokenKind.Char => PrimitiveKind.Char,
                DescriptorTokenKind.Double => PrimitiveKind.Double,
                DescriptorTokenKind.Float => PrimitiveKind.Float,
                DescriptorTokenKind.Int => PrimitiveKind.Int,
                DescriptorTokenKind.Long => PrimitiveKind.Long,
                DescriptorTokenKind.Short => PrimitiveKind.Short,
                DescriptorTokenKind.Boolean => PrimitiveKind.Boolean,
                DescriptorTokenKind.Void => PrimitiveKind.Void,
                _ => throw new DescriptorParserException($"Unexpected token <{token.Kind}>.")
            };
        }
    }
}