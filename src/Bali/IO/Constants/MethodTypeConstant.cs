using System.IO;

namespace Bali.IO.Constants
{
    /// <summary>
    /// Represents a method type.
    /// </summary>
    public class MethodTypeConstant : Constant
    {
        /// <summary>
        /// Creates a new <see cref="MethodTypeConstant"/>.
        /// </summary>
        /// <param name="descriptorIndex">The index into the <see cref="ConstantPool"/> to a <see cref="Utf8Constant"/> holding the descriptor of the method.</param>
        public MethodTypeConstant(ushort descriptorIndex)
            : base(ConstantKind.MethodType) => DescriptorIndex = descriptorIndex;

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> to a <see cref="Utf8Constant"/> holding the descriptor of the method.
        /// </summary>
        public ushort DescriptorIndex
        {
            get;
            set;
        }
        
        /// <summary>
        /// Parses a <see cref="MethodTypeConstant"/> from the given input <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The input <see cref="Stream"/> to read data from.</param>
        /// <returns>The parsed <see cref="MethodTypeConstant"/>.</returns>
        public static MethodTypeConstant Create(Stream stream) => new(stream.ReadU2());
    }
}