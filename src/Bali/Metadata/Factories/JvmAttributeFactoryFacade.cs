using System;
using System.Collections.Generic;
using System.IO;
using Bali.IO;
using Bali.IO.Constants;

namespace Bali.Metadata.Factories
{
    /// <summary>
    /// Provides a basic implementation of the <see cref="IJvmAttributeFactoryFacade"/> contract with
    /// modularity in mind, so custom non-standard attributes can be processed if needed.
    /// </summary>
    public class JvmAttributeFactoryFacade : IJvmAttributeFactoryFacade
    {
        private readonly ConstantPool _constantPool;
        private readonly Dictionary<string, JvmAttributeFactoryBase> _concreteFactories;

        private static readonly DefaultJvmAttributeFactory DefaultJvmAttributeFactory =
            new DefaultJvmAttributeFactory();

        /// <summary>
        /// Creates a new <see cref="JvmAttributeFactoryFacade"/>.
        /// </summary>
        /// <param name="constantPool">The <see cref="ConstantPool"/>.</param>
        public JvmAttributeFactoryFacade(in ConstantPool constantPool)
        {
            _constantPool = constantPool;
            _concreteFactories = new Dictionary<string, JvmAttributeFactoryBase>
            {
                ["ConstantValue"] = new ConstantValueAttributeFactory(this),
                ["Synthetic"] = new SyntheticAttributeFactory(this)
            };
        }

        /// <inheritdoc />
        public JvmAttributeFactoryBase this[string name]
        {
            get => _concreteFactories.TryGetValue(name, out var value)
                ? value
                : DefaultJvmAttributeFactory;
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