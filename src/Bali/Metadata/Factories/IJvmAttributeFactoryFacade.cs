using System.IO;

namespace Bali.Metadata.Factories
{
    /// <summary>
    /// Provides a contract for keeping track of <see cref="JvmAttributeFactoryBase"/> instances.
    /// </summary>
    public interface IJvmAttributeFactoryFacade
    {
        /// <summary>
        /// Gets or sets the attribute factory for a given attribute <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        JvmAttributeFactoryBase this[string name]
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a <see cref="JvmAttribute"/> from the <paramref name="stream"/>.
        /// </summary>
        /// <returns>The parsed <see cref="JvmAttribute"/>.</returns>
        JvmAttribute Create();
    }
}