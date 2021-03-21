using System;

namespace Bali.IO
{
    /// <summary>
    /// Provides a contract for a <see cref="IDataDestination"/> writer which processes the bytes in big endian order.
    /// </summary>
    public interface IBigEndianWriter
    {
        /// <summary>
        /// Gets the current position in the <see cref="IDataSource"/>.
        /// </summary>
        long Position
        {
            get;
        }

        /// <summary>
        /// Creates a new <see cref="IBigEndianSegmentWriter"/> that when disposed will prepend the written data's
        /// length as 2 bytes to the output <see cref="IDataDestination"/>.
        /// </summary>
        /// <returns>A <see cref="IBigEndianSegmentWriter"/></returns>
        IBigEndianSegmentWriter WithU2Length();

        /// <summary>
        /// Creates a new <see cref="IBigEndianSegmentWriter"/> that when disposed will prepend the written data's
        /// length as 4 bytes to the output <see cref="IDataDestination"/>.
        /// </summary>
        /// <returns>A <see cref="IBigEndianSegmentWriter"/></returns>
        IBigEndianSegmentWriter WithU4Length();

        /// <summary>
        /// Writes <see cref="byte"/>s from the provided <paramref name="span"/>.
        /// </summary>
        /// <param name="span">The <see cref="Span{T}"/> to write the bytes from.</param>
        void Write(Span<byte> span);

        /// <summary>
        /// Writes a <see cref="byte"/> to the <see cref="IDataDestination"/>.
        /// </summary>
        /// <param name="value">The <see cref="byte"/> to write.</param>
        void WriteU1(byte value);

        /// <summary>
        /// Writes a <see cref="sbyte"/> to the <see cref="IDataDestination"/>.
        /// </summary>
        /// <param name="value">The <see cref="sbyte"/> to write.</param>
        void WriteI1(sbyte value);

        /// <summary>
        /// Writes a <see cref="ushort"/> to the <see cref="IDataDestination"/>.
        /// </summary>
        /// <param name="value">The <see cref="ushort"/> to write.</param>
        void WriteU2(ushort value);

        /// <summary>
        /// Writes a <see cref="short"/> to the <see cref="IDataDestination"/>.
        /// </summary>
        /// <param name="value">The <see cref="short"/> to write.</param>
        void WriteI2(short value);

        /// <summary>
        /// Writes a <see cref="uint"/> to the <see cref="IDataDestination"/>.
        /// </summary>
        /// <param name="value">The <see cref="uint"/> to write.</param>
        void WriteU4(uint value);

        /// <summary>
        /// Writes a <see cref="int"/> to the <see cref="IDataDestination"/>.
        /// </summary>
        /// <param name="value">The <see cref="int"/> to write.</param>
        void WriteI4(int value);

        /// <summary>
        /// Writes a <see cref="ulong"/> to the <see cref="IDataDestination"/>.
        /// </summary>
        /// <param name="value">The <see cref="ulong"/> to write.</param>
        void WriteU8(ulong value);

        /// <summary>
        /// Writes a <see cref="long"/> to the <see cref="IDataDestination"/>.
        /// </summary>
        /// <param name="value">The <see cref="long"/> to write.</param>
        void WriteI8(long value);

        /// <summary>
        /// Writes a <see cref="float"/> to the <see cref="IDataDestination"/>.
        /// </summary>
        /// <param name="value">The <see cref="float"/> to write.</param>
        void WriteR4(float value);

        /// <summary>
        /// Writes a <see cref="double"/> to the <see cref="IDataDestination"/>.
        /// </summary>
        /// <param name="value">The <see cref="double"/> to write.</param>
        void WriteR8(double value);
    }
}