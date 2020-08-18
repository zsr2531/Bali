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
    }
}