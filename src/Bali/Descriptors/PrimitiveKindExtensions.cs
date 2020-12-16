using System;

namespace Bali.Descriptors
{
    /// <summary>
    /// Provides helper extension method for <see cref="PrimitiveKind"/>.
    /// </summary>
    public static class PrimitiveKindExtensions
    {
        /// <summary>
        /// Returns the internal name of a JVM primitive.
        /// </summary>
        /// <param name="primitiveKind">The primitive.</param>
        /// <returns>The internal form of the <paramref name="primitiveKind"/>.</returns>
        public static char ToInternalForm(this PrimitiveKind primitiveKind)
        {
            return primitiveKind switch
            {
                PrimitiveKind.Byte => 'B',
                PrimitiveKind.Boolean => 'Z',
                PrimitiveKind.Char => 'C',
                PrimitiveKind.Int => 'I',
                PrimitiveKind.Long => 'J',
                PrimitiveKind.Float => 'F',
                PrimitiveKind.Double => 'D',
                _ => throw new ArgumentOutOfRangeException(nameof(primitiveKind))
            };
        }
    }
}