namespace Bali.IO.Constants
{
    public class Utf8Constant : Constant
    {
        public Utf8Constant(string value)
            : base(ConstantKind.Utf8) => Value = value;

        public string Value
        {
            get;
        }
    }
}