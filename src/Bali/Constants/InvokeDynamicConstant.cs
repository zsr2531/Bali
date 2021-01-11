namespace Bali.Constants
{
    /// <summary>
    /// Represents the operand of a <c>invokedynamic</c> instruction, that specifies the dynamic invocation name,
    /// the argument and return types of the call, and optionally, a sequence of additional constants called
    /// static arguments to the bootstrap method.
    /// </summary>
    public class InvokeDynamicConstant : Constant
    {
        /// <summary>
        /// Creates a new <see cref="InvokeDynamicConstant"/>.
        /// </summary>
        /// <param name="bootstrapMethodAttributeIndex">The index into the bootstrap method table of this <see cref="ClassFile"/>.</param>
        /// <param name="nameAndTypeIndex">Index into the <see cref="ConstantPool"/> to a <see cref="NameAndTypeConstant"/> that indicates the name and the descriptor of the method.</param>
        public InvokeDynamicConstant(ushort bootstrapMethodAttributeIndex, ushort nameAndTypeIndex)
            : base(ConstantKind.InvokeDynamic)
        {
            BootstrapMethodAttributeIndex = bootstrapMethodAttributeIndex;
            NameAndTypeIndex = nameAndTypeIndex;
        }

        /// <summary>
        /// Gets or sets the index into the bootstrap method table of this <see cref="ClassFile"/>.
        /// </summary>
        public ushort BootstrapMethodAttributeIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> to a <see cref="NameAndTypeConstant"/> that indicates the name and the descriptor of the method.
        /// </summary>
        public ushort NameAndTypeIndex
        {
            get;
            set;
        }
    }
}