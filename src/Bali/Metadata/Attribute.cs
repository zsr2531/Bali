using System;

namespace Bali.Metadata
{
    /// <summary>
    /// Represents a raw attribute extracted from the class file.
    /// </summary>
    public class Attribute
    {
        /// <summary>
        /// Creates a new <see cref="Attribute"/>.
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the attribute.</param>
        /// <param name="data">The raw data of the attribute.</param>
        public Attribute(ushort nameIndex, byte[] data)
            : this(nameIndex)
        {
            Data = data;
        }

        /// <summary>
        /// Creates a new <see cref="Attribute"/>.
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the attribute.</param>
        protected Attribute(ushort nameIndex)
        {
            NameIndex = nameIndex;
            Data = Array.Empty<byte>();
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
        public virtual byte[] Data
        {
            get;
        }
    }
}