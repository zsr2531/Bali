using System.Collections.Generic;

namespace Bali.Attributes
{
    public sealed class StackMapTableAttribute : JvmAttribute
    {
        public StackMapTableAttribute(ushort nameIndex, IList<StackMapFrame> entries)
            : base(nameIndex)
        {
            Entries = entries;
        }
        
        public IList<StackMapFrame> Entries
        {
            get;
            set;
        }
    }
}