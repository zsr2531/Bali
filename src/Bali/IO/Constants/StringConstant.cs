using System.IO;

namespace Bali.IO.Constants
{
    public class StringConstant : Constant
    {
        public StringConstant(ushort stringIndex)
            : base(ConstantKind.String) => StringIndex = stringIndex;

        public ushort StringIndex
        {
            get;
        }

        public static StringConstant Create(Stream stream) => new StringConstant(stream.ReadU2());
    }
}