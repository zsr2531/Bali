namespace Bali.Emit
{
    /// <summary>
    /// An enumeration indicating the flow control of a particular <see cref="JvmOpCode"/>.
    /// </summary>
    public enum JvmFlowControl : byte
    {
        /// <summary>
        /// Indicates that the instruction will just fall through to the next one.
        /// </summary>
        Fallthrough,
        
        /// <summary>
        /// Indicates that the instruction will always branch.
        /// </summary>
        UnconditionalBranch,
        
        /// <summary>
        /// Indicates that the instruction can branch or fall through to the next one.
        /// </summary>
        ConditionalBranch,
        
        /// <summary>
        /// Indicates that the instructions throws.
        /// </summary>
        Throw,
        
        /// <summary>
        /// Indicates that the instruction exits the method.
        /// </summary>
        Return,
        
        /// <summary>
        /// Indicates that the JVM doesn't define the flow control for the <see cref="JvmOpCode"/>.
        /// </summary>
        Undefined
    }
}