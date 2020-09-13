using System.IO;
using Bali.IO;

namespace Bali.Metadata.Attributes
{
    public sealed class SignatureAttribute : Attribute
    {
        public SignatureAttribute(ushort nameIndex, ushort signatureIndex) : base(nameIndex)
        {
            SignatureIndex = signatureIndex;
        }

        public ushort SignatureIndex
        {
            get;
        }

        /// <inheritdoc />
        public override byte[] Data => new[]
        {
            (byte) ((SignatureIndex >> 8) & 0xFF), (byte) (SignatureIndex & 0xFF)
        };

        public static SignatureAttribute Create(Stream stream, ushort nameIndex) =>
            new SignatureAttribute(nameIndex, stream.ReadU2());
    }
}