namespace Bali.IO.Descriptors
{
    /// <summary>
    /// Represents a <see cref="FieldDescriptor"/> that has a primitive type.
    /// </summary>
    public sealed class PrimitiveFieldDescriptor : FieldDescriptor
    {
        /// <summary>
        /// Creates a new <see cref="PrimitiveFieldDescriptor"/> with the given <paramref name="arrayRank"/>
        /// and <see cref="PrimitiveKind"/>.
        /// </summary>
        /// <param name="arrayRank">The array rank.</param>
        /// <param name="kind">The <see cref="PrimitiveKind"/>.</param>
        public PrimitiveFieldDescriptor(int arrayRank, PrimitiveKind kind)
            : base(arrayRank) => Kind = kind;

        /// <summary>
        /// The primitive type of the field descriptor.
        /// </summary>
        public PrimitiveKind Kind
        {
            get;
        }
    }
}