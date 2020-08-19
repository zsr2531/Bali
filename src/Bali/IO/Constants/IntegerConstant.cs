using System.IO;

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
        
        public static IntegerConstant Create(Stream stream) => new IntegerConstant((int) stream.ReadU4());
    }
}