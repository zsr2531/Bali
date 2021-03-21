using System;

namespace Bali.IO
{
    /// <summary>
    /// Provides a contract for a data destination where data gets written to.
    /// </summary>
    public interface IDataDestination : IDisposable
    {
        /// <summary>
        /// The current position in the data stream.
        /// </summary>
        int Position
        {
            get;
        }

        /// <summary>
        /// Writes the <paramref name="value"/> to the data stream.
        /// </summary>
        /// <param name="value">The <see cref="byte"/> to write to the data stream.</param>
        void Write(byte value);
    }
}