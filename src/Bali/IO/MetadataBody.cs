using System.Collections.Generic;
using Bali.Metadata;

namespace Bali.IO
{
    public readonly struct MetadataBody
    {
        public readonly IList<ushort> Interfaces;
        
        public readonly IList<JvmFieldInfo> Fields;
        
        public readonly IList<JvmMethodInfo> Methods;
        
        public readonly IList<JvmAttribute> Attributes;

        public MetadataBody(ushort[] interfaces, JvmFieldInfo[] fields, JvmMethodInfo[] methods, JvmAttribute[] attributes)
        {
            Interfaces = interfaces;
            Fields = fields;
            Methods = methods;
            Attributes = attributes;
        }
    }
}
