using System;
using System.Collections.Generic;
using System.IO;
using Bali.IO.Constants;

namespace Bali.IO
{
    public readonly struct ConstantPoolReader
    {
        private readonly Stream? _inputStream;
        private readonly ushort _count;
        
        private static readonly Dictionary<ConstantKind, Func<Stream, Constant>> ConstantFactories;

        public ConstantPoolReader(Stream inputStream, ushort count)
        {
            _inputStream = inputStream;
            _count = count;
        }

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
                [ConstantKind.InterfaceMethodref] = InterfaceMethodrefConstant.Create,
                [ConstantKind.InvokeDynamic] = InvokeDynamicConstant.Create,
                [ConstantKind.MethodType] = MethodTypeConstant.Create,
                [ConstantKind.MethodHandle] = MethodHandleConstant.Create
            };
        }

        public ConstantPool ReadConstantPool()
        {
            if (_inputStream is null)
                throw new ArgumentException("No input stream was provided.");
            
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

            return new ConstantPool(constants);
        }
    }
}