using System;
using System.IO;

namespace Bali.IO
{
    internal sealed class BigEndianSegmentWriter : IBigEndianSegmentWriter
    {
        private readonly IBigEndianWriter _destination;
        private readonly bool _isU2;
        private readonly BigEndianWriter _segment;

        internal BigEndianSegmentWriter(IBigEndianWriter destination, bool isU2)
        {
            _destination = destination;
            _isU2 = isU2;
            
            var temporary = new StreamDataDestination(new MemoryStream(), true);
            _segment = new BigEndianWriter(temporary);
        }

        /// <inheritdoc />
        public long Position => _destination.Position + LengthBytes + _segment.Position;

        private int LengthBytes => _isU2 ? 2 : 4;

        /// <inheritdoc />
        public IBigEndianSegmentWriter WithU2Length() => new BigEndianSegmentWriter(this, true);

        /// <inheritdoc />
        public IBigEndianSegmentWriter WithU4Length() => new BigEndianSegmentWriter(this, false);

        /// <inheritdoc />
        public void Write(Span<byte> span) => _segment.Write(span);

        /// <inheritdoc />
        public void WriteU1(byte value) => _segment.WriteU1(value);

        /// <inheritdoc />
        public void WriteI1(sbyte value) => _segment.WriteI1(value);

        /// <inheritdoc />
        public void WriteU2(ushort value) => _segment.WriteU2(value);

        /// <inheritdoc />
        public void WriteI2(short value) => _segment.WriteI2(value);

        /// <inheritdoc />
        public void WriteU4(uint value) => _segment.WriteU4(value);

        /// <inheritdoc />
        public void WriteI4(int value) => _segment.WriteI4(value);

        /// <inheritdoc />
        public void WriteU8(ulong value) => _segment.WriteU8(value);

        /// <inheritdoc />
        public void WriteI8(long value) => _segment.WriteI8(value);

        /// <inheritdoc />
        public void WriteR4(float value) => _segment.WriteR4(value);

        /// <inheritdoc />
        public void WriteR8(double value) => _segment.WriteR8(value);

        /// <inheritdoc />
        public void Dispose()
        {
            var temporary = (StreamDataDestination) _segment.Data;
            var stream = temporary.Stream;
            long length = stream.Length;
            
            if (_isU2)
                _destination.WriteU2((ushort) length);
            else
                _destination.WriteU4((uint) length);
            
            stream.Seek(0, SeekOrigin.Begin);
            for (int i = 0; i < stream.Length; i++)
                _destination.WriteU1((byte) stream.ReadByte());
            
            temporary.Dispose();
        }
    }
}