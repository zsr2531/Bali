using Bali.SourceGeneration;

namespace Bali.Metadata.Attributes
{
    /// <summary>
    /// An attribute which describes a constant value.
    /// </summary>
    [AutoFactory]
    [AutoBuilder]
    public sealed class ConstantValueAttribute : JvmAttribute
    {
        /// <summary>
        /// Creates a new <see cref="ConstantValueAttribute"/>.
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the attribute.</param>
        /// <param name="constantValueIndex">The index into the <see cref="ConstantPool"/> representing the value of the constant.</param>
        public ConstantValueAttribute(ushort nameIndex, ushort constantValueIndex)
            : base(nameIndex)
        {
            ConstantValueIndex = constantValueIndex;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> representing the value of the constant.
        /// </summary>
        public ushort ConstantValueIndex
        {
            get;
            set;
        }
    }
}