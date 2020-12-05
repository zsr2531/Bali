using System.IO;
using Bali.IO;
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

        public static SignatureAttribute Create(Stream stream, ushort nameIndex) =>
            new SignatureAttribute(nameIndex, stream.ReadU2());
    }
}