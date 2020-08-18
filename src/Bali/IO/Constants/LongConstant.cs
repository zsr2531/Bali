namespace Bali.IO.Constants
{
    public class LongConstant : Constant
    {
        public LongConstant(long value)
            : base(ConstantKind.Long) => Value = value;

        public long Value
        {
            get;
        }
    }
}