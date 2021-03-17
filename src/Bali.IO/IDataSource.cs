using System;

namespace Bali.IO
{
    /// <summary>
    /// Provides a contract for a data sources where data gets read from.
    /// </summary>
    public interface IDataSource : IDisposable
    {
        /// <summary>
        /// The current position in the data stream.
        /// </summary>
        long Position
        {
            get;
        }

        /// <summary>
        /// Reads the next <see cref="byte"/> from the data stream.
        /// </summary>
        /// <returns>The next <see cref="byte"/> from the data stream.</returns>
        byte Read();
    }
}