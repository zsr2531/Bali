using System.IO;
using Bali.Constants;

namespace Bali.Attributes.Readers
{
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
        /// Reads a <see cref="JvmAttribute"/> from the <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The input <see cref="Stream"/> to read data from.</param>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> to a <see cref="Utf8Constant"/> holding the name.</param>
        /// <returns>The parsed <see cref="JvmAttribute"/>.</returns>
        JvmAttribute Read(Stream stream, ushort nameIndex);
    }
}