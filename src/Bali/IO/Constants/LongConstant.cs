using System.IO;

namespace Bali.IO.Constants
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
            : base(ConstantKind.Long) => Value = value;
        
        /// <summary>
        /// Gets or sets the value of the constant.
        /// </summary>
        public long Value
        {
            get;
            set;
        }
        
        /// <summary>
        /// Parses a <see cref="LongConstant"/> from the given input <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The input <see cref="Stream"/> to read data from.</param>
        /// <returns>The parsed <see cref="LongConstant"/>.</returns>
        public static LongConstant Create(Stream stream) => new((long) stream.ReadU8());
    }
}