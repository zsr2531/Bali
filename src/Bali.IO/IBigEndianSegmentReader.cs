using System;

namespace Bali.IO
{
    /// <summary>
    /// Provides a contract for a reader that when disposed will consume the remaining data
    /// from the input <see cref="IDataSource"/>.
    /// </summary>
    /// <remarks>The length is pre-determined when creating the <see cref="IBigEndianSegmentReader"/>.</remarks>
    public interface IBigEndianSegmentReader : IBigEndianReader, IDisposable
    {
    }
}