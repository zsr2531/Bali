using System.Collections.Generic;
using Bali.Metadata;

namespace Bali.IO
{
    public readonly struct MetadataBody
    {
        public readonly IList<ushort> Interfaces;
        
        public readonly IList<FieldInfo> Fields;
        
        public readonly IList<MethodInfo> Methods;
        
        public readonly IList<AttributeInfo> Attributes;

        public MetadataBody(IList<ushort> interfaces, IList<FieldInfo> fields, IList<MethodInfo> methods, IList<AttributeInfo> attributes)
        {
            Interfaces = interfaces;
            Fields = fields;
            Methods = methods;
            Attributes = attributes;
        }
    }
}
