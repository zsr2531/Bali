namespace Bali.Emit
{
    /// <summary>
    /// Represents a JVM exception handler.
    /// </summary>
    public struct JvmExceptionHandler
    {
        /// <summary>
        /// Gets the index of the first instruction to protect.
        /// </summary>
        public ushort TryStart
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the index of the last instruction to protect.
        /// </summary>
        /// <remarks>Note that this is an exclusive index.</remarks>
        public ushort TryEnd
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the index of the handler block's first instruction.
        /// </summary>
        public ushort HandlerStart
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the index into the <see cref="ConstantPool" /> describing the type of the exception to catch
        /// or 0 if the exception handler is a <c>finally</c> block.
        /// </summary>
        public ushort CatchType
        {
            get;
            set;
        }

        /// <inheritdoc />
        public override int GetHashCode() => TryStart + TryEnd + HandlerStart + CatchType;
    }
}