using System.IO;
using Bali.IO;

namespace Bali.Metadata.Attributes
{
    public sealed class EnclosingMethodAttribute : JvmAttribute
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
            set;
        }

        public ushort MethodIndex
        {
            get;
            set;
        }

        public static EnclosingMethodAttribute Create(Stream stream, ushort nameIndex) =>
            new EnclosingMethodAttribute(nameIndex, stream.ReadU2(), stream.ReadU2());
    }
}