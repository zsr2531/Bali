namespace Bali
{
    /// <summary>
    /// Represents a single <c>class</c> or <c>interface</c>.
    /// </summary>
    public class ClassFile
    {
        /// <summary>
        /// The magic value.
        /// </summary>
        /// <remarks>This should always have the value <c>0xCAFEBABE</c>.</remarks>
        public uint Magic
        {
            get;
            set;
        }

        /// <summary>
        /// The minor version of this <see cref="ClassFile"/>.
        /// </summary>
        public ushort MinorVersion
        {
            get;
            set;
        }

        /// <summary>
        /// The major version of this <see cref="ClassFile"/>.
        /// </summary>
        public ushort MajorVersion
        {
            get;
            set;
        }
    }
}