using System.IO;

namespace Bali.IO.Constants
{
    public class MethodTypeConstant : Constant
    {
        public MethodTypeConstant(ushort descriptorIndex)
            : base(ConstantKind.MethodType) => DescriptorIndex = descriptorIndex;

        public ushort DescriptorIndex
        {
            get;
        }
        
        public static MethodTypeConstant Create(Stream stream) => new MethodTypeConstant(stream.ReadU2());
    }
}