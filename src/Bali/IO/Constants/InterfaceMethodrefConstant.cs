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
    }
}