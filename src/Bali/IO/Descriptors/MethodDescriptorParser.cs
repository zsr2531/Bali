using System;
using System.Collections.Generic;

namespace Bali.IO.Descriptors
{
    public readonly struct MethodDescriptorParser
    {
        private readonly DescriptorTokenStream? _tokenStream;

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