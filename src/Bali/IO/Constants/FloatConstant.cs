using System.IO;

namespace Bali.IO.Constants
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
            : base(ConstantKind.Float) => Value = value;

        /// <summary>
        /// Gets or sets the value of the constant.
        /// </summary>
        public float Value
        {
            get;
            set;
        }

        /// <summary>
        /// Parses a <see cref="FloatConstant"/> from the given input <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The input <see cref="Stream"/> to read data from.</param>
        /// <returns>The parsed <see cref="FloatConstant"/>.</returns>
        public static unsafe FloatConstant Create(Stream stream)
        {
            uint bits = stream.ReadU4();
            return new FloatConstant(*(float*)&bits);
        }
    }
}