using System.Collections.Generic;
using Bali.Constants;
using Bali.IO;

namespace Bali
{
    internal readonly ref struct ConstantPoolReader
    {
        private readonly IBigEndianReader _reader;
        private readonly ushort _count;

        internal ConstantPoolReader(IBigEndianReader reader, ushort count)
        {
            _reader = reader;
            _count = count;
        }

        internal ConstantPool ReadConstantPool()
        {
            var constants = new List<Constant>();

            for (int i = 0; i < _count; i++)
            {
                var constant = ConstantReader.CreateConstant(_reader);
                constants.Add(constant);
                if (constant is LongConstant or DoubleConstant)
                {
                    constants.Add(constant); // Longs and doubles take up 2 slots... urgh
                    i++;
                }
            }

            return new ConstantPool(constants);
        }
    }
}