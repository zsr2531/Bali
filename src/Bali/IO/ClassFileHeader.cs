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
        /// Creates a new <see cref="ClassFileHeader"/>.
        /// </summary>
        /// <param name="magic">The magic value.</param>
        /// <param name="minor">The minor version.</param>
        /// <param name="major">The major version.</param>
        public ClassFileHeader(uint magic, ushort minor, ushort major)
        {
            Magic = magic;
            Minor = minor;
            Major = major;
        }

        /// <summary>
        /// Creates a new <see cref="ClassFileHeader"/> from the specified <paramref name="classFile"/>.
        /// </summary>
        /// <param name="classFile">The <see cref="ClassFile"/> to construct the header of.</param>
        public ClassFileHeader(ClassFile classFile)
            : this(classFile.Magic, classFile.MinorVersion, classFile.MajorVersion)
        {
        }

        /// <summary>
        /// Writes the <see cref="ClassFileHeader"/> to the <paramref name="writer"/>.
        /// </summary>
        /// <param name="writer">The <see cref="IBigEndianWriter"/> to write the <see cref="ClassFileHeader"/> to.</param>
        public void Write(IBigEndianWriter writer)
        {
            writer.WriteU4(Magic);
            writer.WriteU2(Minor);
            writer.WriteU2(Major);
        }

        /// <summary>
        /// Reads the <see cref="ClassFileHeader"/> of a <see cref="ClassFile"/> from the <paramref name="reader"/>.
        /// </summary>
        /// <param name="reader">The <see cref="IBigEndianReader"/> to read data from.</param>
        /// <returns>The read <see cref="ClassFileHeader"/>.</returns>
        public static ClassFileHeader FromReader(IBigEndianReader reader) =>
            new(reader.ReadU4(), reader.ReadU2(), reader.ReadU2());

        /// <summary>
        /// Writes the <see cref="ClassFileHeader"/> of a <see cref="ClassFile"/> to the <paramref name="writer"/>.
        /// </summary>
        /// <param name="classFile">The <see cref="ClassFile"/> to write the header of.</param>
        /// <param name="writer">The <see cref="IBigEndianWriter"/> to write the <see cref="ConstantPool"/> to.</param>
        public static void IntoWriter(ClassFile classFile, IBigEndianWriter writer) =>
            new ClassFileHeader(classFile).Write(writer);
    }
}