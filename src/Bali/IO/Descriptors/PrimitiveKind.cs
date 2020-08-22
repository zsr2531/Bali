namespace Bali.IO.Descriptors
{
    /// <summary>
    /// The 7 primitive types that the JVM supports.
    /// </summary>
    public enum PrimitiveKind
    {
        /// <summary>
        /// A single <c>byte</c>.
        /// </summary>
        Byte,
        
        /// <summary>
        /// A logical <c>true</c> or <c>false</c>.
        /// </summary>
        Boolean,
        
        /// <summary>
        /// A single <c>char</c> encoded as UTF-16.
        /// </summary>
        Char,
        
        /// <summary>
        /// A 32 bit signed integer.
        /// </summary>
        Int,
        
        /// <summary>
        /// A 64 bit signed integer.
        /// </summary>
        Long,
        
        /// <summary>
        /// A single-precision floating point number.
        /// </summary>
        Float,
        
        /// <summary>
        /// A double-precision floating point number.
        /// </summary>
        Double
    }
}