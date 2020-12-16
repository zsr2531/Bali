using System.IO;

namespace Bali.Metadata.Builders
{
    /// <summary>
    /// Provides a contract for a builder that can serialize a specific type of <see cref="JvmAttribute"/>.
    /// </summary>
    public interface IJvmAttributeBuilder
    {
        /// <summary>
        /// Gets the name of the attribute that this class can serialize.
        /// </summary>
        string Name
        {
            get;
        }
        
        /// <summary>
        /// Writes the name index to the output <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The output <see cref="Stream"/> to write data to.</param>
        /// <param name="attribute">The <see cref="JvmAttribute"/> to write the name index of to the output <paramref name="stream"/>.</param>
        void WriteName(Stream stream, JvmAttribute attribute);
        
        /// <summary>
        /// Writes the contents of the <see cref="JvmAttribute"/> to the output <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The output <see cref="Stream"/> to write data to.</param>
        /// <param name="attribute">The <see cref="JvmAttribute"/> to write the contents of to the output <paramref name="stream"/>.</param>
        void WriteBody(Stream stream, JvmAttribute attribute);
    }
}