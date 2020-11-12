namespace Bali.Emit.Operands
{
    public class WideConstantPoolIndexWithArrayDimensions
    {
        public WideConstantPoolIndexWithArrayDimensions(ushort wideConstantPoolIndex, byte arrayDimensions)
        {
            WideConstantPoolIndex = wideConstantPoolIndex;
            ArrayDimensions = arrayDimensions;
        }

        public ushort WideConstantPoolIndex
        {
            get;
            set;
        }

        public byte ArrayDimensions
        {
            get;
            set;
        }
    }
}