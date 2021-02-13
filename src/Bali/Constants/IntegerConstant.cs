namespace Bali.Constants
{
    /// <summary>
    /// Represents an <c>int</c> constant in the <see cref="ConstantPool"/>.
    /// </summary>
    public class IntegerConstant : Constant
    {
        /// <summary>
        /// Creates a new <see cref="IntegerConstant"/>.
        /// </summary>
        /// <param name="value">The value of the constant.</param>
        public IntegerConstant(int value)
            : base(ConstantKind.Integer)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the value of the constant.
        /// </summary>
        public int Value
        {
            get;
            set;
        }
    }
}