using System.Collections.Generic;
using Bali.SourceGeneration;

namespace Bali.Metadata.Attributes
{
    /// <summary>
    /// An attribute which describes which checked exceptions a method may throw.
    /// </summary>
    [AutoFactory]
    [AutoBuilder]
    public sealed class ExceptionsAttribute : JvmAttribute
    {
        /// <summary>
        /// Creates a new <see cref="ExceptionsAttribute"/>.
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the attribute.</param>
        /// <param name="exceptions">The indices into the <see cref="ConstantPool"/> representing the class of the exceptions.</param>
        public ExceptionsAttribute(ushort nameIndex, IList<ushort> exceptions)
            : base(nameIndex)
        {
            Exceptions = exceptions;
        }

        /// <summary>
        /// Gets or sets the indices into the <see cref="ConstantPool"/> representing the class of the exceptions.
        /// </summary>
        public IList<ushort> Exceptions
        {
            get;
            set;
        }
    }
}