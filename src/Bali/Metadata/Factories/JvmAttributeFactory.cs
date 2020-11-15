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

        private static readonly DefaultJvmAttributeFactory _defaultJvmAttributeFactory =
            new DefaultJvmAttributeFactory();

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
            get
            {
                if (_concreteFactories.TryGetValue(name, out var value))
                    return value;

                return _defaultJvmAttributeFactory;
            }
            set => _concreteFactories[name] = value;
        }

        /// <inheritdoc />
        public JvmAttribute Create(Stream stream)
        {
            ushort nameIndex = stream.ReadU2();
            var nameConstant = _constantPool[nameIndex];
            if (!(nameConstant is Utf8Constant { Value: {} name }))
                throw new ArgumentException(nameof(nameIndex));

            return this[name].Create(stream, nameIndex);
        }
    }
}