using System;
using System.Linq;

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

        /// <inheritdoc />
        public override bool Equals(FieldDescriptor? other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return GetHashCode() == other.GetHashCode();
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (!(obj is PrimitiveFieldDescriptor other))
                return false;

            return Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode() => HashCode.Combine(ArrayRank, Kind);

        /// <inheritdoc />
        public override string ToString() => $"{string.Join("", Enumerable.Repeat("[", ArrayRank))}{Kind.ToInternalForm()}";
    }
}