using System.IO;
using Bali.IO;

namespace Bali.Metadata.Builders
{
    public abstract class JvmAttributeBuilderBase<T> : IJvmAttributeBuilder
        where T : JvmAttribute
    {
        protected JvmAttributeBuilderBase(IJvmAttributeDirector director)
        {
            Director = director;
        }

        /// <inheritdoc />
        public abstract string Name
        {
            get;
        }

        protected IJvmAttributeDirector Director
        {
            get;
        }

        /// <inheritdoc />
        public void WriteName(Stream stream, JvmAttribute attribute) => stream.WriteU2(attribute.NameIndex);

        /// <inheritdoc />
        public void WriteBody(Stream stream, JvmAttribute attribute) => WriteBody(stream, (T) attribute);

        /// <inheritdoc cref="WriteBody" />
        protected abstract void WriteBody(Stream stream, T attribute);
    }
}