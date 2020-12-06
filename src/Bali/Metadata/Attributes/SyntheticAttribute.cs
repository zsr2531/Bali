using Bali.SourceGeneration;

namespace Bali.Metadata.Attributes
{
    [AutoFactory]
    [AutoBuilder]
    public sealed class SyntheticAttribute : JvmAttribute
    {
        public SyntheticAttribute(ushort nameIndex)
            : base(nameIndex) { }
    }
}