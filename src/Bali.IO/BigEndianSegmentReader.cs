using System;

namespace Bali.IO
{
    internal sealed class BigEndianSegmentReader : IBigEndianSegmentReader
    {
        private readonly IBigEndianReader _source;
        private readonly uint _length;
        private readonly long _startPosition;

        internal BigEndianSegmentReader(IBigEndianReader source, uint length)
        {
            _source = source;
            _length = length;
            _startPosition = source.Position;
        }

        /// <inheritdoc />
        public long Position => _source.Position;

        /// <inheritdoc />
        public IBigEndianSegmentReader WithU2Length(ushort length) => new BigEndianSegmentReader(this, length);

        /// <inheritdoc />
        public IBigEndianSegmentReader WithU4Length(uint length) => new BigEndianSegmentReader(this, length);

        /// <inheritdoc />
        public void Read(Span<byte> span) => AssertNoOverrun().Read(span);

        /// <inheritdoc />
        public byte ReadU1() => AssertNoOverrun().ReadU1();

        /// <inheritdoc />
        public sbyte ReadI1() => AssertNoOverrun().ReadI1();

        /// <inheritdoc />
        public ushort ReadU2() => AssertNoOverrun().ReadU2();

        /// <inheritdoc />
        public short ReadI2() => AssertNoOverrun().ReadI2();

        /// <inheritdoc />
        public uint ReadU4() => AssertNoOverrun().ReadU4();

        /// <inheritdoc />
        public int ReadI4() => AssertNoOverrun().ReadI4();

        /// <inheritdoc />
        public ulong ReadU8() => AssertNoOverrun().ReadU8();
        
        /// <inheritdoc />
        public long ReadI8() => AssertNoOverrun().ReadI8();

        /// <inheritdoc />
        public float ReadR4() => AssertNoOverrun().ReadR4();

        /// <inheritdoc />
        public double ReadR8() => AssertNoOverrun().ReadR8();

        /// <inheritdoc />
        public void Dispose()
        {
            AssertNoOverrun();
            long remaining = GetRemainingBytes();
            for (long i = 0; i < remaining; i++)
                _source.ReadU1();
        }

        private long GetRemainingBytes() => _startPosition + _length - _source.Position;

        private IBigEndianReader AssertNoOverrun()
        {
            if (GetRemainingBytes() >= 0)
                return _source;

            throw new InvalidOperationException("Exceeded the number of bytes to read.");
        }
    }
}