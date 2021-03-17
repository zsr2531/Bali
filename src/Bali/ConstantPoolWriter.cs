using System.Diagnostics;
using Bali.Constants;
using Bali.IO;

namespace Bali
{
    internal readonly ref struct ConstantPoolWriter
    {
        private readonly ConstantPool _pool;
        private readonly IBigEndianWriter _writer;

        internal ConstantPoolWriter(ConstantPool pool, IBigEndianWriter writer)
        {
            _pool = pool;
            _writer = writer;
        }

        internal void WriteConstantPool()
        {
            _writer.WriteU2((ushort) (_pool.Count + 1));

            for (int i = 1; i < _pool.Count + 1; i++)
            {
                var current = _pool[i];
                // TODO: Fix nasty bug, `i` isn't incremented in Release mode!
                if (current is LongConstant or DoubleConstant)
                    Debug.Assert(current == _pool[++i], "Long and double constants should take up 2 slots.");

                ConstantWriter.BuildConstant(current, _writer);
            }
        }
    }
}