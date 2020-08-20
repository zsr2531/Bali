namespace Bali.IO.Descriptors
{
    public sealed class Token
    {
        public Token(TextSpan span, TokenKind kind, string value)
        {
            Span = span;
            Kind = kind;
            Value = value;
        }

        public TextSpan Span
        {
            get;
        }

        public TokenKind Kind
        {
            get;
        }
        
        public string Value
        {
            get;
        }
    }
}