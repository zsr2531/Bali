using System.Collections.Generic;
using Bali.Attributes;

namespace Bali.IO
{
    /// <summary>
    /// A simple data structure holding the interface indices, the field, methods and attributes of a <see cref="ClassFile"/>.
    /// </summary>
    public readonly struct MetadataBody
    {
        /// <summary>
        /// The list of indices into the <see cref="ConstantPool"/> representing the direct superinterfaces of a <see cref="ClassFile"/>.
        /// </summary>
        public readonly IList<ushort> Interfaces;
        
        /// <summary>
        /// The list of fields of a <see cref="ClassFile"/>.
        /// </summary>
        public readonly IList<JvmFieldInfo> Fields;
        
        /// <summary>
        /// The list of methods of a <see cref="ClassFile"/>.
        /// </summary>
        public readonly IList<JvmMethodInfo> Methods;
        
        /// <summary>
        /// The list of attributes of a <see cref="ClassFile"/>.
        /// </summary>
        public readonly IList<JvmAttribute> Attributes;

        /// <summary>
        /// Creates a new <see cref="MetadataBody"/>.
        /// </summary>
        /// <param name="interfaces">The list of indices into the <see cref="ConstantPool"/> representing the direct superinterfaces of a <see cref="ClassFile"/>.</param>
        /// <param name="fields">The list of fields of a <see cref="ClassFile"/>.</param>
        /// <param name="methods">The list of methods of a <see cref="ClassFile"/>.</param>
        /// <param name="attributes">The list of attributes of a <see cref="ClassFile"/>.</param>
        public MetadataBody(
            IList<ushort> interfaces,
            IList<JvmFieldInfo> fields,
            IList<JvmMethodInfo> methods,
            IList<JvmAttribute> attributes)
        {
            Interfaces = interfaces;
            Fields = fields;
            Methods = methods;
            Attributes = attributes;
        }
    }
}
