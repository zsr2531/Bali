using System.IO;

namespace Bali.IO.Constants
{
    /// <summary>
    /// Represents a field or a method, without indicating which class or interface it belongs to.
    /// </summary>
    public class NameAndTypeConstant : Constant
    {
        /// <summary>
        /// Creates a new <see cref="NameAndTypeConstant"/>.
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> to a <see cref="Utf8Constant"/> holding the name of the field or method.</param>
        /// <param name="descriptorIndex">The index into the <see cref="ConstantPool"/> to a <see cref="Utf8Constant"/> holding the descriptor of the field or method.</param>
        public NameAndTypeConstant(ushort nameIndex, ushort descriptorIndex)
            : base(ConstantKind.NameAndType)
        {
            NameIndex = nameIndex;
            DescriptorIndex = descriptorIndex;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> to a <see cref="Utf8Constant"/> holding the name of the field or method.
        /// </summary>
        public ushort NameIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> to a <see cref="Utf8Constant"/> holding the descriptor of the field or method.
        /// </summary>
        public ushort DescriptorIndex
        {
            get;
            set;
        }
        
        /// <summary>
        /// Parses a <see cref="NameAndTypeConstant"/> from the given input <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The input <see cref="Stream"/> to read data from.</param>
        /// <returns>The parsed <see cref="NameAndTypeConstant"/>.</returns>
        public static NameAndTypeConstant Create(Stream stream) =>
            new(stream.ReadU2(), stream.ReadU2());
    }
}