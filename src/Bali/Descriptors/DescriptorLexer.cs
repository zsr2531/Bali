using System;
using System.Collections.Generic;

namespace Bali.Descriptors
{
    /// <summary>
    /// A simple lexer that turns Java descriptor strings into a token stream.
    /// </summary>
    public struct DescriptorLexer
    {
        private readonly ReadOnlyMemory<char> _text;

        private int _position;
        
        private static readonly IList<char> Special = new []
        {
            '.', ';', '[', '/', '<', '>', '(', ')',
            'B', 'C', 'D', 'F', 'I', 'J', 'S', 'Z', 'V', 'L'
        };

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
        public DescriptorTokenStream Lex()
        {
            if (_text.IsEmpty)
                throw new ArgumentException("No input text was provided.");

            return new DescriptorTokenStream(Supply);
        }

        private DescriptorToken Supply()
        {
            if (Current == '\0')
            {
                var span = new TextSpan(_position, _position);
                var token = new DescriptorToken(span, DescriptorTokenKind.EndOfFile, ReadOnlyMemory<char>.Empty);

                return token;
            }

            if (Special.Contains(Current))
                return SingleCharacter();

            int start = _position;
            while (!Special.Contains(Current) && _position < _text.Length)
                Next();

            return CreateIdentifierToken(start);
        }

        private DescriptorToken CreateIdentifierToken(int start)
        {
            var span = new TextSpan(start, _position - 1);
            var text = _text.Slice(start, _position - start);
            
            return new DescriptorToken(span, DescriptorTokenKind.Identifier, text);
        }

        private DescriptorToken SingleCharacter()
        {
            var span = new TextSpan(_position, _position + 1);
            var text = _text.Slice(_position, 1);
            var token = Next() switch
            {
                '<' => DescriptorTokenKind.LeftAngledBracket,
                '>' => DescriptorTokenKind.RightAngledBracket,
                '(' => DescriptorTokenKind.LeftParenthesis,
                ')' => DescriptorTokenKind.RightParenthesis,
                '[' => DescriptorTokenKind.LeftBracket,
                'B' => DescriptorTokenKind.B,
                'C' => DescriptorTokenKind.C,
                'D' => DescriptorTokenKind.D,
                'F' => DescriptorTokenKind.F,
                'I' => DescriptorTokenKind.I,
                'J' => DescriptorTokenKind.J,
                'S' => DescriptorTokenKind.S,
                'Z' => DescriptorTokenKind.Z,
                'V' => DescriptorTokenKind.V,
                'L' => DescriptorTokenKind.L,
                ';' => DescriptorTokenKind.Semicolon,
                '/' => DescriptorTokenKind.Slash,
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