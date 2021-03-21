using System;
using System.IO;

namespace Bali.IO
{
    /// <summary>
    /// Provides an implementation for the <see cref="IDataSource"/> contract which can read data from a <see cref="Stream"/>.
    /// </summary>
    public sealed class StreamDataSource : IDataSource
    {
        private readonly Stream _stream;
        private readonly bool _disposeStream;

        /// <summary>
        /// Creates a new <see cref="StreamDataSource"/>.
        /// </summary>
        /// <param name="stream">The specified input <see cref="Stream"/>.</param>
        /// <param name="disposeStream">Whether to also dispose the <paramref name="stream"/> when the data source is disposed.</param>
        public StreamDataSource(Stream stream, bool disposeStream = false)
        {
            _stream = stream;
            _disposeStream = disposeStream;
        }

        /// <inheritdoc />
        public int Position => (int) _stream.Position;

        /// <inheritdoc />
        public byte Read()
        {
            int value = _stream.ReadByte();
            if (value == -1)
                throw new InvalidOperationException();

            return (byte) value;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            if (_disposeStream)
                _stream.Dispose();
        }
    }
}