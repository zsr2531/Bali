namespace Bali.IO
{
    /// <summary>
    /// A simple data structure holding the <see cref="ClassAccessFlags"/>, the <c>this</c> and <c>super</c> class indices.
    /// </summary>
    public readonly struct ClassFileBody
    {
        /// <summary>
        /// The <see cref="ClassAccessFlags"/>.
        /// </summary>
        public readonly ClassAccessFlags AccessFlags;

        /// <summary>
        /// The index into the <see cref="ConstantPool"/> describing this class.
        /// </summary>
        public readonly ushort ThisClass;

        /// <summary>
        /// The index into the <see cref="ConstantPool"/> describing the super class.
        /// </summary>
        public readonly ushort SuperClass;

        /// <summary>
        /// Creates a new <see cref="ClassFileBody"/>.
        /// </summary>
        /// <param name="accessFlags">The <see cref="ClassAccessFlags"/>.</param>
        /// <param name="thisClass">The index into the <see cref="ConstantPool"/> describing this class.</param>
        /// <param name="superClass">The index into the <see cref="ConstantPool"/> describing the superclass.</param>
        public ClassFileBody(ClassAccessFlags accessFlags, ushort thisClass, ushort superClass)
        {
            AccessFlags = accessFlags;
            ThisClass = thisClass;
            SuperClass = superClass;
        }

        /// <summary>
        /// Creates a new <see cref="ClassFileBody"/> from the specified <paramref name="classFile"/>.
        /// </summary>
        /// <param name="classFile">The <see cref="ClassFile"/> to construct the body of.</param>
        public ClassFileBody(ClassFile classFile)
            : this(classFile.AccessFlags, classFile.ThisClassIndex, classFile.SuperClassIndex)
        {
        }

        /// <summary>
        /// Writes the <see cref="ClassFileBody"/> to the <paramref name="writer"/>.
        /// </summary>
        /// <param name="writer">The <see cref="IBigEndianWriter"/> to write the <see cref="ClassFileBody"/> to.</param>
        public void Write(IBigEndianWriter writer)
        {
            writer.WriteU2((ushort) AccessFlags);
            writer.WriteU2(ThisClass);
            writer.WriteU2(SuperClass);
        }

        /// <summary>
        /// Reads the <see cref="ClassFileBody"/> of a <see cref="ClassFile"/> from the <paramref name="reader"/>.
        /// </summary>
        /// <param name="reader">The <see cref="IBigEndianReader"/> to read data from.</param>
        /// <returns>The read <see cref="ClassFileBody"/>.</returns>
        public static ClassFileBody FromReader(IBigEndianReader reader) =>
            new((ClassAccessFlags) reader.ReadU2(), reader.ReadU2(), reader.ReadU2());

        /// <summary>
        /// Writes the <see cref="ClassFileBody"/> of a <see cref="ClassFile"/> to the <paramref name="writer"/>.
        /// </summary>
        /// <param name="classFile">The <see cref="ClassFile"/> to write the header of.</param>
        /// <param name="writer">The <see cref="IBigEndianWriter"/> to write the <see cref="ConstantPool"/> to.</param>
        public static void IntoWriter(ClassFile classFile, IBigEndianWriter writer) =>
            new ClassFileBody(classFile).Write(writer);
    }
}