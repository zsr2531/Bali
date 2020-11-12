namespace Bali.Emit.Operands
{
    public class WideConstantPoolIndexWithTwoBytes
    {
        public WideConstantPoolIndexWithTwoBytes(ushort wideConstantPoolIndex, byte byteOne, byte byteTwo)
        {
            WideConstantPoolIndex = wideConstantPoolIndex;
            ByteOne = byteOne;
            ByteTwo = byteTwo;
        }

        public ushort WideConstantPoolIndex
        {
            get;
            set;
        }

        public byte ByteOne
        {
            get;
            set;
        }

        public byte ByteTwo
        {
            get;
            set;
        }
    }
}