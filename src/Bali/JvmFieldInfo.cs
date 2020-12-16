using System.Collections.Generic;
using Bali.Attributes;

namespace Bali
{
    /// <summary>
    /// Represents a raw field extracted from a class file.
    /// </summary>
    public struct JvmFieldInfo
    {
        /// <summary>
        /// Creates a new <see cref="JvmFieldInfo"/>.
        /// </summary>
        /// <param name="accessFlags">The see <see cref="FieldAccessFlags"/>.</param>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the field.</param>
        /// <param name="descriptorIndex">The index into the <see cref="ConstantPool"/> representing the type of the field.</param>
        /// <param name="attributes">All of the field's attributes.</param>
        public JvmFieldInfo(FieldAccessFlags accessFlags, ushort nameIndex, ushort descriptorIndex, IList<JvmAttribute> attributes)
        {
            AccessFlags = accessFlags;
            NameIndex = nameIndex;
            DescriptorIndex = descriptorIndex;
            Attributes = attributes;
        }

        /// <summary>
        /// Gets the <see cref="FieldAccessFlags"/>.
        /// </summary>
        public FieldAccessFlags AccessFlags
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the index into the <see cref="ConstantPool"/> representing the name of the field.
        /// </summary>
        public ushort NameIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the index into the <see cref="ConstantPool"/> representing the type of the field.
        /// </summary>
        public ushort DescriptorIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets all of the field's attributes.
        /// </summary>
        public IList<JvmAttribute> Attributes
        {
            get;
            set;
        }
    }
}