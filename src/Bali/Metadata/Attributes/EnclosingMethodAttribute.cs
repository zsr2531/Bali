using System.IO;
using Bali.IO;

namespace Bali.Metadata.Attributes
{
    public sealed class EnclosingMethodAttribute : Attribute
    {
        public EnclosingMethodAttribute(ushort nameIndex, ushort classIndex, ushort methodIndex)
            : base(nameIndex)
        {
            ClassIndex = classIndex;
            MethodIndex = methodIndex;
        }

        public ushort ClassIndex
        {
            get;
        }

        public ushort MethodIndex
        {
            get;
        }

        /// <inheritdoc />
        public override byte[] Data => new[]
        {
            (byte) ((ClassIndex >> 8) & 0xFF), (byte) (ClassIndex & 0xFF),
            (byte) ((MethodIndex >> 8) & 0xFF), (byte) (MethodIndex & 0xFF)
        };

        public static EnclosingMethodAttribute Create(Stream stream, ushort nameIndex) =>
            new EnclosingMethodAttribute(nameIndex, stream.ReadU2(), stream.ReadU2());
    }
}