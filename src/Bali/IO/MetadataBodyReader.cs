using System;
using System.Collections.Generic;
using System.IO;
using Bali.Metadata;
using Attribute = Bali.Metadata.Attribute;

namespace Bali.IO
{
    public readonly struct MetadataBodyReader
    {
        private readonly Stream? _inputStream;

        public MetadataBodyReader(Stream inputStream) => _inputStream = inputStream;

        public MetadataBody ReadMetadataBody()
        {
            if (_inputStream is null)
                throw new ArgumentException("No input stream was provided.");

            ushort interfacesCount = _inputStream.ReadU2();
            var interfaces = new List<ushort>(interfacesCount);

            for (int i = 0; i < interfacesCount; i++)
                interfaces.Add(_inputStream.ReadU2());

            var fields = ReadInfo((f, n, d, a) => new FieldInfo(f, n, d, a));
            var methods = ReadInfo((f, n, d, a) => new MethodInfo(f, n, d, a));
            var attributes = ReadAttributes();
            
            return new MetadataBody(interfaces, fields, methods, attributes);
        }

        private IList<T> ReadInfo<T>(Func<AccessFlags, ushort, ushort, AttributeInfo[], T> factory)
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

        private Attribute[] ReadAttributes()
        {
            ushort attributesCount = _inputStream!.ReadU2();
            if (attributesCount == 0)
                return Array.Empty<Attribute>();
            
            Attribute[] attributes = new Attribute[attributesCount];
            for (int i = 0; i < attributesCount; i++)
            {
                ushort nameIndex = _inputStream!.ReadU2();
                uint size = _inputStream!.ReadU4();
                if (size == 0)
                {
                    attributes[i] = new Attribute(nameIndex, Array.Empty<byte>());
                    continue;
                }
                
                byte[] data = new byte[size];
                _inputStream!.Read(data, 0, (int) size);
                attributes[i] = new Attribute(nameIndex, data);
            }

            return attributes;
        }
    }
}
