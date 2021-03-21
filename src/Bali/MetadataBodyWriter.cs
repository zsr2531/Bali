using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Bali.Attributes;
using Bali.Attributes.Writers;
using Bali.IO;

namespace Bali
{
    internal readonly ref struct MetadataBodyWriter
    {
        private readonly MetadataBody _metadataBody;
        private readonly IBigEndianWriter _writer;
        private readonly IJvmAttributeDirector _director;

        internal MetadataBodyWriter(in MetadataBody metadataBody, IBigEndianWriter writer, IJvmAttributeDirector director)
        {
            _metadataBody = metadataBody;
            _writer = writer;
            _director = director;
        }

        internal void WriteMetadataBody()
        {
            _writer.WriteU2((ushort) _metadataBody.Interfaces.Count);
            foreach (ushort @interface in _metadataBody.Interfaces)
                _writer.WriteU2(@interface);
            
            WriteInfo(_metadataBody.Fields, f => f.AccessFlags, f => f.NameIndex, f => f.DescriptorIndex, f => f.Attributes);
            WriteInfo(_metadataBody.Methods, m => m.AccessFlags, m => m.NameIndex, m => m.DescriptorIndex, m => m.Attributes);
            WriteAttributes(_metadataBody.Attributes);
        }

        private void WriteInfo<TType, TFlags>(
            IList<TType> list,
            Func<TType, TFlags> flagSelector,
            Func<TType, ushort> nameSelector,
            Func<TType, ushort> descriptorSelector,
            Func<TType, IList<JvmAttribute>> attributeSelector)
        {
            _writer.WriteU2((ushort) list.Count);
            foreach (var item in list)
            {
                var flags = flagSelector(item);
                ushort rawFlags = Unsafe.As<TFlags, ushort>(ref flags);
                
                _writer.WriteU2(rawFlags);
                _writer.WriteU2(nameSelector(item));
                _writer.WriteU2(descriptorSelector(item));
                WriteAttributes(attributeSelector(item));
            }
        }

        private void WriteAttributes(IList<JvmAttribute> attributes)
        {
            _writer.WriteU2((ushort) attributes.Count);
            foreach (var attribute in attributes)
                _director.WriteAttribute(attribute, _writer);
        }
    }
}