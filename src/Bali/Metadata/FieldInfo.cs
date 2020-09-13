using System.Collections.Generic;

namespace Bali.Metadata
{
    /// <summary>
    /// Represents a raw field extracted from a class file.
    /// </summary>
    public readonly struct FieldInfo
    {
        /// <summary>
        /// Creates a new <see cref="FieldInfo"/>.
        /// </summary>
        /// <param name="flags">The see <see cref="AccessFlags"/>.</param>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the field.</param>
        /// <param name="descriptorIndex">The index into the <see cref="ConstantPool"/> representing the type of the field.</param>
        /// <param name="attributes">All of the field's attributes.</param>
        public FieldInfo(AccessFlags flags, ushort nameIndex, ushort descriptorIndex, IReadOnlyList<Attribute> attributes)
        {
            Flags = flags;
            NameIndex = nameIndex;
            DescriptorIndex = descriptorIndex;
            Attributes = attributes;
        }

        /// <summary>
        /// Gets the <see cref="AccessFlags"/>.
        /// </summary>
        public AccessFlags Flags
        {
            get;
        }

        /// <summary>
        /// Gets the index into the <see cref="ConstantPool"/> representing the name of the field.
        /// </summary>
        public ushort NameIndex
        {
            get;
        }

        /// <summary>
        /// Gets the index into the <see cref="ConstantPool"/> representing the type of the field.
        /// </summary>
        public ushort DescriptorIndex
        {
            get;
        }

        /// <summary>
        /// Gets all of the field's attributes.
        /// </summary>
        public IReadOnlyList<Attribute> Attributes
        {
            get;
        }
    }
}