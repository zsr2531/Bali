namespace Bali.Emit.Operands
{
    /// <summary>
    /// Represents the operand of the <see cref="JvmOpCodes.Iinc"/> opcode.
    /// </summary>
    public class LocalIndexWithSignedByte
    {
        /// <summary>
        /// Creates a new <see cref="LocalIndexWithSignedByte"/>.
        /// </summary>
        /// <param name="localIndex">The local variable's index.</param>
        /// <param name="signedByte">The number to increment the local variable by.</param>
        public LocalIndexWithSignedByte(byte localIndex, sbyte signedByte)
        {
            LocalIndex = localIndex;
            SignedByte = signedByte;
        }

        /// <summary>
        /// Gets or sets the local variable's index.
        /// </summary>
        public byte LocalIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the number to increment the local variable by.
        /// </summary>
        public sbyte SignedByte
        {
            get;
            set;
        }
    }
}