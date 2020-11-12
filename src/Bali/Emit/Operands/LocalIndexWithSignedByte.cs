namespace Bali.Emit.Operands
{
    public class LocalIndexWithSignedByte
    {
        public LocalIndexWithSignedByte(byte localIndex, sbyte signedByte)
        {
            LocalIndex = localIndex;
            SignedByte = signedByte;
        }

        public byte LocalIndex
        {
            get;
            set;
        }

        public sbyte SignedByte
        {
            get;
            set;
        }
    }
}