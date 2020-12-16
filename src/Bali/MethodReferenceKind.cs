using Bali.Emit;

namespace Bali
{
    /// <summary>
    /// Denotes bytecode behaviour of a method handle.
    /// </summary>
    public enum MethodReferenceKind : byte
    {
        /// <summary>
        /// Indicates that the bytecode behavior is the <see cref="JvmOpCodes.Getfield"/> instruction.
        /// </summary>
        GetField = 1,
        
        /// <summary>
        /// Indicates that the bytecode behaviour is the <see cref="JvmOpCodes.Getstatic"/> instruction.
        /// </summary>
        GetStatic = 2,
        
        /// <summary>
        /// Indicates that the bytecode behaviour is the <see cref="JvmOpCodes.Putfield"/> instruction.
        /// </summary>
        PutField = 3,
        
        /// <summary>
        /// Indicates that the bytecode behaviour is the <see cref="JvmOpCodes.Putstatic"/> instruction.
        /// </summary>
        PutStatic = 4,
        
        /// <summary>
        /// Indicates that the bytecode behaviour is the <see cref="JvmOpCodes.Invokevirtual"/> instruction.
        /// </summary>
        InvokeVirtual = 5,
        
        /// <summary>
        /// Indicates that the bytecode behaviour is the <see cref="JvmOpCodes.Invokestatic"/> instruction.
        /// </summary>
        InvokeStatic = 6,
        
        /// <summary>
        /// Indicates that the bytecode behaviour is the <see cref="JvmOpCodes.Invokespecial"/> instruction.
        /// </summary>
        InvokeSpecial = 7,
        
        /// <summary>
        /// Indicates that the bytecode behaviour is <see cref="JvmOpCodes.New"/>, <see cref="JvmOpCodes.Dup"/>, <see cref="JvmOpCodes.Invokespecial"/>.
        /// </summary>
        NewInvokeSpecial = 8,
        
        /// <summary>
        /// Indicates that the bytecode behaviour is the <see cref="JvmOpCodes.Invokeinterface"/> instruction.
        /// </summary>
        InvokeInterface = 9
    }
}