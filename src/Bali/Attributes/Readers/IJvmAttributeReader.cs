using Bali.Constants;
using Bali.IO;

namespace Bali.Attributes.Readers
{
    /// <summary>
    /// Provides a contract for a reader that can deserialize a specific type of <see cref="JvmAttribute"/>.
    /// </summary>
    public interface IJvmAttributeReader
    {
        /// <summary>
        /// Gets the name of the attribute that the factory creates instances of.
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Reads a <see cref="JvmAttribute"/> from the <paramref name="reader"/>.
        /// </summary>
        /// <param name="reader">The <see cref="IBigEndianReader"/> to read data from.</param>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> to a <see cref="Utf8Constant"/> holding the name.</param>
        /// <param name="length">The length of the attribute's body.</param>
        /// <returns>The parsed <see cref="JvmAttribute"/>.</returns>
        JvmAttribute Read(IBigEndianReader reader, ushort nameIndex, uint length);
    }
}