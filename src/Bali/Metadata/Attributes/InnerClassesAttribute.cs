using System;
using System.Collections.Generic;
using System.IO;
using Bali.IO;

namespace Bali.Metadata.Attributes
{
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

        public static InnerClassesAttribute Create(Stream stream, ushort nameIndex)
        {
            ushort count = stream.ReadU2();
            var buffer = count == 0
                ? Array.Empty<InnerClassInfo>()
                : new InnerClassInfo[count];

            for (int i = 0; i < count; i++)
            {
                buffer[i] = new InnerClassInfo(
                    stream.ReadU2(), stream.ReadU2(), stream.ReadU2(), (ClassAccessFlags) stream.ReadU2());
            }

            return new InnerClassesAttribute(nameIndex, buffer);
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