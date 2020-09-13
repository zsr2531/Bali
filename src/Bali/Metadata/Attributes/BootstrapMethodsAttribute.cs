using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bali.IO;

namespace Bali.Metadata.Attributes
{
    public sealed class BootstrapMethodsAttribute : Attribute
    {
        public BootstrapMethodsAttribute(ushort nameIndex, IReadOnlyList<BootstrapInfo> bootstrapMethods)
            : base(nameIndex)
        {
            BootstrapMethods = bootstrapMethods;
        }

        public IReadOnlyList<BootstrapInfo> BootstrapMethods
        {
            get;
        }

        /// <inheritdoc />
        public override byte[] Data
        {
            get
            {
                var buffer = new byte[BootstrapMethods.Sum(info => info.Size)];
                var span = buffer.AsSpan();

                foreach (var info in BootstrapMethods)
                {
                    BinaryPrimitives.WriteUInt16BigEndian(span, info.BootstrapMethodIndex);

                    foreach (ushort index in info.BootstrapMethodArgumentIndices)
                    {
                        span = span.Slice(2);
                        BinaryPrimitives.WriteUInt16BigEndian(span, index);
                    }
                    
                    span = span.Slice(info.Size);
                }

                return buffer;
            }
        }

        public static BootstrapMethodsAttribute Create(Stream stream, ushort nameIndex)
        {
            ushort count = stream.ReadU2();
            var buffer = count == 0
                ? Array.Empty<BootstrapInfo>()
                : new BootstrapInfo[count];

            for (int i = 0; i < count; i++)
            {
                ushort index = stream.ReadU2();
                ushort argCount = stream.ReadU2();
                var argsBuffer = argCount == 0
                    ? Array.Empty<ushort>()
                    : new ushort[argCount];

                for (int j = 0; j < argCount; j++)
                    argsBuffer[j] = stream.ReadU2();
                
                buffer[i] = new BootstrapInfo(index, argsBuffer);
            }
            
            return new BootstrapMethodsAttribute(nameIndex, buffer);
        }
    }

    public readonly struct BootstrapInfo
    {
        public BootstrapInfo(ushort bootstrapMethodIndex, IReadOnlyList<ushort> bootstrapMethodArgumentIndices)
        {
            BootstrapMethodIndex = bootstrapMethodIndex;
            BootstrapMethodArgumentIndices = bootstrapMethodArgumentIndices;
        }

        public ushort BootstrapMethodIndex
        {
            get;
        }

        public IReadOnlyList<ushort> BootstrapMethodArgumentIndices
        {
            get;
        }

        internal int Size => (BootstrapMethodArgumentIndices.Count + 1) * 2;
    }
}