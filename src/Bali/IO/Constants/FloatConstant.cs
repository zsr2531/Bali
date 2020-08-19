using System.IO;

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

        public static unsafe FloatConstant Create(Stream stream)
        {
            uint bits = stream.ReadU4();
            return new FloatConstant(*(float*)&bits);
        }
    }
}