namespace Bali.Emit.Operands
{
    /// <summary>
    /// Represents the operand of the <see cref="JvmOpCodes.Invokedynamic"/> and <see cref="JvmOpCodes.Invokeinterface"/> opcodes.
    /// </summary>
    public class WideConstantPoolIndexWithTwoBytes
    {
        /// <summary>
        /// Creates a new <see cref="WideConstantPoolIndexWithTwoBytes"/>.
        /// </summary>
        /// <param name="wideConstantPoolIndex">The wide index into the <see cref="ConstantPool"/> representing the method to invoke.</param>
        /// <param name="byteOne">The first extra byte associated with the operand.</param>
        /// <param name="byteTwo">The second extra byte associated with the operand.</param>
        public WideConstantPoolIndexWithTwoBytes(ushort wideConstantPoolIndex, byte byteOne, byte byteTwo)
        {
            WideConstantPoolIndex = wideConstantPoolIndex;
            ByteOne = byteOne;
            ByteTwo = byteTwo;
        }

        /// <summary>
        /// Gets or sets the wide index into the <see cref="ConstantPool"/> representing the method to invoke.
        /// </summary>
        public ushort WideConstantPoolIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the first extra byte associated with the operand.
        /// </summary>
        public byte ByteOne
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the second extra byte associated with the operand.
        /// </summary>
        public byte ByteTwo
        {
            get;
            set;
        }
    }
}