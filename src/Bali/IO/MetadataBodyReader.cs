using System;
using System.Collections.Generic;
using System.IO;
using Bali.Metadata;
using Bali.Metadata.Factories;

namespace Bali.IO
{
    public readonly struct MetadataBodyReader
    {
        private readonly Stream? _inputStream;
        private readonly IJvmAttributeFactoryFacade? _attributeFactory;

        public MetadataBodyReader(Stream inputStream, in ConstantPool constantPool)
        {
            _inputStream = inputStream;
            _attributeFactory = new JvmAttributeFactoryFacade(constantPool);
        }

        public MetadataBody ReadMetadataBody()
        {
            if (_inputStream is null)
                throw new ArgumentException("No input stream was provided.");

            ushort interfacesCount = _inputStream.ReadU2();
            var interfaces = new List<ushort>(interfacesCount);

            for (int i = 0; i < interfacesCount; i++)
                interfaces.Add(_inputStream.ReadU2());

            var fields = ReadInfo((f, n, d, a) => new JvmFieldInfo(f, n, d, a));
            var methods = ReadInfo((f, n, d, a) => new JvmMethodInfo(f, n, d, a));
            var attributes = ReadAttributes();
            
            return new MetadataBody(interfaces, fields, methods, attributes);
        }

        private IList<T> ReadInfo<T>(Func<AccessFlags, ushort, ushort, JvmAttribute[], T> factory)
        {
            ushort count = _inputStream!.ReadU2();
            if (count == 0)
                return new List<T>();

            var buffer = new List<T>(count);
            for (int i = 0; i < count; i++)
            {
                var flags = (AccessFlags) _inputStream!.ReadU2();
                ushort nameIndex = _inputStream!.ReadU2();
                ushort descriptorIndex = _inputStream!.ReadU2();
                var attributes = ReadAttributes();
                buffer.Add(factory(flags, nameIndex, descriptorIndex, attributes));
            }

            return buffer;
        }

        private JvmAttribute[] ReadAttributes()
        {
            ushort attributesCount = _inputStream!.ReadU2();
            if (attributesCount == 0)
                return Array.Empty<JvmAttribute>();
            
            JvmAttribute[] attributes = new JvmAttribute[attributesCount];
            for (int i = 0; i < attributesCount; i++)
            {
                ushort nameIndex = _inputStream!.ReadU2();
                attributes[i] = _attributeFactory!.Create(_inputStream!);
            }

            return attributes;
        }
    }
}
