using System;
using System.IO;

namespace Bali.IO
{
    /// <summary>
    /// Provides an implementation for the <see cref="IDataSource"/> contract which can read data from a file.
    /// </summary>
    public sealed class FileDataSource : IDataSource
    {
        private readonly FileStream _stream;

        /// <summary>
        /// Creates a new <see cref="FileDataSource"/>.
        /// </summary>
        /// <param name="path">The path to the file to read data from.</param>
        public FileDataSource(string path)
        {
            _stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None);
        }

        /// <inheritdoc />
        public long Position => _stream.Position;

        /// <inheritdoc />
        public byte Read()
        {
            int value = _stream.ReadByte();
            if (value == -1)
                throw new InvalidOperationException();

            return (byte) value;
        }

        /// <inheritdoc />
        public void Dispose() => _stream.Dispose();
    }
}