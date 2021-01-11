namespace Bali.Constants
{
    /// <summary>
    /// Represents a <c>float</c> constant in the <see cref="ConstantPool"/>.
    /// </summary>
    public class FloatConstant : Constant
    {
        /// <summary>
        /// Creates a new <see cref="FloatConstant"/>.
        /// </summary>
        /// <param name="value">The value of the constant.</param>
        public FloatConstant(float value)
            : base(ConstantKind.Float)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the value of the constant.
        /// </summary>
        public float Value
        {
            get;
            set;
        }
    }
}