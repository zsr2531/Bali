using System.IO;
using Bali.IO.Constants;

namespace Bali.Metadata.Factories
{
    /// <summary>
    /// Provides a contract for a factory that can create a concrete <see cref="JvmAttribute"/> instance.
    /// </summary>
    public abstract class JvmAttributeFactoryBase
    {
        /// <summary>
        /// Initializes the <see cref="AttributeFactoryFacade"/>.
        /// </summary>
        /// <param name="attributeFactoryFacade">The attribute factory that can be used to create other types of attributes.</param>
        protected JvmAttributeFactoryBase(IJvmAttributeFactoryFacade attributeFactoryFacade)
        {
            AttributeFactoryFacade = attributeFactoryFacade;
        }

        /// <summary>
        /// Gets the attribute factory that can be used to create other types of attributes.
        /// </summary>
        protected IJvmAttributeFactoryFacade AttributeFactoryFacade
        {
            get;
        }

        /// <summary>
        /// Gets the name of the attribute that the factory creates instances of.
        /// </summary>
        public abstract string Name
        {
            get;
        }
        
        /// <summary>
        /// Reads a <see cref="JvmAttribute"/> from the <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The input <see cref="Stream"/> to read data from.</param>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> to a <see cref="Utf8Constant"/> holding the name.</param>
        /// <returns>The parsed <see cref="JvmAttribute"/>.</returns>
        public abstract JvmAttribute Read(Stream stream, ushort nameIndex);
    }
}