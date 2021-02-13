namespace Bali.Constants
{
    /// <summary>
    /// Represents a class or interface name/descriptor in the <see cref="ConstantPool"/>.
    /// </summary>
    public class ClassConstant : Constant
    {
        /// <summary>
        /// Creates a new <see cref="ClassConstant"/>.
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> to a <see cref="Utf8Constant"/>.</param>
        public ClassConstant(ushort nameIndex)
            : base(ConstantKind.Class)
        {
            NameIndex = nameIndex;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> to a <see cref="Utf8Constant"/> holding either the
        /// internal form of a class' name or in the case of some opcodes like <c>anewarray</c>, a type descriptor.
        /// </summary>
        public ushort NameIndex
        {
            get;
            set;
        }
    }
}