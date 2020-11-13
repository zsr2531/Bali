using System.IO;
using Bali.Metadata.Attributes;

namespace Bali.Metadata.Factories
{
    public class SyntheticAttributeFactory : ConcreteJvmAttributeFactoryBase
    {
        /// <inheritdoc />
        public SyntheticAttributeFactory(IJvmAttributeFactory attributeFactory)
            : base(attributeFactory) { }

        /// <inheritdoc />
        public override string Name => "Synthetic";

        /// <inheritdoc />
        public override JvmAttribute Create(Stream stream, ushort nameIndex) =>
            new SyntheticAttribute(nameIndex);
    }
}