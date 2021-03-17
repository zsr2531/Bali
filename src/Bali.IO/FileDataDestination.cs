using System.IO;

namespace Bali.IO
{
    /// <summary>
    /// Provides an implementation for the <see cref="IDataDestination"/> contract which can write data to a file.
    /// </summary>
    public sealed class FileDataDestination : IDataDestination
    {
        private readonly FileStream _stream;

        /// <summary>
        /// Creates a new <see cref="FileDataDestination"/>.
        /// </summary>
        /// <param name="path">The path to the file to write data to.</param>
        public FileDataDestination(string path)
        {
            _stream = File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None);
        }

        /// <inheritdoc />
        public long Position => _stream.Position;

        /// <inheritdoc />
        public void Write(byte value) => _stream.WriteByte(value);

        /// <inheritdoc />
        public void Dispose() => _stream.Dispose();
    }
}