using System;
using System.IO;
using Bali.IO;

namespace Bali.Metadata
{
    /// <summary>
    /// Represents a raw attribute extracted from the class file.
    /// </summary>
    public class JvmAttribute
    {
        private readonly byte[]? _data;

        /// <summary>
        /// Creates a new <see cref="JvmAttribute"/>.
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the attribute.</param>
        /// <param name="data">The raw data of the attribute.</param>
        public JvmAttribute(ushort nameIndex, byte[] data)
            : this(nameIndex)
        {
            _data = data;
        }

        /// <summary>
        /// Creates a new <see cref="JvmAttribute"/>.
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the attribute.</param>
        protected JvmAttribute(ushort nameIndex)
        {
            NameIndex = nameIndex;
        }

        /// <summary>
        /// Gets the index into the <see cref="ConstantPool"/> representing the name of the attribute.
        /// </summary>
        public ushort NameIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the raw data of the attribute.
        /// </summary>
        public byte[] GetData()
        {
            using var ms = Serialize();
            return ms.ToArray();
        }

        /// <summary>
        /// Writes the raw byte representation of the attribute to the <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The output <see cref="Stream"/> to write data to.</param>
        public void WriteTo(Stream stream)
        {
            using var ms = Serialize();
            
            stream.WriteU2(NameIndex);
            stream.WriteU4((uint) ms.Length);
            ms.WriteTo(stream);
        }

        /// <summary>
        /// Serializes the attribute into a <see cref="MemoryStream"/>.
        /// </summary>
        /// <returns>The serialized attribute.</returns>
        protected virtual MemoryStream Serialize() => new(_data ?? Array.Empty<byte>());
    }
}