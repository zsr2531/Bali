using System;

namespace Bali.IO
{
    /// <summary>
    /// Provides an implementation for the <see cref="IDataSource"/> contract which can read data from a <see cref="byte"/> buffer.
    /// </summary>
    public sealed class BufferDataSource : IDataSource
    {
        private readonly ReadOnlyMemory<byte> _data;

        /// <summary>
        /// Creates a new <see cref="BufferDataSource"/>.
        /// </summary>
        /// <param name="data">The <see cref="byte"/>[] to read data from.</param>
        public BufferDataSource(ReadOnlyMemory<byte> data)
        {
            _data = data;
        }

        /// <inheritdoc />
        public int Position
        {
            get;
            private set;
        }

        /// <inheritdoc />
        public byte Read()
        {
            if (Position >= _data.Length)
                throw new InvalidOperationException("End of input.");

            return _data.Span[Position++];
        }

        /// <inheritdoc />
        public void Dispose()
        {
        }
    }
}