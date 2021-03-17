using System.Collections.Generic;
using Bali.Attributes;
using Bali.Attributes.Writers;
using Bali.IO;

namespace Bali
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

        /// <summary>
        /// Creates a new <see cref="MetadataBody"/> from the specified <paramref name="classFile"/>.
        /// </summary>
        /// <param name="classFile">The <see cref="ClassFile"/> to construct the metadata body of.</param>
        public MetadataBody(ClassFile classFile)
            : this(classFile.Interfaces, classFile.Fields, classFile.Methods, classFile.Attributes)
        {
        }

        /// <summary>
        /// Writes the <see cref="MetadataBody"/> to the <paramref name="writer"/>.
        /// </summary>
        /// <param name="writer">The <see cref="IBigEndianWriter"/> to write the <see cref="MetadataBody"/> to.</param>
        /// <param name="director">The <see cref="IJvmAttributeDirector"/> to write <see cref="JvmAttribute"/>s with.</param>
        public void Write(IBigEndianWriter writer, IJvmAttributeDirector director) =>
            new MetadataBodyWriter(this, writer, director).WriteMetadataBody();

        /// <summary>
        /// Reads the <see cref="MetadataBody"/> of a <see cref="ClassFile"/> from the <paramref name="reader"/>.
        /// </summary>
        /// <param name="reader">The <see cref="IBigEndianReader"/> to read data from.</param>
        /// <param name="constantPool">The <see cref="ConstantPool"/> to resolve constants from.</param>
        /// <returns>The read <see cref="MetadataBody"/>.</returns>
        public static MetadataBody FromReader(IBigEndianReader reader, ConstantPool constantPool) =>
            new MetadataBodyReader(reader, constantPool).ReadMetadataBody();

        /// <summary>
        /// Writes the <see cref="MetadataBody"/> of a <see cref="ClassFile"/> to the <paramref name="writer"/>.
        /// </summary>
        /// <param name="classFile">The <see cref="ClassFile"/> to write the header of.</param>
        /// <param name="writer">The <see cref="IBigEndianWriter"/> to write the <see cref="ConstantPool"/> to.</param>
        public static void IntoWriter(ClassFile classFile, IBigEndianWriter writer) =>
            new MetadataBody(classFile).Write(writer, new JvmAttributeDirector(classFile.Constants));
    }
}
