namespace Bali.Emit.Operands
{
    public class WideLocalIndexWithSignedShort
    {
        public WideLocalIndexWithSignedShort(ushort localIndex, short signedByte)
        {
            LocalIndex = localIndex;
            SignedByte = signedByte;
        }

        public ushort LocalIndex
        {
            get;
            set;
        }

        public short SignedByte
        {
            get;
            set;
        }
    }
}