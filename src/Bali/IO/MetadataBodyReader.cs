using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Bali.Metadata;
using Bali.Metadata.Factories;

namespace Bali.IO
{
    /// <summary>
    /// Reads the interface indices, fields, methods and attributes from a given <see cref="Stream"/>.
    /// </summary>
    public readonly struct MetadataBodyReader
    {
        private readonly Stream? _inputStream;
        private readonly IJvmAttributeFactoryFacade? _attributeFactory;

        /// <summary>
        /// Creates a new <see cref="MetadataBodyReader"/>.
        /// </summary>
        /// <param name="inputStream">The input <see cref="Stream"/> to read data from.</param>
        /// <param name="constantPool">The <see cref="ConstantPool"/> to resolve constant pool indices with.</param>
        public MetadataBodyReader(Stream inputStream, in ConstantPool constantPool)
        {
            _inputStream = inputStream;
            _attributeFactory = new JvmAttributeFactoryFacade(inputStream, constantPool);
        }

        /// <summary>
        /// Parses the <see cref="MetadataBody"/> from the input <see cref="Stream"/>.
        /// </summary>
        /// <returns>The parsed <see cref="MetadataBody"/>.</returns>
        /// <exception cref="ArgumentException">When the input <see cref="Stream"/> is <i>null</i>.</exception>
        public MetadataBody ReadMetadataBody()
        {
            if (_inputStream is null)
                throw new ArgumentException("No input stream was provided.");

            ushort interfacesCount = _inputStream.ReadU2();
            var interfaces = new List<ushort>(interfacesCount);

            for (int i = 0; i < interfacesCount; i++)
                interfaces.Add(_inputStream.ReadU2());

            var fields = ReadInfo<JvmFieldInfo, FieldAccessFlags>((f, n, d, a) => new JvmFieldInfo(f, n, d, a));
            var methods = ReadInfo<JvmMethodInfo, MethodAccessFlags>((f, n, d, a) => new JvmMethodInfo(f, n, d, a));
            var attributes = ReadAttributes();
            
            return new MetadataBody(interfaces, fields, methods, attributes);
        }

        private IList<TType> ReadInfo<TType, TFlags>(Func<TFlags, ushort, ushort, IList<JvmAttribute>, TType> factory)
        {
            ushort count = _inputStream!.ReadU2();
            if (count == 0)
                return new List<TType>();

            var buffer = new List<TType>(count);
            for (int i = 0; i < count; i++)
            {
                ushort rawFlags = _inputStream!.ReadU2();
                var flags = Unsafe.As<ushort, TFlags>(ref rawFlags);
                ushort nameIndex = _inputStream!.ReadU2();
                ushort descriptorIndex = _inputStream!.ReadU2();
                var attributes = ReadAttributes();
                buffer.Add(factory(flags, nameIndex, descriptorIndex, attributes));
            }

            return buffer;
        }

        private IList<JvmAttribute> ReadAttributes()
        {
            ushort attributesCount = _inputStream!.ReadU2();
            if (attributesCount == 0)
                return new List<JvmAttribute>();
            
            var attributes = new List<JvmAttribute>(attributesCount);
            for (int i = 0; i < attributesCount; i++)
                attributes.Add(_attributeFactory!.Create());

            return attributes;
        }
    }
}
