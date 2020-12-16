using System;
using System.Collections.Generic;

namespace Bali.Descriptors
{
    /// <summary>
    /// Parses a stream of <see cref="DescriptorToken"/>s into a <see cref="MethodDescriptor"/>.
    /// </summary>
    public readonly struct MethodDescriptorParser
    {
        private readonly DescriptorTokenStream? _tokenStream;

        /// <summary>
        /// Creates a new <see cref="MethodDescriptorParser"/>.
        /// </summary>
        /// <param name="tokenStream">The stream of <see cref="DescriptorToken"/>s to parse.</param>
        public MethodDescriptorParser(DescriptorTokenStream tokenStream) => _tokenStream = tokenStream;

        /// <summary>
        /// Parses the token stream into a <see cref="MethodDescriptor"/>.
        /// </summary>
        /// <returns>The <see cref="MethodDescriptor"/> parsed from the input token stream.</returns>
        /// <exception cref="ArgumentException">
        /// When no stream of <see cref="DescriptorToken"/>s was provided.
        /// </exception>
        /// <exception cref="DescriptorParserException">
        /// When the input contains a bad token or the input is invalid.
        /// </exception>
        public MethodDescriptor Parse()
        {
            if (_tokenStream is null)
                throw new ArgumentException("No input stream was provided.");

            var parameters = Parameters();
            var returnType = ReturnType();

            return new MethodDescriptor(returnType, parameters);
        }

        private IList<FieldDescriptor> Parameters()
        {
            var leftParens = _tokenStream!.Next();
            if (leftParens.Kind != DescriptorTokenKind.LeftParenthesis)
                DescriptorParserException.ThrowUnexpectedToken(leftParens, DescriptorTokenKind.LeftParenthesis);
            
            var parser = new FieldDescriptorParser(_tokenStream);
            var parameters = new List<FieldDescriptor>();

            DescriptorTokenKind lookaheadTokenKind;
            while ((lookaheadTokenKind = _tokenStream.Lookahead().Kind) != DescriptorTokenKind.RightParenthesis)
            {
                if (lookaheadTokenKind == DescriptorTokenKind.EndOfFile)
                    throw new DescriptorParserException("Unexpected end of input.");
                    
                parameters.Add(parser.Parse());
            }

            _tokenStream.Next(); // Consume right parenthesis token.
            return parameters;
        }

        private FieldDescriptor ReturnType() => new FieldDescriptorParser(_tokenStream!).Parse();
    }
}