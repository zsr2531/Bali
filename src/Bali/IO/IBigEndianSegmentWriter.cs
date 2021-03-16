using System;

namespace Bali.IO
{
    /// <summary>
    /// Provides a contract for a writer that when disposed will prepend the written data's
    /// length as 2 bytes to the output <see cref="IDataDestination"/>.
    /// </summary>
    public interface IBigEndianSegmentWriter : IBigEndianWriter, IDisposable
    {
    }
}