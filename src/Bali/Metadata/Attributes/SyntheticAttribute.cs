namespace Bali.Metadata.Attributes
{
    public sealed class SyntheticAttribute : Attribute
    {
        public SyntheticAttribute(ushort nameIndex)
            : base(nameIndex) { }
    }
}