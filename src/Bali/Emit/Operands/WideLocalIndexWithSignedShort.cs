namespace Bali.Emit.Operands
{
    /// <summary>
    /// Represents the operand of the wide version of the <see cref="JvmOpCodes.Iinc"/> opcode.
    /// </summary>
    public class WideLocalIndexWithSignedShort
    {
        /// <summary>
        /// Creates a new <see cref="WideLocalIndexWithSignedShort"/>.
        /// </summary>
        /// <param name="localIndex">The local variable's index.</param>
        /// <param name="signedShort">The number to increment the local variable by.</param>
        public WideLocalIndexWithSignedShort(ushort localIndex, short signedShort)
        {
            LocalIndex = localIndex;
            SignedShort = signedShort;
        }

        /// <summary>
        /// Gets or sets the local variable's index.
        /// </summary>
        public ushort LocalIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the number to increment the local variable by.
        /// </summary>
        public short SignedShort
        {
            get;
            set;
        }
    }
}