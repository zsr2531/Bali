using System.Collections.Generic;
using Bali.SourceGeneration;

namespace Bali.Metadata.Attributes
{
    [AutoFactory]
    [AutoBuilder]
    public sealed class InnerClassesAttribute : JvmAttribute
    {
        public InnerClassesAttribute(ushort nameIndex, IList<InnerClassInfo> innerClasses)
            : base(nameIndex)
        {
            InnerClasses = innerClasses;
        }

        public IList<InnerClassInfo> InnerClasses
        {
            get;
            set;
        }
    }

    public struct InnerClassInfo
    {
        public InnerClassInfo(
            ushort innerClassIndex, ushort outerClassIndex, ushort innerNameIndex, ClassAccessFlags innerAccessFlags)
        {
            InnerClassIndex = innerClassIndex;
            OuterClassIndex = outerClassIndex;
            InnerNameIndex = innerNameIndex;
            InnerAccessFlags = innerAccessFlags;
        }

        public ushort InnerClassIndex
        {
            get;
            set;
        }

        public ushort OuterClassIndex
        {
            get;
            set;
        }

        public ushort InnerNameIndex
        {
            get;
            set;
        }

        public ClassAccessFlags InnerAccessFlags
        {
            get;
            set;
        }
    }
}