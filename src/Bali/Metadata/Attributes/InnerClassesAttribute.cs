using System;
using System.Collections.Generic;
using System.IO;
using Bali.IO;

namespace Bali.Metadata.Attributes
{
    public sealed class InnerClassesAttribute : Attribute
    {
        public InnerClassesAttribute(ushort nameIndex, IReadOnlyList<InnerClassInfo> innerClasses)
            : base(nameIndex)
        {
            InnerClasses = innerClasses;
        }

        public IReadOnlyList<InnerClassInfo> InnerClasses
        {
            get;
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
                    stream.ReadU2(), stream.ReadU2(), stream.ReadU2(), (AccessFlags) stream.ReadU2());
            }

            return new InnerClassesAttribute(nameIndex, buffer);
        }
    }

    public readonly struct InnerClassInfo
    {
        public InnerClassInfo(
            ushort innerClassIndex, ushort outerClassIndex, ushort innerNameIndex, AccessFlags innerAccessFlags)
        {
            InnerClassIndex = innerClassIndex;
            OuterClassIndex = outerClassIndex;
            InnerNameIndex = innerNameIndex;
            InnerAccessFlags = innerAccessFlags;
        }

        public ushort InnerClassIndex
        {
            get;
        }

        public ushort OuterClassIndex
        {
            get;
        }

        public ushort InnerNameIndex
        {
            get;
        }

        public AccessFlags InnerAccessFlags
        {
            get;
        }
    }
}