namespace Bali.Constants
{
    /// <summary>
    /// Represents a method type.
    /// </summary>
    public class MethodTypeConstant : Constant
    {
        /// <summary>
        /// Creates a new <see cref="MethodTypeConstant"/>.
        /// </summary>
        /// <param name="descriptorIndex">The index into the <see cref="ConstantPool"/> to a <see cref="Utf8Constant"/> holding the descriptor of the method.</param>
        public MethodTypeConstant(ushort descriptorIndex)
            : base(ConstantKind.MethodType)
        {
            DescriptorIndex = descriptorIndex;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> to a <see cref="Utf8Constant"/> holding the descriptor of the method.
        /// </summary>
        public ushort DescriptorIndex
        {
            get;
            set;
        }
    }
}