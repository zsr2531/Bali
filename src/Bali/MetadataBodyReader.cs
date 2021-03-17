using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Bali.Attributes;
using Bali.Attributes.Readers;
using Bali.IO;

namespace Bali
{
    /// <summary>
    /// Reads the interface indices, fields, methods and attributes from a given input <see cref="IBigEndianReader"/>.
    /// </summary>
    public readonly ref struct MetadataBodyReader
    {
        private readonly IBigEndianReader _reader;
        private readonly IJvmAttributeReaderFacade _facade;

        /// <summary>
        /// Creates a new <see cref="MetadataBodyReader"/>.
        /// </summary>
        /// <param name="reader">The input <see cref="IBigEndianReader"/> to read data from.</param>
        /// <param name="constantPool">The <see cref="ConstantPool"/> to resolve constant pool indices with.</param>
        public MetadataBodyReader(IBigEndianReader reader, ConstantPool constantPool)
        {
            _reader = reader;
            _facade = new JvmAttributeReaderFacade(reader, constantPool);
        }

        /// <summary>
        /// Parses the <see cref="MetadataBody"/> from the input <see cref="IBigEndianReader"/>.
        /// </summary>
        /// <returns>The parsed <see cref="MetadataBody"/>.</returns>
        public MetadataBody ReadMetadataBody()
        {
            ushort interfacesCount = _reader.ReadU2();
            var interfaces = new List<ushort>(interfacesCount);

            for (int i = 0; i < interfacesCount; i++)
                interfaces.Add(_reader.ReadU2());

            var fields = ReadInfo<JvmFieldInfo, FieldAccessFlags>((f, n, d, a) => new JvmFieldInfo(f, n, d, a));
            var methods = ReadInfo<JvmMethodInfo, MethodAccessFlags>((f, n, d, a) => new JvmMethodInfo(f, n, d, a));
            var attributes = ReadAttributes();
            
            return new MetadataBody(interfaces, fields, methods, attributes);
        }

        private IList<TType> ReadInfo<TType, TFlags>(Func<TFlags, ushort, ushort, IList<JvmAttribute>, TType> factory)
        {
            ushort count = _reader.ReadU2();
            if (count == 0)
                return new List<TType>();

            var buffer = new List<TType>(count);
            for (int i = 0; i < count; i++)
            {
                ushort rawFlags = _reader!.ReadU2();
                var flags = Unsafe.As<ushort, TFlags>(ref rawFlags);
                ushort nameIndex = _reader!.ReadU2();
                ushort descriptorIndex = _reader!.ReadU2();
                var attributes = ReadAttributes();
                buffer.Add(factory(flags, nameIndex, descriptorIndex, attributes));
            }

            return buffer;
        }

        private IList<JvmAttribute> ReadAttributes()
        {
            ushort attributesCount = _reader.ReadU2();
            if (attributesCount == 0)
                return new List<JvmAttribute>();
            
            var attributes = new List<JvmAttribute>(attributesCount);
            for (int i = 0; i < attributesCount; i++)
                attributes.Add(_facade.ReadAttribute());

            return attributes;
        }
    }
}
