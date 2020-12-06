using System;
using System.IO;
using Bali.IO;

namespace Bali.Metadata.Builders
{
    public sealed class DefaultJvmAttributeBuilder : IJvmAttributeBuilder
    {
        /// <inheritdoc />
        public string Name => throw new NotSupportedException();

        /// <inheritdoc />
        public void WriteName(Stream stream, JvmAttribute attribute) => stream.WriteU2(attribute.NameIndex);

        /// <inheritdoc />
        public void WriteBody(Stream stream, JvmAttribute attribute)
        {
            if (attribute.Data is null)
                throw new ArgumentOutOfRangeException(nameof(attribute));
                
            stream.Write(attribute.Data, 0, attribute.Data.Length);
        }
    }
}