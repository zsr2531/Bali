namespace Bali.Constants
{
    /// <summary>
    /// Represents a constant object of type <c>String</c>.
    /// </summary>
    public class StringConstant : Constant
    {
        /// <summary>
        /// Creates a new <see cref="StringConstant"/>.
        /// </summary>
        /// <param name="stringIndex">The index into the <see cref="ConstantPool"/> to a <see cref="Utf8Constant"/> holding the value of the string.</param>
        public StringConstant(ushort stringIndex)
            : base(ConstantKind.String)
        {
            StringIndex = stringIndex;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> to a <see cref="Utf8Constant"/> holding the value of the string.
        /// </summary>
        public ushort StringIndex
        {
            get;
            set;
        }
    }
}