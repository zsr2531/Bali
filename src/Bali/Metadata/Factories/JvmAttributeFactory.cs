using System;
using System.Collections.Generic;
using System.IO;
using Bali.IO;
using Bali.IO.Constants;

namespace Bali.Metadata.Factories
{
    public class JvmAttributeFactory : IJvmAttributeFactory
    {
        private readonly ConstantPool _constantPool;
        private readonly Dictionary<string, ConcreteJvmAttributeFactoryBase> _concreteFactories;

        public JvmAttributeFactory(in ConstantPool constantPool)
        {
            _constantPool = constantPool;
            _concreteFactories = new Dictionary<string, ConcreteJvmAttributeFactoryBase>
            {
                ["ConstantValue"] = new ConstantValueAttributeFactory(this),
                ["Synthetic"] = new SyntheticAttributeFactory(this)
            };
        }
        
        public ConcreteJvmAttributeFactoryBase this[string name]
        {
            set => _concreteFactories[name] = value;
        }
        
        /// <inheritdoc />
        public JvmAttribute Create(Stream stream, ushort nameIndex)
        {
            var nameConstant = _constantPool[nameIndex];
            if (!(nameConstant is Utf8Constant { Value: {} name }))
                throw new ArgumentException(nameof(nameIndex));

            return _concreteFactories.TryGetValue(name, out var factory)
                ? factory.Create(stream, nameIndex)
                : new JvmAttribute(nameIndex, ReadRawData(stream));
        }

        private static byte[] ReadRawData(Stream stream)
        {
            uint length = stream.ReadU4();
            if (length == 0)
                return Array.Empty<byte>();

            var buffer = new byte[length];
            stream.Read(buffer, 0, (int) length);

            return buffer;
        }
    }
}