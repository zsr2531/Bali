namespace Bali.IO.Constants
{
    public class NameAndTypeConstant : Constant
    {
        public NameAndTypeConstant(ushort nameIndex, ushort descriptorIndex)
            : base(ConstantKind.NameAndType)
        {
            NameIndex = nameIndex;
            DescriptorIndex = descriptorIndex;
        }

        public ushort NameIndex
        {
            get;
        }

        public ushort DescriptorIndex
        {
            get;
        }
    }
}