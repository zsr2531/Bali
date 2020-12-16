using System.IO;
using Bali.IO;

namespace Bali.Metadata.Builders
{
    /// <summary>
    /// Provides base functionality to help implement the <see cref="IJvmAttributeBuilder"/> contract.
    /// </summary>
    /// <typeparam name="T">The type of the attribute to build.</typeparam>
    public abstract class JvmAttributeBuilderBase<T> : IJvmAttributeBuilder
        where T : JvmAttribute
    {
        /// <summary>
        /// Initializes the underlying <see cref="Director"/>.
        /// </summary>
        /// <param name="director">The underlying <see cref="IJvmAttributeDirector"/>.</param>
        protected JvmAttributeBuilderBase(IJvmAttributeDirector director)
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
        public void WriteName(Stream stream, JvmAttribute attribute) => stream.WriteU2(attribute.NameIndex);

        /// <inheritdoc />
        public void WriteBody(Stream stream, JvmAttribute attribute) => WriteBody(stream, (T) attribute);

        /// <inheritdoc cref="JvmAttributeBuilderBase{T}.WriteBody(Stream,JvmAttribute)" />
        protected abstract void WriteBody(Stream stream, T attribute);
    }
}