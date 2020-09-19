using System;
namespace Bali.Metadata
{
    /// <summary>
    /// Represents a raw attribute extracted from the class file.
    /// </summary>
    public class Attribute
    {
        private readonly byte[]? _data;

        /// <summary>
        /// Creates a new <see cref="Attribute"/>.
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the attribute.</param>
        /// <param name="data">The raw data of the attribute.</param>
        public Attribute(ushort nameIndex, byte[] data)
            : this(nameIndex)
        {
            _data = data;
        }

        /// <summary>
        /// Creates a new <see cref="Attribute"/>.
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the attribute.</param>
        protected Attribute(ushort nameIndex)
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
        public virtual byte[] GetData() => _data ?? Array.Empty<byte>();
    }
}