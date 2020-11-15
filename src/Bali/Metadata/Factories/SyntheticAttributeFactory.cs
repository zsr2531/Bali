using System.IO;
using Bali.Metadata.Attributes;

namespace Bali.Metadata.Factories
{
    public class SyntheticAttributeFactory : JvmAttributeFactoryBase
    {
        /// <inheritdoc />
        public SyntheticAttributeFactory(IJvmAttributeFactoryFacade attributeFactoryFacade)
            : base(attributeFactoryFacade) { }

        /// <inheritdoc />
        public override string Name => "Synthetic";

        /// <inheritdoc />
        public override JvmAttribute Create(Stream stream, ushort nameIndex) =>
            new SyntheticAttribute(nameIndex);
    }
}