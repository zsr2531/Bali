using Bali.SourceGeneration;

namespace Bali.Attributes
{
    /// <summary>
    /// An attribute which describes the source file from which a given <see cref="ClassFile"/> was compiled from.
    /// </summary>
    [AutoFactory]
    [AutoBuilder]
    public sealed class SourceFileAttribute : JvmAttribute
    {
        /// <summary>
        /// Creates a new <see cref="SourceFileAttribute"/>.
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the attribute.</param>
        /// <param name="sourceFileIndex">
        /// The index into the <see cref="ConstantPool"/> representing the
        /// source file which this <see cref="ClassFile"/> was compiled from.
        /// </param>
        public SourceFileAttribute(ushort nameIndex, ushort sourceFileIndex)
            : base(nameIndex)
        {
            SourceFileIndex = sourceFileIndex;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> representing the
        /// source file which this <see cref="ClassFile"/> was compiled from.
        /// </summary>
        public ushort SourceFileIndex
        {
            get;
            set;
        }
    }
}