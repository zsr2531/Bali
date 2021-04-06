using System.Collections.Generic;

namespace Bali.Attributes
{
    public sealed class StackMapTableAttribute : JvmAttribute
    {
        public StackMapTableAttribute(ushort nameIndex, IList<StackMapFrameBase> entries)
            : base(nameIndex)
        {
            Entries = entries;
        }
        
        public IList<StackMapFrameBase> Entries
        {
            get;
            set;
        }
    }
}