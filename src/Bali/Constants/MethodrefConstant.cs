namespace Bali.Constants
{
    /// <summary>
    /// Represents a method in the <see cref="ClassFile"/>.
    /// </summary>
    public class MethodrefConstant : Constant
    {
        /// <summary>
        /// Creates a new <see cref="MethodrefConstant"/>.
        /// </summary>
        /// <param name="classIndex"></param>
        /// <param name="nameAndTypeIndex"></param>
        public MethodrefConstant(ushort classIndex, ushort nameAndTypeIndex)
            : base(ConstantKind.Methodref)
        {
            ClassIndex = classIndex;
            NameAndTypeIndex = nameAndTypeIndex;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> to a <see cref="ClassConstant"/> that this method is a member of.
        /// </summary>
        public ushort ClassIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> to a <see cref="NameAndTypeConstant"/> that indicates the name and the descriptor of this method.
        /// </summary>
        public ushort NameAndTypeIndex
        {
            get;
            set;
        }
    }
}
