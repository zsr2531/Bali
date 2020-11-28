﻿using System;
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
        private readonly Stream _stream;
        private readonly ConstantPool _constantPool;
        private readonly Dictionary<string, JvmAttributeFactoryBase> _concreteFactories;

        private static readonly DefaultJvmAttributeFactory DefaultJvmAttributeFactory = new();

        /// <summary>
        /// Creates a new <see cref="JvmAttributeFactoryFacade"/>.
        /// </summary>
        /// <param name="stream">The input <see cref="Stream"/> to read data from.</param>
        /// <param name="constantPool">The <see cref="ConstantPool"/>.</param>
        public JvmAttributeFactoryFacade(Stream stream, in ConstantPool constantPool)
        {
            _stream = stream;
            _constantPool = constantPool;
            _concreteFactories = new Dictionary<string, JvmAttributeFactoryBase>
            {
                ["Code"] = new CodeAttributeFactory(this),
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
            set
            {
                if (name != value.Name)
                    throw new ArgumentException(nameof(name));
                
                _concreteFactories[name] = value;
            }
        }

        /// <inheritdoc />
        public JvmAttribute Create()
        {
            ushort nameIndex = _stream.ReadU2();
            string name = GetName(nameIndex);

            return this[name].Create(_stream, nameIndex);
        }

        private string GetName(ushort nameIndex)
        {
            var constant = _constantPool[nameIndex];
            if (constant is not Utf8Constant { Value: { } name })
                throw new ArgumentException(nameof(nameIndex));

            return name;
        }
    }
}