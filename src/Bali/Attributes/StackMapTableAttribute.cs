using System.Collections.Generic;

namespace Bali.Attributes
{
    /// <summary>
    /// An attribute which provides rich type information about the bytecode which is used for verification.
    /// </summary>
    public sealed class StackMapTableAttribute : JvmAttribute
    {
        /// <summary>
        /// Creates a new <see cref="StackMapTableAttribute"/>.
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the attribute.</param>
        /// <param name="entries">The <see cref="StackMapFrame"/>s.</param>
        public StackMapTableAttribute(ushort nameIndex, IList<StackMapFrame> entries)
            : base(nameIndex)
        {
            Entries = entries;
        }
        
        /// <summary>
        /// Gets the <see cref="StackMapFrame"/>s.
        /// </summary>
        public IList<StackMapFrame> Entries
        {
            get;
            set;
        }
    }
}