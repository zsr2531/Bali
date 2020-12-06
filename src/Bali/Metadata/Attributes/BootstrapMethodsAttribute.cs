using System.Collections.Generic;
using Bali.SourceGeneration;

namespace Bali.Metadata.Attributes
{
    [AutoFactory]
    [AutoBuilder]
    public sealed class BootstrapMethodsAttribute : JvmAttribute
    {
        public BootstrapMethodsAttribute(ushort nameIndex, IList<BootstrapInfo> bootstrapMethods)
            : base(nameIndex)
        {
            BootstrapMethods = bootstrapMethods;
        }

        public IList<BootstrapInfo> BootstrapMethods
        {
            get;
            set;
        }
    }

    public struct BootstrapInfo
    {
        public BootstrapInfo(ushort bootstrapMethodIndex, IList<ushort> bootstrapMethodArgumentIndices)
        {
            BootstrapMethodIndex = bootstrapMethodIndex;
            BootstrapMethodArgumentIndices = bootstrapMethodArgumentIndices;
        }

        public ushort BootstrapMethodIndex
        {
            get;
            set;
        }

        public IList<ushort> BootstrapMethodArgumentIndices
        {
            get;
            set;
        }
    }
}