namespace Bali.Constants
{
    /// <summary>
    /// An enumeration of all types of <see cref="Constant"/>s.
    /// </summary>
    public enum ConstantKind
    {
        /// <summary>
        /// Indicates that the constant is a <see cref="ClassConstant"/>.
        /// </summary>
        Class = 7,
        
        /// <summary>
        /// Indicates that the constant is a <see cref="FieldrefConstant"/>.
        /// </summary>
        Fieldref = 9,
        
        /// <summary>
        /// Indicates that the constant is a <see cref="MethodrefConstant"/>.
        /// </summary>
        Methodref = 10,
        
        /// <summary>
        /// Indicates that the constant is a <see cref="InterfaceMethodrefConstant"/>.
        /// </summary>
        InterfaceMethodref = 11,
        
        /// <summary>
        /// Indicates that the constant is a <see cref="StringConstant"/>.
        /// </summary>
        String = 8,
        
        /// <summary>
        /// Indicates that the constant is a <see cref="IntegerConstant"/>.
        /// </summary>
        Integer = 3,
        
        /// <summary>
        /// Indicates that the constant is a <see cref="FloatConstant"/>.
        /// </summary>
        Float = 4,
        
        /// <summary>
        /// Indicates that the constant is a <see cref="LongConstant"/>.
        /// </summary>
        Long = 5,
        
        /// <summary>
        /// Indicates that the constant is a <see cref="DoubleConstant"/>.
        /// </summary>
        Double = 6,
        
        /// <summary>
        /// Indicates that the constant is a <see cref="NameAndTypeConstant"/>.
        /// </summary>
        NameAndType = 12,
        
        /// <summary>
        /// Indicates that the constant is a <see cref="Utf8Constant"/>.
        /// </summary>
        Utf8 = 1,
        
        /// <summary>
        /// Indicates that the constant is a <see cref="MethodHandleConstant"/>.
        /// </summary>
        MethodHandle = 15,
        
        /// <summary>
        /// Indicates that the constant is a <see cref="MethodTypeConstant"/>.
        /// </summary>
        MethodType = 16,
        
        /// <summary>
        /// Indicates that the constant is a <see cref="InvokeDynamicConstant"/>.
        /// </summary>
        InvokeDynamic = 18
    }
}