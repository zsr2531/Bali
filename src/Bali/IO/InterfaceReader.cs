using System;
using System.Collections.Generic;
using System.IO;

namespace Bali.IO
{
    /// <summary>
    /// Reads the indices of superinterfaces of a current class.
    /// </summary>
    public readonly struct InterfaceReader
    {
        private readonly Stream? _inputStream;
        private readonly ushort _count;

        /// <summary>
        /// Creates a new <see cref="InterfaceReader"/>.
        /// </summary>
        /// <param name="inputStream">The input <see cref="Stream"/> to read data from.</param>
        /// <param name="count">The number of indices to read.</param>
        public InterfaceReader(Stream inputStream, ushort count)
        {
            _inputStream = inputStream;
            _count = count;
        }

        /// <summary>
        /// Reads the interface indices.
        /// </summary>
        /// <returns>A list of indices into the <see cref="ConstantPool"/> describing superinterfaces of the current class.</returns>
        /// <exception cref="ArgumentException">When no input <see cref="Stream"/> is provided.</exception>
        public IList<ushort> ReadInterfaceIndices()
        {
            if (_inputStream is null)
                throw new ArgumentException("No input stream provided.");
            
            var interfaceIndices = new List<ushort>();

            for (int i = 0; i < _count; i++)
                interfaceIndices.Add(_inputStream.ReadU2());

            return interfaceIndices;
        }
    }
}