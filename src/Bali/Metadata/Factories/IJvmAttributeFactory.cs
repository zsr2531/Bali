using System.IO;
using Bali.IO.Constants;

namespace Bali.Metadata.Factories
{
    public interface IJvmAttributeFactory
    {
        /// <summary>
        /// Creates a <see cref="JvmAttribute"/> from the <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The input <see cref="Stream"/> to read data from.</param>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> to a <see cref="Utf8Constant"/> holding the name.</param>
        /// <returns>The parsed <see cref="JvmAttribute"/>.</returns>
        JvmAttribute Create(Stream stream, ushort nameIndex);
    }
}