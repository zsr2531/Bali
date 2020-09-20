using System.IO;

namespace Bali.IO.Constants
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
            : base(ConstantKind.Integer) => Value = value;

        /// <summary>
        /// Gets or sets the value of the constant.
        /// </summary>
        public int Value
        {
            get;
            set;
        }
        
        /// <summary>
        /// Parses a <see cref="IntegerConstant"/> from the given input <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The input <see cref="Stream"/> to read data from.</param>
        /// <returns>The parsed <see cref="IntegerConstant"/>.</returns>
        public static IntegerConstant Create(Stream stream) => new IntegerConstant((int) stream.ReadU4());
    }
}