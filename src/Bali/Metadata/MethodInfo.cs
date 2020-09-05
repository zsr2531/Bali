using System.Collections.Generic;

namespace Bali.Metadata
{
    /// <summary>
    /// Represents a raw method extracted from a class file.
    /// </summary>
    public readonly struct MethodInfo
    {
        /// <summary>
        /// Creates a new <see cref="MethodInfo"/>.
        /// </summary>
        /// <param name="accessFlags">The <see cref="AccessFlags"/>.</param>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the method.</param>
        /// <param name="descriptorIndex">The index into the <see cref="ConstantPool"/> representing the signature of the method.</param>
        /// <param name="attributes">All of the method's attributes.</param>
        public MethodInfo(AccessFlags accessFlags, ushort nameIndex, ushort descriptorIndex, IReadOnlyList<AttributeInfo> attributes)
        {
            AccessFlags = accessFlags;
            NameIndex = nameIndex;
            DescriptorIndex = descriptorIndex;
            Attributes = attributes;
        }

        /// <summary>
        /// Gets the <see cref="AccessFlags"/>.
        /// </summary>
        public AccessFlags AccessFlags
        {
            get;
        }

        /// <summary>
        /// Gets the index into the <see cref="ConstantPool"/> representing the name of the method.
        /// </summary>
        public ushort NameIndex
        {
            get;
        }

        /// <summary>
        /// Gets the index into the <see cref="ConstantPool"/> representing the signature of the method.
        /// </summary>
        public ushort DescriptorIndex
        {
            get;
        }

        /// <summary>
        /// Gets all of the method's signatures.
        /// </summary>
        public IReadOnlyList<AttributeInfo> Attributes
        {
            get;
        }
    }
}