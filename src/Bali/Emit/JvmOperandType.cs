namespace Bali.Emit
{
    /// <summary>
    /// An enumeration representing the type of the operand of a <see cref="JvmOpCode"/>.
    /// </summary>
    public enum JvmOperandType : byte
    {
        /// <summary>
        /// Indicates that the opcode has no operand.
        /// </summary>
        None,
        
        /// <summary>
        /// Indicates that the opcode has a signed short operand that is the offset to
        /// the target instruction, relative to the current one.
        /// </summary>
        BranchOffset,
        
        /// <summary>
        /// Indicates that the opcode has a signed int operand that is the offset to
        /// the target instruction, relative to the current one.
        /// </summary>
        WideBranchOffset,
        
        /// <summary>
        /// Indicates that the opcode has a jump table operand.
        /// </summary>
        /// <remarks>Used by <see cref="JvmOpCodes.Lookupswitch"/>.</remarks>
        LookupSwitchJumpTable,
        
        /// <summary>
        /// Indicates that the opcode has a jump table operand.
        /// </summary>
        /// <remarks>Used by <see cref="JvmOpCodes.Tableswitch"/>.</remarks>
        TableSwitchJumpTable,
        
        /// <summary>
        /// Indicates that the opcode's operand references an argument/local variable with a single unsigned byte as the index.
        /// </summary>
        LocalIndex,
        
        /// <summary>
        /// Indicates that the opcode's operand references an argument/local variable with an unsigned short as the index,
        /// but also has an extra signed byte.
        /// </summary>
        /// <remarks>Used by <see cref="JvmOpCodes.Iinc"/>.</remarks>
        LocalIndexWithSignedByte,
        
        /// <summary>
        /// Indicates that the opcode's operand indexes the <see cref="ConstantPool"/> with a single unsigned byte as the index.
        /// </summary>
        ConstantPoolIndex,
        
        /// <summary>
        /// Indicates that the opcode's operand indexes the <see cref="ConstantPool"/> with an unsigned short as the index.
        /// </summary>
        WideConstantPoolIndex,
        
        /// <summary>
        /// Indicates that the opcode's operand indexes the <see cref="ConstantPool"/> with an unsigned short as the index,
        /// but also has an extra unsigned byte for the array dimensions.
        /// </summary>
        /// <remarks>Used by <see cref="JvmOpCodes.Multinewarray"/>.</remarks>
        WideConstantPoolIndexWithArrayDimensions,
        
        /// <summary>
        /// Indicates that the opcode's operand indexes the <see cref="ConstantPool"/> with an unsigned short as the index,
        /// but also has 2 extra unsigned bytes.
        /// </summary>
        /// <remarks>Used by <see cref="JvmOpCodes.Invokedynamic"/> and <see cref="JvmOpCodes.Invokeinterface"/> for redundancy purposes.</remarks>
        WideConstantPoolIndexWithTwoBytes,
        
        /// <summary>
        /// Indicates that the opcode's operand is a <see cref="JvmPrimitiveArrayType"/>.
        /// </summary>
        ArrayType,
        
        /// <summary>
        /// Indicates that the opcode's operand is a signed byte.
        /// </summary>
        InlineByte,
        
        /// <summary>
        /// Indicates that the opcode's operand is a signed short.
        /// </summary>
        InlineShort
    }
}