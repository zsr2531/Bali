namespace Bali.Constants
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
    }
}