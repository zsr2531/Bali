using System;
using System.IO;

namespace Bali.IO
{
    /// <summary>
    /// Reads the <see cref="ClassAccessFlags"/>, the <c>this</c> and <c>super</c> class indices.
    /// </summary>
    public readonly struct ClassFileBodyReader
    {
        private readonly Stream? _inputStream;

        /// <summary>
        /// Creates a new <see cref="ClassFileBodyReader"/>.
        /// </summary>
        /// <param name="inputStream">The input <see cref="Stream"/> to read data from.</param>
        public ClassFileBodyReader(Stream? inputStream) => _inputStream = inputStream;

        /// <summary>
        /// Parses the <see cref="ClassFileBody"/> from the input <see cref="Stream"/>.
        /// </summary>
        /// <returns>The <see cref="ClassFileBody"/> holding the <see cref="ClassAccessFlags"/>, the <c>this</c> and <c>super</c> class indices.</returns>
        /// <exception cref="ArgumentException">When the input <see cref="Stream"/> is <i>null</i>.</exception>
        public ClassFileBody ReadBody()
        {
            if (_inputStream is null)
                throw new ArgumentException("No input stream was provided.");

            var accessFlags = (ClassAccessFlags) _inputStream.ReadU2();
            ushort thisClass = _inputStream.ReadU2();
            ushort superClass = _inputStream.ReadU2();
            
            return new ClassFileBody(accessFlags, thisClass, superClass);
        }
    }
}