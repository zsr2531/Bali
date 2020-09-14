﻿using System.IO;
using Bali.IO;

namespace Bali.Metadata.Attributes
{
    public sealed class ConstantValueAttribute : Attribute
    {
        public ConstantValueAttribute(ushort nameIndex, ushort constantValueIndex) : base(nameIndex) =>
            ConstantValueIndex = constantValueIndex;

        public ushort ConstantValueIndex
        {
            get;
        }

        /// <inheritdoc />
        public override byte[] Data =>
            new[] { (byte) ((ConstantValueIndex >> 8) & 0xFF), (byte) (ConstantValueIndex & 0xFF) };
        
        public static ConstantValueAttribute Create(Stream stream, ushort nameIndex) =>
            new ConstantValueAttribute(nameIndex, stream.ReadU2());
    }
}