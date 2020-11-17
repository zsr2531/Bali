using System.Collections.Generic;

namespace Bali.Metadata
{
    /// <summary>
    /// Represents a raw method extracted from a class file.
    /// </summary>
    public struct JvmMethodInfo
    {
        /// <summary>
        /// Creates a new <see cref="JvmMethodInfo"/>.
        /// </summary>
        /// <param name="accessFlags">The <see cref="MethodAccessFlags"/>.</param>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the method.</param>
        /// <param name="descriptorIndex">The index into the <see cref="ConstantPool"/> representing the signature of the method.</param>
        /// <param name="attributes">All of the method's attributes.</param>
        public JvmMethodInfo(MethodAccessFlags accessFlags, ushort nameIndex, ushort descriptorIndex, IList<JvmAttribute> attributes)
        {
            AccessFlags = accessFlags;
            NameIndex = nameIndex;
            DescriptorIndex = descriptorIndex;
            Attributes = attributes;
        }

        /// <summary>
        /// Gets or sets the <see cref="MethodAccessFlags"/>.
        /// </summary>
        public MethodAccessFlags AccessFlags
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> representing the name of the method.
        /// </summary>
        public ushort NameIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> representing the signature of the method.
        /// </summary>
        public ushort DescriptorIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets all of the method's attributes.
        /// </summary>
        public IList<JvmAttribute> Attributes
        {
            get;
        }
    }
}