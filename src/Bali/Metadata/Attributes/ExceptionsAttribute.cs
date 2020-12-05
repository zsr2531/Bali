using System.Collections.Generic;
using Bali.SourceGeneration;

namespace Bali.Metadata.Attributes
{
    [AutoBuilder]
    public sealed class ExceptionsAttribute : JvmAttribute
    {
        public ExceptionsAttribute(ushort nameIndex, IList<ushort> exceptions) : base(nameIndex) =>
            Exceptions = exceptions;
        
        public IList<ushort> Exceptions
        {
            get;
            set;
        }
    }
}