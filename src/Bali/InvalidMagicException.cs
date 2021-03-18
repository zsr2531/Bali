using System;

namespace Bali
{
    /// <summary>
    /// Thrown when the first 4 bytes of a <see cref="ClassFile"/> isn't <b>0xCAFEBABE</b>.
    /// </summary>
    public sealed class InvalidMagicException : Exception
    {
        /// <summary>
        /// Creates a new <see cref="InvalidMagicException"/>.
        /// </summary>
        public InvalidMagicException()
            : base("The magic value wasn't valid.")
        {
        }
    }
}