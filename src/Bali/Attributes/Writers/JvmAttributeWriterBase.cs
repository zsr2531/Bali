using Bali.IO;

namespace Bali.Attributes.Writers
{
    /// <summary>
    /// Provides base functionality to help implement the <see cref="IJvmAttributeWriter"/> contract.
    /// </summary>
    /// <typeparam name="T">The type of the attribute to build.</typeparam>
    public abstract class JvmAttributeWriterBase<T> : IJvmAttributeWriter
        where T : JvmAttribute
    {
        /// <summary>
        /// Initializes the underlying <see cref="Director"/>.
        /// </summary>
        /// <param name="director">The underlying <see cref="IJvmAttributeDirector"/>.</param>
        protected JvmAttributeWriterBase(IJvmAttributeDirector director)
        {
            Director = director;
        }

        /// <inheritdoc />
        public abstract string Name
        {
            get;
        }

        /// <summary>
        /// Gets the underlying <see cref="IJvmAttributeDirector"/> which can build other types of attributes.
        /// </summary>
        protected IJvmAttributeDirector Director
        {
            get;
        }

        /// <inheritdoc />
        public void WriteName(JvmAttribute attribute, IBigEndianWriter writer) => writer.WriteU2(attribute.NameIndex);

        /// <inheritdoc />
        public void WriteBody(JvmAttribute attribute, IBigEndianWriter writer) => WriteBody((T) attribute, (IBigEndianSegmentWriter) writer);

        /// <inheritdoc cref="WriteBody(T, IBigEndianWriter)" />
        protected abstract void WriteBody(T attribute, IBigEndianWriter writer);
    }
}