namespace Bali.IO.Constants
{
    public class FloatConstant : Constant
    {
        public FloatConstant(float value)
            : base(ConstantKind.Float) => Value = value;

        public float Value
        {
            get;
        }
    }
}