using System;
using System.IO;
using Bali.IO;

namespace Bali.Metadata.Factories
{
    /// <summary>
    /// Provides a default implementation of the <see cref="JvmAttributeFactoryBase"/> contract.
    /// </summary>
    public sealed class DefaultJvmAttributeFactory : JvmAttributeFactoryBase
    {
        /// <inheritdoc />
        public DefaultJvmAttributeFactory()
            : base(null!) { }

        /// <inheritdoc />
        public override string Name => throw new NotSupportedException();

        /// <inheritdoc />
        public override JvmAttribute Read(Stream stream, ushort nameIndex) =>
            new JvmAttribute(nameIndex, ReadRawData(stream));

        private static byte[] ReadRawData(Stream stream)
        {
            uint length = stream.ReadU4();
            if (length == 0)
                return Array.Empty<byte>();

            var buffer = new byte[length];
            stream.Read(buffer, 0, (int) length);

            return buffer;
        }
    }
}