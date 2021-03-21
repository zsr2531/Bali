using Bali.IO;

namespace Bali.Attributes.Writers
{
    /// <summary>
    /// Provides a contract for a writer that can serialize a specific type of <see cref="JvmAttribute"/>.
    /// </summary>
    public interface IJvmAttributeWriter
    {
        /// <summary>
        /// Gets the name of the attribute that this class can serialize.
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Writes the name index to the output <paramref name="writer"/>.
        /// </summary>
        /// <param name="attribute">The <see cref="JvmAttribute"/> to write the name index of to the output <paramref name="writer"/>.</param>
        /// <param name="writer">The <see cref="IBigEndianWriter"/> to write data to.</param>
        void WriteName(JvmAttribute attribute, IBigEndianWriter writer);

        /// <summary>
        /// Writes the contents of the <see cref="JvmAttribute"/> to the output <paramref name="writer"/>.
        /// </summary>
        /// <param name="attribute">The <see cref="JvmAttribute"/> to write the contents of to the output <paramref name="writer"/>.</param>
        /// <param name="writer">The <see cref="IBigEndianWriter"/> to write data to.</param>
        void WriteBody(JvmAttribute attribute, IBigEndianWriter writer);
    }
}