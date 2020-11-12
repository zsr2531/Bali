using Bali.Metadata;

namespace Bali.IO
{
    public readonly struct MetadataBody
    {
        public readonly ushort[] Interfaces;
        
        public readonly JvmFieldInfo[] Fields;
        
        public readonly JvmMethodInfo[] Methods;
        
        public readonly JvmAttribute[] Attributes;

        public MetadataBody(ushort[] interfaces, JvmFieldInfo[] fields, JvmMethodInfo[] methods, JvmAttribute[] attributes)
        {
            Interfaces = interfaces;
            Fields = fields;
            Methods = methods;
            Attributes = attributes;
        }
    }
}