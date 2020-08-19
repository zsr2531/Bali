using System.IO;

namespace Bali.IO.Constants
{
    public class InterfaceMethodrefConstant : Constant
    {
        public InterfaceMethodrefConstant(ushort classIndex, ushort nameAndTypeIndex)
            : base(ConstantKind.InterfaceMethodref)
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
        
        public static InterfaceMethodrefConstant Create(Stream stream) =>
            new InterfaceMethodrefConstant(stream.ReadU2(), stream.ReadU2());
    }
}