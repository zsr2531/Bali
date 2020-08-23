using System;
using System.Collections.Generic;

namespace Bali.IO.Descriptors
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

        public MethodDescriptor Parse()
        {
            if (_tokenStream is null)
                throw new ArgumentException("No input stream was provided.");

            var fieldDescriptorParser = new FieldDescriptorParser(_tokenStream);
            var parameters = new List<FieldDescriptor>();
            
            while (true)
            {
                var token = _tokenStream.Lookahead();
                if (token.Kind == DescriptorTokenKind.EndOfFile)
                    DescriptorParserException.ThrowUnexpectedToken(token);

                switch (token.Kind)
                {
                    case DescriptorTokenKind.LeftParenthesis:
                    {
                        _tokenStream.Next();
                        break;
                    }

                    case DescriptorTokenKind.RightParenthesis:
                    {
                        _tokenStream.Next();
                        return new MethodDescriptor(fieldDescriptorParser.Parse(), parameters);
                    }

                    default:
                    {
                        parameters.Add(fieldDescriptorParser.Parse());
                        break;
                    }
                }
            }
        }
    }
}