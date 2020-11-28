namespace Bali.Metadata
{
    /// <summary>
    /// Represents a raw attribute extracted from the class file.
    /// </summary>
    public class JvmAttribute
    {
        internal readonly byte[]? Data;

        /// <summary>
        /// Creates a new <see cref="JvmAttribute"/>.
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the attribute.</param>
        /// <param name="data">The raw data of the attribute.</param>
        public JvmAttribute(ushort nameIndex, byte[] data)
            : this(nameIndex)
        {
            Data = data;
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
    }
}