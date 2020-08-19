using System.IO;

namespace Bali.IO.Constants
{
    public class FieldrefConstant : Constant
    {
        public FieldrefConstant(ushort classIndex, ushort nameAndTypeIndex)
            : base(ConstantKind.Fieldref)
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
        
        public static FieldrefConstant Create(Stream stream) => new FieldrefConstant(stream.ReadU2(), stream.ReadU2());
    }
}