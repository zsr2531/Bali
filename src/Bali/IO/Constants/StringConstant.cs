using System.IO;

namespace Bali.IO.Constants
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
            : base(ConstantKind.String) => StringIndex = stringIndex;

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> to a <see cref="Utf8Constant"/> holding the value of the string.
        /// </summary>
        public ushort StringIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Parses a <see cref="StringConstant"/> from the given input <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The input <see cref="Stream"/> to read data from.</param>
        /// <returns>The parsed <see cref="StringConstant"/>.</returns>
        public static StringConstant Create(Stream stream) => new StringConstant(stream.ReadU2());
    }
}