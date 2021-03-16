using System;
using System.Buffers.Binary;

namespace Bali.IO
{
    /// <summary>
    /// Provides an implementation of the <see cref="IBigEndianReader"/> contract.
    /// </summary>
    public class BigEndianReader : IBigEndianReader
    {
        private readonly IDataSource _data;

        /// <summary>
        /// Creates a new <see cref="BigEndianReader"/>.
        /// </summary>
        /// <param name="data">The <see cref="IDataSource"/> to read data from.</param>
        public BigEndianReader(IDataSource data)
        {
            _data = data;
        }

        /// <inheritdoc />
        public long Position => _data.Position;

        /// <inheritdoc />
        public void Read(Span<byte> span) => _data.Read(span);

        /// <inheritdoc />
        public byte ReadU1() => _data.Read();

        /// <inheritdoc />
        public sbyte ReadI1() => (sbyte) _data.Read();

        /// <inheritdoc />
        public ushort ReadU2()
        {
            Span<byte> span = stackalloc byte[2];
            _data.Read(span);
            return BinaryPrimitives.ReadUInt16BigEndian(span);
        }

        /// <inheritdoc />
        public short ReadI2()
        {
            Span<byte> span = stackalloc byte[2];
            _data.Read(span);
            return BinaryPrimitives.ReadInt16BigEndian(span);
        }

        /// <inheritdoc />
        public uint ReadU4()
        {
            Span<byte> span = stackalloc byte[4];
            _data.Read(span);
            return BinaryPrimitives.ReadUInt32BigEndian(span);
        }

        /// <inheritdoc />
        public int ReadI4()
        {
            Span<byte> span = stackalloc byte[4];
            _data.Read(span);
            return BinaryPrimitives.ReadInt32BigEndian(span);
        }

        /// <inheritdoc />
        public ulong ReadU8()
        {
            Span<byte> span = stackalloc byte[8];
            _data.Read(span);
            return BinaryPrimitives.ReadUInt64BigEndian(span);
        }

        /// <inheritdoc />
        public long ReadI8()
        {
            Span<byte> span = stackalloc byte[8];
            _data.Read(span);
            return BinaryPrimitives.ReadInt64BigEndian(span);
        }

        /// <inheritdoc />
        public unsafe float ReadR4()
        {
            uint raw = ReadU4();
            return *(float*) &raw;
        }

        /// <inheritdoc />
        public unsafe double ReadR8()
        {
            ulong raw = ReadU8();
            return *(double*) &raw;
        }
    }
}