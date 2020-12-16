using Bali.SourceGeneration;

namespace Bali.Metadata.Attributes
{
    /// <summary>
    /// An attribute which describes a local/anonymous class defined in a method in the source code.
    /// </summary>
    [AutoFactory]
    [AutoBuilder]
    public sealed class EnclosingMethodAttribute : JvmAttribute
    {
        /// <summary>
        /// Creates a new <see cref="EnclosingMethodAttribute"/>.
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the attribute.</param>
        /// <param name="classIndex">The index into the <see cref="ConstantPool"/> representing the local/anonymous class.</param>
        /// <param name="methodIndex">
        /// The index into the <see cref="ConstantPool"/> representing the method which contained the
        /// local/anonymous class originally in the source code.
        /// </param>
        public EnclosingMethodAttribute(ushort nameIndex, ushort classIndex, ushort methodIndex)
            : base(nameIndex)
        {
            ClassIndex = classIndex;
            MethodIndex = methodIndex;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> representing the local/anonymous class.
        /// </summary>
        public ushort ClassIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> representing the method which contained the
        /// local/anonymous class originally in the source code.
        /// </summary>
        public ushort MethodIndex
        {
            get;
            set;
        }
    }
}