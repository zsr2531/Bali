using System;

namespace Bali.IO
{
    /// <summary>
    /// Provides an implementation for the <see cref="IDataDestination"/> contract which can write data to a <see cref="byte"/>[].
    /// </summary>
    public sealed class ByteArrayDataDestination : IDataDestination
    {
        private byte[] _buffer = new byte[512];
        
        /// <summary>
        /// Gets the underlying buffer.
        /// </summary>
        public byte[] Buffer => _buffer;

        /// <inheritdoc />
        public long Position
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
        }
    }
}