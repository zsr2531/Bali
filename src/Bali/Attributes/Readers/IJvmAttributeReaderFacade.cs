namespace Bali.Attributes.Readers
{
    /// <summary>
    /// Provides a contract for keeping track of <see cref="JvmAttributeReaderBase"/> instances.
    /// </summary>
    public interface IJvmAttributeReaderFacade
    {
        /// <summary>
        /// Gets or sets the attribute factory for a given attribute <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        JvmAttributeReaderBase this[string name]
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a <see cref="JvmAttribute"/>.
        /// </summary>
        /// <returns>The parsed <see cref="JvmAttribute"/>.</returns>
        JvmAttribute Create();
    }
}