using Bali.Metadata;

namespace Bali.IO
{
    public readonly struct MetadataBody
    {
        public readonly ushort[] Interfaces;
        
        public readonly FieldInfo[] Fields;
        
        public readonly MethodInfo[] Methods;
        
        public readonly AttributeInfo[] Attributes;

        public MetadataBody(ushort[] interfaces, FieldInfo[] fields, MethodInfo[] methods, AttributeInfo[] attributes)
        {
            Interfaces = interfaces;
            Fields = fields;
            Methods = methods;
            Attributes = attributes;
        }
    }
}