using System;
using System.Collections.Generic;
using System.IO;
using Bali.IO.Constants;

namespace Bali.IO
{
    public class ConstantPoolReader
    {
        private readonly Stream _inputStream;
        private readonly ushort _count;
        
        private static readonly Dictionary<ConstantKind, Func<Stream, Constant>> ConstantFactories;

        public ConstantPoolReader(Stream inputStream, ClassFileHeader classFileHeader)
        {
            _inputStream = inputStream;
            _count = (ushort) (classFileHeader.ConstantPoolCount - 1);
        }

        static ConstantPoolReader()
        {
            ConstantFactories = new Dictionary<ConstantKind, Func<Stream, Constant>>
            {
                [ConstantKind.String] = StringConstant.Create
            };
        }

        public IList<Constant> ReadConstantPool()
        {
            var constants = new List<Constant>();

            for (int i = 0; i < _count;)
            {
                var tag = (ConstantKind) _inputStream.ReadU1();
                constants.Add(ConstantFactories[tag](_inputStream));

                i += tag switch
                {
                    ConstantKind.Long => 2,
                    ConstantKind.Double => 2,
                    _ => 1
                };
            }

            return constants;
        }
    }
}