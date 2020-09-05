namespace Bali.Metadata
{
    /// <summary>
    /// Represents a raw attribute extracted from the class file.
    /// </summary>
    public readonly struct AttributeInfo
    {
        /// <summary>
        /// Creates a new <see cref="AttributeInfo"/>.
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the attribute.</param>
        /// <param name="data">The raw data of the attribute.</param>
        public AttributeInfo(ushort nameIndex, byte[] data)
        {
            NameIndex = nameIndex;
            Data = data;
        }

        /// <summary>
        /// Gets the index into the <see cref="ConstantPool"/> representing the name of the attribute.
        /// </summary>
        public ushort NameIndex
        {
            get;
        }

        /// <summary>
        /// Gets the raw data of the attribute.
        /// </summary>
        public byte[] Data
        {
            get;
        }
    }
}