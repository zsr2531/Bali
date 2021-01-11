using System;
using System.Collections.Generic;
using System.IO;
using Bali.Constants;

namespace Bali.IO
{
    /// <summary>
    /// Parses the <see cref="ConstantPool"/> from the given input <see cref="Stream"/>.
    /// </summary>
    public readonly struct ConstantPoolReader
    {
        private readonly Stream? _stream;
        private readonly ushort _count;

        /// <summary>
        /// Creates a new <see cref="ConstantPoolReader"/>.
        /// </summary>
        /// <param name="stream">The input <see cref="Stream"/> to read data from.</param>
        /// <param name="count">The number of constants to read.</param>
        public ConstantPoolReader(Stream stream, ushort count)
        {
            _stream = stream;
            _count = count;
        }

        /// <summary>
        /// Reads the <see cref="ConstantPool"/>.
        /// </summary>
        /// <returns>The <see cref="ConstantPool"/> from the input <see cref="Stream"/>.</returns>
        public ConstantPool ReadConstantPool()
        {
            if (_stream is null)
                throw new ArgumentException("No input stream was provided.");
            
            var constants = new List<Constant>();

            for (int i = 0; i < _count;)
            {
                var constant = ConstantFactory.CreateConstant(_stream);

                i += constant switch
                {
                    LongConstant or DoubleConstant => 2,
                    _ => 1
                };
            }

            return new ConstantPool(constants);
        }
    }
}