using System.IO;

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

        public static Utf8Constant Create(Stream stream)
        {
            ushort length = stream.ReadU2();
            return new Utf8Constant(JavaUtf8.Decode(stream, length));
        }
    }
}