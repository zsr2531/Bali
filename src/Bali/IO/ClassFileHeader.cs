using Bali.IO.Constants;

namespace Bali.IO
{
    /// <summary>
    /// Represents the first 3 values found in a <i>.class</i> file; the magic value, the minor- and the major version.
    /// </summary>
    public readonly struct ClassFileHeader
    {
        /// <summary>
        /// The magic value.
        /// </summary>
        /// <remarks>This should always be <b>0xCAFEBABE</b>.</remarks>
        public readonly uint Magic;
        
        /// <summary>
        /// The minor version.
        /// </summary>
        public readonly ushort Minor;
        
        /// <summary>
        /// The major version.
        /// </summary>
        public readonly ushort Major;

        /// <summary>
        /// The number of <see cref="Constant"/>s in the constants pool <b><i>+ 1</i></b>.
        /// </summary>
        public readonly ushort ConstantPoolCount;

        /// <summary>
        /// Creates a new <see cref="ClassFileHeader"/>.
        /// </summary>
        /// <param name="magic">The magic value.</param>
        /// <param name="minor">The minor version.</param>
        /// <param name="major">The major version.</param>
        /// <param name="constantPoolCount">The number of items in the <see cref="ConstantPool"/> <b><i>+ 1</i></b>.</param>
        public ClassFileHeader(uint magic, ushort minor, ushort major, ushort constantPoolCount)
        {
            Magic = magic;
            Minor = minor;
            Major = major;
            ConstantPoolCount = constantPoolCount;
        }
    }
}