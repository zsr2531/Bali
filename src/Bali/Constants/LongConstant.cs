namespace Bali.Constants
{
    /// <summary>
    /// Represents a <c>long</c> constant in the <see cref="ConstantPool"/>.
    /// </summary>
    public class LongConstant : Constant
    {
        /// <summary>
        /// Creates a new <see cref="LongConstant"/>.
        /// </summary>
        /// <param name="value">The value of the constant.</param>
        public LongConstant(long value)
            : base(ConstantKind.Long)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the value of the constant.
        /// </summary>
        public long Value
        {
            get;
            set;
        }
    }
}