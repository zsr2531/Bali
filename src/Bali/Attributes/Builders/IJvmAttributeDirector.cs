namespace Bali.Attributes.Builders
{
    /// <summary>
    /// Provides a contract for keeping track of <see cref="IJvmAttributeBuilder"/> instances.
    /// </summary>
    public interface IJvmAttributeDirector
    {
        /// <summary>
        /// Gets or sets the <see cref="IJvmAttributeBuilder"/> for the given attribute <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        IJvmAttributeBuilder this[string name]
        {
            get;
            set;
        }

        /// <summary>
        /// Writes the <paramref name="attribute"/>.
        /// </summary>
        /// <param name="attribute">The <see cref="JvmAttribute"/> to write.</param>
        void ConstructAttribute(JvmAttribute attribute);
    }
}