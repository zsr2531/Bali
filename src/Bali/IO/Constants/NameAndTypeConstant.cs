using System.IO;

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
        
        public static NameAndTypeConstant Create(Stream stream) =>
            new NameAndTypeConstant(stream.ReadU2(), stream.ReadU2());
    }
}