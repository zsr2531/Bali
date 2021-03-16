using Bali.IO;

namespace Bali.Attributes.Writers
{
    /// <summary>
    /// Provides a contract for keeping track of <see cref="IJvmAttributeWriter"/> instances.
    /// </summary>
    public interface IJvmAttributeDirector
    {
        /// <summary>
        /// Gets or sets the <see cref="IJvmAttributeWriter"/> for the given attribute <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        IJvmAttributeWriter this[string name]
        {
            get;
            set;
        }

        /// <summary>
        /// Writes the <paramref name="attribute"/>.
        /// </summary>
        /// <param name="attribute">The <see cref="JvmAttribute"/> to write.</param>
        /// <param name="writer"></param>
        void WriteAttribute(JvmAttribute attribute, IBigEndianWriter writer);
    }
}