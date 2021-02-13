using System;
using System.IO;
using Bali.Constants;

namespace Bali.IO
{
    public readonly struct ConstantPoolWriter
    {
        private readonly ConstantPool? _pool;
        private readonly Stream? _stream;

        public ConstantPoolWriter(ConstantPool pool, Stream stream)
        {
            _pool = pool;
            _stream = stream;
        }

        public void WriteConstantPool()
        {
            if (_pool is null)
                throw new ArgumentException("pool");
            if (_stream is null)
                throw new ArgumentException("stream");

            _stream.WriteU2((ushort) (_pool.Count + 1));

            for (int i = 1; i < _pool.Count + 1; i++)
            {
                var current = _pool[i];
                if (current is LongConstant or DoubleConstant)
                    i++;
                
                ConstantBuilder.BuildConstant(current, _stream);
            }
        }
    }
}