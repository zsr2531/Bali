using Bali.SourceGeneration;

namespace Bali.Metadata.Attributes
{
    [AutoBuilder]
    public sealed class SyntheticAttribute : JvmAttribute
    {
        public SyntheticAttribute(ushort nameIndex)
            : base(nameIndex) { }
    }
}