namespace Bali.Constants
{
    /// <summary>
    /// Represents a <c>double</c> constant in the <see cref="ConstantPool"/>.
    /// </summary>
    public class DoubleConstant : Constant
    {
        /// <summary>
        /// Creates a new <see cref="DoubleConstant"/>.
        /// </summary>
        /// <param name="value">The value of the constant.</param>
        public DoubleConstant(double value)
            : base(ConstantKind.Double)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the value of the constant.
        /// </summary>
        public double Value
        {
            get;
            set;
        }
    }
}