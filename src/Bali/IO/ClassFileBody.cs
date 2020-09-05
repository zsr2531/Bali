namespace Bali.IO
{
    /// <summary>
    /// A simple data structure holding the <see cref="Bali.AccessFlags"/>, the <c>this</c> and <c>super</c> class indices.
    /// </summary>
    public readonly struct ClassFileBody
    {
        /// <summary>
        /// The <see cref="Bali.AccessFlags"/>.
        /// </summary>
        public readonly AccessFlags AccessFlags;

        /// <summary>
        /// The index into the <see cref="ConstantPool"/> describing this class.
        /// </summary>
        public readonly ushort ThisClass;

        /// <summary>
        /// The index into the <see cref="ConstantPool"/> describing the super class.
        /// </summary>
        public readonly ushort SuperClass;

        /// <summary>
        /// The indices into the <see cref="ConstantPool"/> describing direct superinterfaces of this class.
        /// </summary>
        public readonly ushort[] Interfaces;

        /// <summary>
        /// Creates a new <see cref="ClassFileBody"/>.
        /// </summary>
        /// <param name="accessFlags">The <see cref="Bali.AccessFlags"/>.</param>
        /// <param name="thisClass">The index into the <see cref="ConstantPool"/> describing this class.</param>
        /// <param name="superClass">The index into the <see cref="ConstantPool"/> describing the superclass.</param>
        /// <param name="interfaces">The indices into the <see cref="ConstantPool"/> describing direct superinterfaces of this class.</param>
        public ClassFileBody(AccessFlags accessFlags, ushort thisClass, ushort superClass, ushort[] interfaces)
        {
            AccessFlags = accessFlags;
            ThisClass = thisClass;
            SuperClass = superClass;
            Interfaces = interfaces;
        }
    }
}