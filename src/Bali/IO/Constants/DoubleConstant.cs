namespace Bali.IO.Constants
{
    public class DoubleConstant : Constant
    {
        public DoubleConstant(double value)
            : base(ConstantKind.Double) => Value = value;

        public double Value
        {
            get;
        }
    }
}