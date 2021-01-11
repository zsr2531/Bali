using System.IO;
using Bali.IO;

namespace Bali.Constants
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
            : base(ConstantKind.Utf8)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the value of the constant.
        /// </summary>
        public string Value
        {
            get;
            set;
        }
    }
}