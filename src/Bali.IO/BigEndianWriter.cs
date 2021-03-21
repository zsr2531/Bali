using System;
using System.Buffers.Binary;

namespace Bali.IO
{
    /// <summary>
    /// Provides an implementation of the <see cref="IBigEndianWriter"/> contract.
    /// </summary>
    public class BigEndianWriter : IBigEndianWriter
    {
        internal readonly IDataDestination Data;

        /// <summary>
        /// Creates a new <see cref="BigEndianWriter"/>.
        /// </summary>
        /// <param name="data">The <see cref="IDataDestination"/> to write data to.</param>
        public BigEndianWriter(IDataDestination data)
        {
            Data = data;
        }

        /// <inheritdoc />
        public long Position => Data.Position;

        /// <inheritdoc />
        public IBigEndianSegmentWriter WithU2Length() => new BigEndianSegmentWriter(this, true);

        /// <inheritdoc />
        public IBigEndianSegmentWriter WithU4Length() => new BigEndianSegmentWriter(this, false);

        /// <inheritdoc />
        public void Write(Span<byte> span) => Data.Write(span);

        /// <inheritdoc />
        public void WriteU1(byte value) => Data.Write(value);

        /// <inheritdoc />
        public void WriteI1(sbyte value) => Data.Write((byte) value);

        /// <inheritdoc />
        public void WriteU2(ushort value)
        {
            Span<byte> span = stackalloc byte[2];
            BinaryPrimitives.WriteUInt16BigEndian(span, value);
            Data.Write(span);
        }

        /// <inheritdoc />
        public void WriteI2(short value)
        {
            Span<byte> span = stackalloc byte[2];
            BinaryPrimitives.WriteInt16BigEndian(span, value);
            Data.Write(span);
        }

        /// <inheritdoc />
        public void WriteU4(uint value)
        {
            Span<byte> span = stackalloc byte[4];
            BinaryPrimitives.WriteUInt32BigEndian(span, value);
            Data.Write(span);
        }

        /// <inheritdoc />
        public void WriteI4(int value)
        {
            Span<byte> span = stackalloc byte[4];
            BinaryPrimitives.WriteInt32BigEndian(span, value);
            Data.Write(span);
        }

        /// <inheritdoc />
        public void WriteU8(ulong value)
        {
            Span<byte> span = stackalloc byte[8];
            BinaryPrimitives.WriteUInt64BigEndian(span, value);
            Data.Write(span);
        }

        /// <inheritdoc />
        public void WriteI8(long value)
        {
            Span<byte> span = stackalloc byte[8];
            BinaryPrimitives.WriteInt64BigEndian(span, value);
            Data.Write(span);
        }

        /// <inheritdoc />
        public unsafe void WriteR4(float value) => WriteU4(*(uint*) &value);

        /// <inheritdoc />
        public unsafe void WriteR8(double value) => WriteU8(*(ulong*) &value);
    }
}