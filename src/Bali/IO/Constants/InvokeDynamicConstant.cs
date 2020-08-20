using System.IO;

namespace Bali.IO.Constants
{
    public class InvokeDynamicConstant : Constant
    {
        public InvokeDynamicConstant(ushort bootstrapMethodAttributeIndex, ushort nameAndTypeIndex)
            : base(ConstantKind.InvokeDynamic)
        {
            BootstrapMethodAttributeIndex = bootstrapMethodAttributeIndex;
            NameAndTypeIndex = nameAndTypeIndex;
        }

        public ushort BootstrapMethodAttributeIndex
        {
            get;
        }

        public ushort NameAndTypeIndex
        {
            get;
        }

        public static InvokeDynamicConstant Create(Stream stream) =>
            new InvokeDynamicConstant(stream.ReadU2(), stream.ReadU2());
    }
}