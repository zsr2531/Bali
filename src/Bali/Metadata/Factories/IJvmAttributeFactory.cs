using System.IO;

namespace Bali.Metadata.Factories
{
    public interface IJvmAttributeFactory
    {
        /// <summary>
        /// Creates a <see cref="JvmAttribute"/> from the <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The input <see cref="Stream"/> to read data from.</param>
        /// <returns>The parsed <see cref="JvmAttribute"/>.</returns>
        JvmAttribute Create(Stream stream);
    }
}