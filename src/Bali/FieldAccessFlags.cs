using System;

namespace Bali
{
    /// <summary>
    /// Denotes access permissions of a field.
    /// </summary>
    [Flags]
    public enum FieldAccessFlags : ushort
    {
        /// <summary>
        /// Declared public; may be accessed from outside its package.
        /// </summary>
        Public = 0x0001,
        
        /// <summary>
        /// Declared private; usable only within the defining class.
        /// </summary>
        Private = 0x0002,
        
        /// <summary>
        /// Declared protected; may be accessed within subclasses.
        /// </summary>
        Protected = 0x0004,
        
        /// <summary>
        /// Declared static; no instance is needed to access the field.
        /// </summary>
        Static = 0x0008,
        
        /// <summary>
        /// Declared final; never directly assigned to after object construction.
        /// </summary>
        Final = 0x0010,
        
        /// <summary>
        /// Declared volatile; cannot be cached.
        /// </summary>
        Volatile = 0x0040,
        
        /// <summary>
        /// Declared transient; not written or read by a persistent object manager.
        /// </summary>
        Transient = 0x0080,
        
        /// <summary>
        /// Declared synthetic; not present in the source code.
        /// </summary>
        Synthetic = 0x1000,
        
        /// <summary>
        /// Declared as an element of an enum.
        /// </summary>
        Enum = 0x4000,
    }
}