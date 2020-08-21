using System.Collections.Generic;

namespace Bali.IO.Descriptors
{
    public class DescriptorLexer
    {
        private readonly string _text;

        private int _position;

        public DescriptorLexer(string text) =>
            _text = text;

        private char Current => _text[_position];

        public IReadOnlyList<DescriptorToken> Lex()
        {
            var tokens = new List<DescriptorToken>();

            return tokens.AsReadOnly();
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