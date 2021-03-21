namespace Bali.Attributes.Readers
{
    /// <summary>
    /// Provides a contract for keeping track of <see cref="JvmAttributeReaderBase"/> instances.
    /// </summary>
    public interface IJvmAttributeReaderFacade
    {
        /// <summary>
        /// Gets or sets the <see cref="IJvmAttributeReader"/> for a given attribute <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        IJvmAttributeReader this[string name]
        {
            get;
            set;
        }

        /// <summary>
        /// Reads a <see cref="JvmAttribute"/>.
        /// </summary>
        /// <returns>The parsed <see cref="JvmAttribute"/>.</returns>
        JvmAttribute ReadAttribute();
    }
}