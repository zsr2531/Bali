using System;
using Bali.IO;

namespace Bali.Attributes.Readers
{
    /// <summary>
    /// Provides a default implementation of the <see cref="JvmAttributeReaderBase"/> contract.
    /// </summary>
    public sealed class DefaultJvmAttributeReader : JvmAttributeReaderBase
    {
        /// <inheritdoc />
        public DefaultJvmAttributeReader()
            : base(null!) { }

        /// <inheritdoc />
        public override string Name => throw new NotSupportedException();

        /// <inheritdoc />
        public override JvmAttribute Read(IBigEndianReader reader, ushort nameIndex, uint length) =>
            new(nameIndex, ReadRawData(reader, length));

        private static byte[] ReadRawData(IBigEndianReader reader, uint length)
        {
            if (length == 0)
                return Array.Empty<byte>();

            byte[] buffer = new byte[length];
            reader.Read(buffer);

            return buffer;
        }
    }
}