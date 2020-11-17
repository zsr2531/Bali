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
    }
}