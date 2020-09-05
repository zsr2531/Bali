using Bali.IO;

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
        /// Gets or sets the <see cref="ClassAccessFlags"/>.
        /// </summary>
        public ClassAccessFlags AccessFlags
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
    }
}