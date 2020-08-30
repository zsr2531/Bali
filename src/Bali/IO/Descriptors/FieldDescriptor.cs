using System;

namespace Bali.IO.Descriptors
{
    /// <summary>
    /// Represents a Java field descriptor.
    /// </summary>
    public abstract class FieldDescriptor : IEquatable<FieldDescriptor>
    {
        /// <summary>
        /// Initialises the <see cref="ArrayRank"/> to <paramref name="arrayRank"/>.
        /// </summary>
        /// <param name="arrayRank">The array rank.</param>
        protected FieldDescriptor(int arrayRank) =>
            ArrayRank = arrayRank;

        /// <summary>
        /// The <see cref="FieldDescriptor"/>'s array rank.
        /// </summary>
        /// <remarks>If this is <c>0</c>, then the descriptor is not an array.</remarks>
        public int ArrayRank
        {
            get;
        }

        /// <inheritdoc />
        public abstract bool Equals(FieldDescriptor? other);

        /// <inheritdoc />
        public abstract override bool Equals(object? obj);

        /// <inheritdoc />
        public abstract override int GetHashCode();

        /// <summary>
        /// Determines whether <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </summary>
        /// <param name="left">The left side of the comparison.</param>
        /// <param name="right">The right side of the comparison.</param>
        /// <returns>Whether <paramref name="left"/> and <paramref name="right"/> are equal.</returns>
        public static bool operator ==(FieldDescriptor? left, FieldDescriptor? right) => Equals(left, right);

        /// <summary>
        /// Determines whether <paramref name="left"/> and <paramref name="right"/> are not equal.
        /// </summary>
        /// <param name="left">The left side of the comparison.</param>
        /// <param name="right">The right side of the comparison.</param>
        /// <returns>Whether <paramref name="left"/> and <paramref name="right"/> are not equal.</returns>
        public static bool operator !=(FieldDescriptor? left, FieldDescriptor? right) => !Equals(left, right);
    }
}