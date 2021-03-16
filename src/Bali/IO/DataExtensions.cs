using System;

namespace Bali.IO
{
    /// <summary>
    /// Provides helper methods on the <see cref="IDataSource"/>- and <see cref="IDataDestination"/> contracts.
    /// </summary>
    public static class DataExtensions
    {
        /// <summary>
        /// Reads bytes into the provided <paramref name="span"/>.
        /// </summary>
        /// <param name="data">The <see cref="IDataSource"/> to read data from.</param>
        /// <param name="span">The <see cref="Span{T}"/> to read the bytes into.</param>
        public static void Read(this IDataSource data, Span<byte> span)
        {
            for (int i = 0; i < span.Length; i++)
                span[i] = data.Read();
        }

        /// <summary>
        /// Writes bytes from the provided <paramref name="span"/>.
        /// </summary>
        /// <param name="data">The <see cref="IDataDestination"/> to read data to.</param>
        /// <param name="span">The <see cref="Span{T}"/> to write the bytes from.</param>
        public static void Write(this IDataDestination data, Span<byte> span)
        {
            for (int i = 0; i < span.Length; i++)
                data.Write(span[i]);
        }
    }
}