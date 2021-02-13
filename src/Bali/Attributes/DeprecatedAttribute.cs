using Bali.SourceGeneration;

namespace Bali.Attributes
{
    /// <summary>
    /// An attribute which indicates that the given member is deprecated.
    /// </summary>
    [AutoReader]
    [AutoWriter]
    public sealed class DeprecatedAttribute : JvmAttribute
    {
        /// <summary>
        /// Creates a new <see cref="DeprecatedAttribute"/>.
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the attribute.</param>
        public DeprecatedAttribute(ushort nameIndex)
            : base(nameIndex)
        {
        }
    }
}