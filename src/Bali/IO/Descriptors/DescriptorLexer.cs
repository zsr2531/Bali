using System;
using System.Collections.Generic;

namespace Bali.IO.Descriptors
{
    /// <summary>
    /// A simple lexer that turns Java descriptor strings into a token stream.
    /// </summary>
    public sealed class DescriptorLexer
    {
        private readonly ReadOnlyMemory<char> _text;

        private int _position;

        /// <summary>
        /// Creates a new <see cref="DescriptorLexer"/> with the given input <paramref name="text"/>
        /// </summary>
        /// <param name="text">The input to lex.</param>
        public DescriptorLexer(ReadOnlyMemory<char> text) => _text = text;

        private char Current => _text.Span[_position];

        /// <summary>
        /// Turns the input text into a stream of <see cref="DescriptorToken"/>s.
        /// </summary>
        /// <returns>A stream of <see cref="DescriptorToken"/>s.</returns>
        /// <exception cref="DescriptorLexerException">
        /// When during the lexical analysis of a reference token, the input unexpectedly ends.
        /// </exception>
        public IEnumerable<DescriptorToken> Lex()
        {
            switch (Current)
            {
                case '\0':
                {
                    var span = new TextSpan(_position, _position);
                    var token = new DescriptorToken(span, DescriptorTokenKind.EndOfFile, ReadOnlyMemory<char>.Empty);
                    
                    yield return token;
                    yield break;
                }

                case 'L':
                {
                    int start = _position;
                    while (Next() != ';')
                    {
                        if (Current == '\0')
                            throw new DescriptorLexerException("Unexpected end of input.");
                    }
                
                    var span = new TextSpan(start, _position);
                    var text = _text.Slice(start, _position);
                    
                    yield return new DescriptorToken(span, DescriptorTokenKind.ClassName, text);
                    break;
                }

                default:
                    yield return SingleCharacter();
                    break;
            }
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