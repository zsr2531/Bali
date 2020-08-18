namespace Bali.IO.Constants
{
    public class ClassConstant : Constant
    {
        public ClassConstant(ushort nameIndex)
            : base(ConstantKind.Class) => NameIndex = nameIndex;

        public ushort NameIndex
        {
            get;
        }
    }
}