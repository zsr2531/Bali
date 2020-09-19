namespace Bali.Emit
{
    /// <summary>
    /// The raw opcode of a JVM instruction.
    /// </summary>
    public enum JvmCode : byte
    {
        /// <summary>
        /// Loads a reference from an array.
        /// </summary>
        aaload = 0x32,
        
        /// <summary>
        /// Stores a reference to an array.
        /// </summary>
        aastore = 0x53,
        
        /// <summary>
        /// Pushes <c>null</c> onto the stack.
        /// </summary>
        aconst_null = 0x1,
        
        /// <summary>
        /// Loads a reference from a local variable.
        /// </summary>
        /// <remarks>
        /// The aload instruction cannot be used to load a value of type <c>returnAddress</c> from a local variable onto the operand stack.
        /// This asymmetry with the astore instruction (<see cref="astore"/>) is intentional.
        /// </remarks>
        aload = 0x19,
        
        /// <inheritdoc cref="aload" />
        aload_0 = 0x2a,

        /// <inheritdoc cref="aload" />
        aload_1 = 0x2b,

        /// <inheritdoc cref="aload" />
        aload_2 = 0x2c,

        /// <inheritdoc cref="aload" />
        aload_3 = 0x2d,
        
        /// <summary>
        /// Creates a new array of reference.
        /// </summary>
        anewarray = 0xbd,
        
        /// <summary>
        /// Returns a reference from a method.
        /// </summary>
        areturn = 0xb0,
        
        /// <summary>
        /// Gets the length of an array.
        /// </summary>
        arraylength = 0xbe,
        
        /// <summary>
        /// Stores a reference into a local variable.
        /// </summary>
        /// <remarks>
        /// The astore instruction is used with an objectref of type <c>returnAddress</c> when implementing the <i>finally</i> clause of the Java programming language (§3.13).
        /// The aload instruction (<see cref="aload"/>) cannot be used to load a value of type <c>returnAddress</c> from a local variable onto the operand stack.
        /// This asymmetry with the <see cref="aload"/> instruction is intentional.
        /// </remarks>
        astore = 0x3a,
        
        /// <inheritdoc cref="astore" />
        astore_0 = 0x4b,

        /// <inheritdoc cref="astore" />
        astore_1 = 0x4c,

        /// <inheritdoc cref="astore" />
        astore_2 = 0x4d,

        /// <inheritdoc cref="astore" />
        astore_3 = 0x4e,
        
        /// <summary>
        /// Throws an exception or an error.
        /// </summary>
        /// <remarks>If the exception to be thrown is <c>null</c>, a <c>NullPointerException</c> will be thrown instead.</remarks>
        athrow = 0xbf,
        
        /// <summary>
        /// Loads a <c>byte</c> or <c>boolean</c> from an array.
        /// </summary>
        baload = 0x33,
    }
}