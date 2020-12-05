using Bali.SourceGeneration;

namespace Bali.Metadata.Attributes
{
    [AutoBuilder]
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
    }
}