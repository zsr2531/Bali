using System.Collections.Generic;
using Bali.Metadata;

namespace Bali
{
    /// <summary>
    /// Represents a single <c>class</c> or <c>interface</c>.
    /// </summary>
    public class ClassFile
    {
        /// <summary>
        /// Gets or sets the magic value.
        /// </summary>
        /// <remarks>This should always have the value <b>0xCAFEBABE</b>.</remarks>
        public uint Magic
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the minor version of this <see cref="ClassFile"/>.
        /// </summary>
        public ushort MinorVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the major version of this <see cref="ClassFile"/>.
        /// </summary>
        public ushort MajorVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the <see cref="ConstantPool"/>.
        /// </summary>
        public ConstantPool Constants
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets the <see cref="Bali.AccessFlags"/>.
        /// </summary>
        public AccessFlags AccessFlags
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> that describes this class.
        /// </summary>
        public ushort ThisClassIndex
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> that describes the superclass.
        /// </summary>
        public ushort SuperClassIndex
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets the indices into the <see cref="Constants"/> representing direct superinterfaces of this class.
        /// </summary>
        public IReadOnlyList<ushort>? Interfaces
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the fields of this class.
        /// </summary>
        public IReadOnlyList<FieldInfo>? Fields
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the methods of this class.
        /// </summary>
        public IReadOnlyList<MethodInfo>? Methods
        {
            get;
            set;
        }
    }
}