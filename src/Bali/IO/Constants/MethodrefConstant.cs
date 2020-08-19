using System.IO;

namespace Bali.IO.Constants
{
    public class MethodrefConstant : Constant
    {
        public MethodrefConstant(ushort classIndex, ushort nameAndTypeIndex)
            : base(ConstantKind.Methodref)
        {
            ClassIndex = classIndex;
            NameAndTypeIndex = nameAndTypeIndex;
        }

        public ushort ClassIndex
        {
            get;
        }

        public ushort NameAndTypeIndex
        {
            get;
        }
        
        public static MethodrefConstant Create(Stream stream) => new MethodrefConstant(stream.ReadU2(), stream.ReadU2());
    }
}