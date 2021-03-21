using System;
using System.Buffers;

namespace Bali.IO
{
    /// <summary>
    /// Provides an implementation for the <see cref="IDataDestination"/> contract which can write data to a <see cref="byte"/> buffer.
    /// </summary>
    public sealed class BufferDataDestination : IDataDestination
    {
        private static readonly ArrayPool<byte> Pool = ArrayPool<byte>.Create();

        private byte[] _buffer = Pool.Rent(512);
        
        /// <summary>
        /// Gets the underlying buffer.
        /// </summary>
        public ReadOnlySpan<byte> Buffer => _buffer.AsSpan().Slice(0, Position);

        /// <inheritdoc />
        public int Position
        {
            get;
            private set;
        }
        
        /// <inheritdoc />
        public void Write(byte value)
        {
            if (Position >= _buffer.Length)
                Array.Resize(ref _buffer, _buffer.Length * 2);

            _buffer[Position++] = value;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Pool.Return(_buffer, true);
        }
    }
}