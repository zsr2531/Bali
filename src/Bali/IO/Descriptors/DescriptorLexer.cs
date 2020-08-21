using System;
using System.Collections.Generic;

namespace Bali.IO.Descriptors
{
    public class DescriptorLexer
    {
        private readonly ReadOnlyMemory<char> _text;

        private int _position;

        public DescriptorLexer(ReadOnlyMemory<char> text) =>
            _text = text;

        private char Current => _text.Span[_position];

        public IEnumerable<DescriptorToken> Lex()
        {
            if (Current == '\0')
            {
                var span = new TextSpan(_position, _position);
                var token = new DescriptorToken(span, DescriptorTokenKind.EndOfFile, ReadOnlyMemory<char>.Empty);
                yield return token;
                yield break;
            }

            if (Current == 'L')
            {
                int start = _position;
                while (Next() != ';')
                {
                    if (Current == '\0')
                        throw new Exception("Unexpected end of input.");
                }
                
                var span = new TextSpan(start, _position);
                var text = _text.Slice(start, _position);
                yield return new DescriptorToken(span, DescriptorTokenKind.ClassName, text);
            }
            else
            {
                yield return SingleCharacter();
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