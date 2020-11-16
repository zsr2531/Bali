using System.IO;

namespace Bali.IO.Constants
{
    /// <summary>
    /// Represents a constant string value.
    /// </summary>
    public class Utf8Constant : Constant
    {
        /// <summary>
        /// Creates a new <see cref="Utf8Constant"/>.
        /// </summary>
        /// <param name="value">The value of the constant.</param>
        public Utf8Constant(string value)
            : base(ConstantKind.Utf8) => Value = value;

        /// <summary>
        /// Gets or sets the value of the constant.
        /// </summary>
        public string Value
        {
            get;
            set;
        }

        /// <summary>
        /// Parses a <see cref="Utf8Constant"/> from the given input <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The input <see cref="Stream"/> to read data from.</param>
        /// <returns>The parsed <see cref="Utf8Constant"/>.</returns>
        public static Utf8Constant Create(Stream stream)
        {
            ushort length = stream.ReadU2();
            return new Utf8Constant(JavaUtf8.Decode(stream, length));
        }
    }
}