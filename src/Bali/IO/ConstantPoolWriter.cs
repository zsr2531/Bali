using System;
using System.IO;
using System.Linq;
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

        public void Write()
        {
            if (_pool is null)
                throw new ArgumentException("pool");
            if (_stream is null)
                throw new ArgumentException("stream");

            int count = _pool.Aggregate(0, (acc, curr) => acc + (curr is LongConstant or DoubleConstant ? 2 : 1));
            _stream.WriteU2((ushort) count);

            foreach (var constant in _pool)
            {
            }
        }
    }
}