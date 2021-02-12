namespace Bali.Constants
{
    /// <summary>
    /// Represents a field in the <see cref="ClassFile"/>.
    /// </summary>
    public class FieldrefConstant : Constant
    {
        /// <summary>
        /// Creates a new <see cref="FieldrefConstant"/>.
        /// </summary>
        /// <param name="classIndex">The index into the <see cref="ConstantPool"/> to a <see cref="ClassConstant"/> that this field is a member of.</param>
        /// <param name="nameAndTypeIndex">The index into the <see cref="ConstantPool"/> to a <see cref="NameAndTypeConstant"/> that indicates the name and the descriptor of this field.</param>
        public FieldrefConstant(ushort classIndex, ushort nameAndTypeIndex)
            : base(ConstantKind.Fieldref)
        {
            ClassIndex = classIndex;
            NameAndTypeIndex = nameAndTypeIndex;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> to a <see cref="ClassConstant"/> that this field is a member of.
        /// </summary>
        public ushort ClassIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> to a <see cref="NameAndTypeConstant"/> that indicates the name and the descriptor of this field.
        /// </summary>
        public ushort NameAndTypeIndex
        {
            get;
            set;
        }
    }
}