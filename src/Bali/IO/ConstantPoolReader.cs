using System;
using System.Collections.Generic;
using System.IO;
using Bali.IO.Constants;

namespace Bali.IO
{
    /// <summary>
    /// Parses the <see cref="ConstantPool"/> from the given input <see cref="Stream"/>.
    /// </summary>
    public readonly struct ConstantPoolReader
    {
        private readonly Stream? _inputStream;
        private readonly ushort _count;
        
        private static readonly Dictionary<ConstantKind, Func<Stream, Constant>> ConstantFactories;

        /// <summary>
        /// Creates a new <see cref="ConstantPoolReader"/>.
        /// </summary>
        /// <param name="inputStream">The input <see cref="Stream"/> to read data from.</param>
        /// <param name="count">The number of constants to read.</param>
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

        /// <summary>
        /// Reads the <see cref="ConstantPool"/>.
        /// </summary>
        /// <returns>The <see cref="ConstantPool"/> from the input <see cref="Stream"/>.</returns>
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