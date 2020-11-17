using System;

namespace Bali
{
    /// <summary>
    /// Denotes access permissions of a class or interface.
    /// </summary>
    [Flags]
    public enum ClassAccessFlags : ushort
    {
        /// <summary>
        /// Declared public; may be accessed from outside its package. 
        /// </summary>
        Public = 0x0001,
        
        /// <summary>
        /// Declared private; usable only within defining parent class.
        /// </summary>
        Private = 0x0002,
        
        /// <summary>
        /// Declared protected; may be accessed from within subclasses.
        /// </summary>
        Protected = 0x0004,
        
        /// <summary>
        /// Marked or implicitly static in source.
        /// </summary>
        Static = 0x0008,

        /// <summary>
        /// Declared final; no subclasses allowed. 
        /// </summary>
        Final = 0x0010,

        /// <summary>
        /// Treat superclass methods specially when invoked by the <c>invokespecial</c> instruction.
        /// </summary>
        Super = 0x0020,

        /// <summary>
        /// Is an interface, not a class.
        /// </summary>
        Interface = 0x0200,

        /// <summary>
        /// Declared abstract; must not be instantiated.
        /// </summary>
        Abstract = 0x0400,

        /// <summary>
        /// Declared synthetic; not present in the source code.
        /// </summary>
        Synthetic = 0x1000,

        /// <summary>
        /// Declared as an annotation type.
        /// </summary>
        Annotation = 0x2000,

        /// <summary>
        /// Declared as an enum type.
        /// </summary>
        Enum = 0x4000
    }
}
