using System;

namespace Bali
{
    /// <summary>
    /// Denotes access permissions to and properties of this class or interface.
    /// </summary>
    [Flags]
    public enum AccessFlags : ushort
    {
        /// <summary>
        /// Declared public; may be accessed from outside its package. 
        /// </summary>
        Public = 0x0001,

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
