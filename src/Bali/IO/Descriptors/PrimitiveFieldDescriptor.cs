namespace Bali.IO.Descriptors
{
    public sealed class PrimitiveFieldDescriptor : FieldDescriptor
    {
        public PrimitiveFieldDescriptor(int arrayRank, PrimitiveKind kind)
            : base(arrayRank) => Kind = kind;

        public PrimitiveKind Kind
        {
            get;
        }
    }
}