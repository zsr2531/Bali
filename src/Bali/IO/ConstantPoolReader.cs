using System;
using System.Collections.Generic;
using System.IO;
using Bali.IO.Constants;

namespace Bali.IO
{
    public class ConstantPoolReader
    {
        private readonly Stream _inputStream;
        
        private static readonly Dictionary<ConstantKind, Func<Stream, Constant>> ConstantFactories;

        public ConstantPoolReader(Stream inputStream) => _inputStream = inputStream;

        static ConstantPoolReader()
        {
            ConstantFactories = new Dictionary<ConstantKind, Func<Stream, Constant>>
            {
                [ConstantKind.String] = StringConstant.Create,
                [ConstantKind.Utf8] = Utf8Constant.Create,
                [ConstantKind.Class] = ClassConstant.Create,
                [ConstantKind.Fieldref] = FieldrefConstant.Create,
                [ConstantKind.Integer] = IntegerConstant.Create,
                [ConstantKind.Methodref] = MethodrefConstant.Create,
                [ConstantKind.Long] = LongConstant.Create,
                [ConstantKind.NameAndType] = NameAndTypeConstant.Create,
                [ConstantKind.InterfaceMethodref] = InterfaceMethodrefConstant.Create
            };
        }

        public ConstantPool ReadConstantPool()
        {
            var constants = new List<Constant>();
            ushort count = (ushort) (_inputStream.ReadU2() - 1);

            for (int i = 0; i < count;)
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

            return new ConstantPool(constants);
        }
    }
}