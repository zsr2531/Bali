namespace Bali.IO.Descriptors
{
    /// <summary>
    /// Represents a Java field descriptor.
    /// </summary>
    public abstract class FieldDescriptor
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
    }
}