using System;
using Bali.IO;

namespace Bali.Attributes.Writers
{
    /// <summary>
    /// Provides a default implementation of the <see cref="IJvmAttributeWriter"/> contract.
    /// </summary>
    public sealed class DefaultJvmAttributeWriter : IJvmAttributeWriter
    {
        /// <inheritdoc />
        public string Name => throw new NotSupportedException();

        /// <inheritdoc />
        public void WriteName(JvmAttribute attribute, IBigEndianWriter writer) => writer.WriteU2(attribute.NameIndex);

        /// <inheritdoc />
        public void WriteBody(JvmAttribute attribute, IBigEndianWriter writer)
        {
            if (attribute.Data is null)
                throw new ArgumentException(nameof(attribute));
                
            writer.Write(attribute.Data);
        }
    }
}