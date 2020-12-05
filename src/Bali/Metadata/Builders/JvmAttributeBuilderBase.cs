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
        public void BuildName(Stream stream, JvmAttribute attribute) => stream.WriteU2(attribute.NameIndex);

        /// <inheritdoc />
        public void BuildBody(Stream stream, JvmAttribute attribute) => BuildBody(stream, (T) attribute);

        /// <inheritdoc cref="BuildBody" />
        protected abstract void BuildBody(Stream stream, T attribute);
    }
}