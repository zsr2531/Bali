using System.IO;
using Bali.IO;
using Bali.Metadata.Attributes;

namespace Bali.Metadata.Factories
{
    public class ConstantValueAttributeFactory : JvmAttributeFactoryBase
    {
        /// <inheritdoc />
        public ConstantValueAttributeFactory(IJvmAttributeFactoryFacade attributeFactoryFacade)
            : base(attributeFactoryFacade) { }

        /// <inheritdoc />
        public override string Name => "ConstantValue";

        /// <inheritdoc />
        public override JvmAttribute Create(Stream stream, ushort nameIndex) =>
            new ConstantValueAttribute(nameIndex, stream.ReadU2());
    }
}