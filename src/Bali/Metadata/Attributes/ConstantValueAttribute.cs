﻿using Bali.SourceGeneration;

namespace Bali.Metadata.Attributes
{
    [AutoBuilder]
    public sealed class ConstantValueAttribute : JvmAttribute
    {
        public ConstantValueAttribute(ushort nameIndex, ushort constantValueIndex) : base(nameIndex) =>
            ConstantValueIndex = constantValueIndex;

        public ushort ConstantValueIndex
        {
            get;
            set;
        }
    }
}