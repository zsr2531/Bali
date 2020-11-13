using System.IO;
using Bali.IO.Constants;

namespace Bali.Metadata.Factories
{
    /// <summary>
    /// Provides a contract for a factory that can create a concrete <see cref="JvmAttribute"/> instance.
    /// </summary>
    public abstract class ConcreteJvmAttributeFactoryBase
    {
        /// <summary>
        /// Initializes the <see cref="AttributeFactory"/>.
        /// </summary>
        /// <param name="attributeFactory">The attribute factory that can be used to create other types of attributes.</param>
        protected ConcreteJvmAttributeFactoryBase(IJvmAttributeFactory attributeFactory)
        {
            AttributeFactory = attributeFactory;
        }

        /// <summary>
        /// Gets the attribute factory that can be used to create other types of attributes.
        /// </summary>
        protected IJvmAttributeFactory AttributeFactory
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
        /// Creates a <see cref="JvmAttribute"/> from the <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The input <see cref="Stream"/> to read data from.</param>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> to a <see cref="Utf8Constant"/> holding the name.</param>
        /// <returns>The parsed <see cref="JvmAttribute"/>.</returns>
        public abstract JvmAttribute Create(Stream stream, ushort nameIndex);
    }
}