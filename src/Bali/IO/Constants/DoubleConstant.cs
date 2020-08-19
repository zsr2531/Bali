using System.IO;

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

        public static unsafe DoubleConstant Create(Stream stream)
        {
            ulong bits = stream.ReadU8();
            return new DoubleConstant(*(double*)&bits);
        }
    }
}