namespace Bali.IO.Constants
{
    public class IntegerConstant : Constant
    {
        public IntegerConstant(int value)
            : base(ConstantKind.Integer) => Value = value;

        public int Value
        {
            get;
        }
    }
}