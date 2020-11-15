namespace Bali.Emit.Operands
{
    /// <summary>
    /// Represents the operand of the <see cref="JvmOpCodes.Multinewarray"/> opcode.
    /// </summary>
    public class WideConstantPoolIndexWithArrayDimensions
    {
        /// <summary>
        /// Creates a new <see cref="WideConstantPoolIndexWithArrayDimensions"/>.
        /// </summary>
        /// <param name="wideConstantPoolIndex">The wide index into the <see cref="ConstantPool"/> representing the type of the array to create.</param>
        /// <param name="arrayDimensions">The dimensions of the array to create.</param>
        public WideConstantPoolIndexWithArrayDimensions(ushort wideConstantPoolIndex, byte arrayDimensions)
        {
            WideConstantPoolIndex = wideConstantPoolIndex;
            ArrayDimensions = arrayDimensions;
        }

        /// <summary>
        /// Gets or sets the wide index into the <see cref="ConstantPool"/> representing the type of the array to create.
        /// </summary>
        public ushort WideConstantPoolIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the dimensions of the array to create.
        /// </summary>
        public byte ArrayDimensions
        {
            get;
            set;
        }
    }
}