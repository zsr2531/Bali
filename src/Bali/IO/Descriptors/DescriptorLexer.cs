using System;
using System.Collections.Generic;

namespace Bali.IO.Descriptors
{
    /// <summary>
    /// A simple lexer that turns Java descriptor strings into a token stream.
    /// </summary>
    public struct DescriptorLexer
    {
        private readonly ReadOnlyMemory<char> _text;

        private int _position;

        /// <summary>
        /// Creates a new <see cref="DescriptorLexer"/> with the given input <paramref name="text"/>
        /// </summary>
        /// <param name="text">The input to lex.</param>
        public DescriptorLexer(ReadOnlyMemory<char> text)
        {
            _text = text;
            _position = 0;
        }

        private char Current => _position >= _text.Length ? '\0' : _text.Span[_position];

        /// <summary>
        /// Turns the input text into a stream of <see cref="DescriptorToken"/>s.
        /// </summary>
        /// <returns>A stream of <see cref="DescriptorToken"/>s.</returns>
        /// <exception cref="ArgumentException">
        /// When no input text is provided.
        /// </exception>
        /// <exception cref="DescriptorLexerException">
        /// When during the lexical analysis of a reference token, the input unexpectedly ends.
        /// </exception>
        public DescriptorTokenStream Lex()
        {
            if (_text.IsEmpty)
                throw new ArgumentException("No input text was provided.");

            return new DescriptorTokenStream(Supply);
        }

        private DescriptorToken Supply()
        {
            switch (Current)
            {
                case '\0':
                {
                    var span = new TextSpan(_position, _position);
                    var token = new DescriptorToken(span, DescriptorTokenKind.EndOfFile, ReadOnlyMemory<char>.Empty);

                    return token;
                }

                case 'L':
                {
                    int start = _position;
                    while (Next() != ';')
                    {
                        if (Current == '\0')
                            return CreateToken(start, DescriptorTokenKind.Bad);
                    }

                    return CreateToken(start, DescriptorTokenKind.ClassName);
                }

                default:
                    return SingleCharacter();
            }
        }

        private DescriptorToken CreateToken(int start, DescriptorTokenKind tokenKind)
        {
            var span = new TextSpan(start, _position - 1);
            var text = _text.Slice(start, _position - start);
            
            return new DescriptorToken(span, tokenKind, text);
        }

        private DescriptorToken SingleCharacter()
        {
            var span = new TextSpan(_position, _position + 1);
            var text = _text.Slice(_position, 1);
            var token = Next() switch
            {
                '(' => DescriptorTokenKind.LeftParenthesis,
                ')' => DescriptorTokenKind.RightParenthesis,
                '[' => DescriptorTokenKind.LeftBracket,
                'B' => DescriptorTokenKind.Byte,
                'C' => DescriptorTokenKind.Char,
                'D' => DescriptorTokenKind.Double,
                'F' => DescriptorTokenKind.Float,
                'I' => DescriptorTokenKind.Int,
                'J' => DescriptorTokenKind.Long,
                'S' => DescriptorTokenKind.Short,
                'Z' => DescriptorTokenKind.Boolean,
                'V' => DescriptorTokenKind.Void,
                _ => DescriptorTokenKind.Bad
            };
            
            return new DescriptorToken(span, token, text);
        }

        private char Next()
        {
            if (_position >= _text.Length)
                return '\0';
            
            char temp = Current;
            _position++;
            return temp;
        }
    }
}