using System;
using System.IO;
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
        public override JvmAttribute Read(Stream stream, ushort nameIndex) =>
            new(nameIndex, ReadRawData(stream));

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