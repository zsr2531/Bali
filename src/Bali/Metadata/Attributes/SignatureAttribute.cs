using Bali.SourceGeneration;

namespace Bali.Metadata.Attributes
{
    [AutoFactory]
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