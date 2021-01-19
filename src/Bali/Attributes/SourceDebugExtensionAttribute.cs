namespace Bali.Attributes
{
    /// <summary>
    /// An attribute which provides extended debugging information.
    /// </summary>
    public sealed class SourceDebugExtensionAttribute : JvmAttribute
    {
        /// <summary>
        /// Creates a new <see cref="SourceDebugExtensionAttribute"/>.
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the attribute.</param>
        /// <param name="debugExtension">The extended debugging information.</param>
        public SourceDebugExtensionAttribute(ushort nameIndex, byte[] debugExtension)
            : base(nameIndex, debugExtension)
        {
        }

        /// <summary>
        /// Gets or sets the extended debugging information.
        /// </summary>
        public byte[] DebugExtension
        {
            get => Data!;
            set => Data = value;
        }
    }
}