using System;
using System.IO;

namespace Bali.IO
{
    /// <summary>
    /// Reads the magic value, the major- and the minor version from the given <see cref="Stream"/>.
    /// </summary>
    public readonly struct ClassFileHeaderReader
    {
        private readonly Stream? _inputStream;

        /// <summary>
        /// Creates a new <see cref="ClassFileHeaderReader"/>.
        /// </summary>
        /// <param name="inputStream">The input <see cref="Stream"/> to read data from.</param>
        public ClassFileHeaderReader(Stream inputStream) => _inputStream = inputStream;

        /// <summary>
        /// Parses the <see cref="ClassFileHeader"/> from the input <see cref="Stream"/>.
        /// </summary>
        /// <param name="allowMagicMismatch">Allow that magic value isn't <b>0xCAFEBABE</b>.</param>
        /// <returns>The <see cref="ClassFileHeader"/> holding the magic value, the major- and minor versions.</returns>
        /// <exception cref="ArgumentException">When the input <see cref="Stream"/> is <i>null</i>.</exception>
        /// <exception cref="InvalidMagicException">When the magic value isn't <b>0xCAFEBABE</b>.</exception>
        public ClassFileHeader ReadHeader(bool allowMagicMismatch = false)
        {
            if (_inputStream is null)
                throw new ArgumentException("No input stream was provided.");
            
            uint magic = _inputStream.ReadU4();
            
            if (!allowMagicMismatch && magic != 0xCAFEBABE)
                throw new InvalidMagicException();

            ushort minor = _inputStream.ReadU2();
            ushort major = _inputStream.ReadU2();

            return new ClassFileHeader(magic, minor, major);
        }
    }
}