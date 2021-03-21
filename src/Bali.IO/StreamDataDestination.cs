using System.IO;

namespace Bali.IO
{
    /// <summary>
    /// Provides an implementation for the <see cref="IDataDestination"/> contract which can write data to a <see cref="Stream"/>.
    /// </summary>
    public sealed class StreamDataDestination : IDataDestination
    {
        internal readonly Stream Stream;
        private readonly bool _disposeStream;

        /// <summary>
        /// Creates a new <see cref="StreamDataDestination"/>.
        /// </summary>
        /// <param name="stream">The specified output <see cref="Stream"/>.</param>
        /// <param name="disposeStream">Whether to also dispose the <paramref name="stream"/> when the data destination is disposed.</param>
        public StreamDataDestination(Stream stream, bool disposeStream = false)
        {
            Stream = stream;
            _disposeStream = disposeStream;
        }

        /// <inheritdoc />
        public int Position => (int) Stream.Position;

        /// <inheritdoc />
        public void Write(byte value) => Stream.WriteByte(value);

        /// <inheritdoc />
        public void Dispose()
        {
            if (_disposeStream)
                Stream.Dispose();
        }
    }
}