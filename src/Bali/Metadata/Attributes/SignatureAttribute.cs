using Bali.SourceGeneration;

namespace Bali.Metadata.Attributes
{
    [AutoBuilder]
    public sealed class SignatureAttribute : JvmAttribute
    {
        public SignatureAttribute(ushort nameIndex, ushort signatureIndex)
            : base(nameIndex)
        {
            SignatureIndex = signatureIndex;
        }

        public ushort SignatureIndex
        {
            get;
            set;
        }
    }
}