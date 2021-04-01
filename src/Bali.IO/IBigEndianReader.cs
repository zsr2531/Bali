using System;

namespace Bali.IO
{
    /// <summary>
    /// Provides a contract for a <see cref="IDataSource"/> reader which processes bytes in big endian order.
    /// </summary>
    public interface IBigEndianReader
    {
        /// <summary>
        /// Gets the current position in the <see cref="IDataSource"/>.
        /// </summary>
        long Position
        {
            get;
        }

        /// <summary>
        /// Creates an <see cref="IBigEndianSegmentReader"/> with the length determined by the <paramref name="length"/>.
        /// </summary>
        /// <returns>The <see cref="IBigEndianSegmentReader"/>.</returns>
        IBigEndianSegmentReader WithU2Length(ushort length);

        /// <summary>
        /// Creates an <see cref="IBigEndianSegmentReader"/> with the length determined by the <paramref name="length"/>.
        /// </summary>
        /// <returns>The <see cref="IBigEndianSegmentReader"/>.</returns>
        IBigEndianSegmentReader WithU4Length(uint length);

        /// <summary>
        /// Reads <see cref="byte"/>s into the provided <paramref name="span"/>.
        /// </summary>
        /// <param name="span">The <see cref="Span{T}"/> to hold the read bytes.</param>
        void Read(Span<byte> span);
        
        /// <summary>
        /// Reads the next <see cref="byte"/> from the <see cref="IDataSource"/>
        /// </summary>
        /// <returns>The next <see cref="byte"/>.</returns>
        byte ReadU1();
        
        /// <summary>
        /// Reads the next <see cref="sbyte"/> from the <see cref="IDataSource"/>.
        /// </summary>
        /// <returns>The next <see cref="sbyte"/>.</returns>
        sbyte ReadI1();
        
        /// <summary>
        /// Reads the next <see cref="ushort"/> from the <see cref="IDataSource"/>.
        /// </summary>
        /// <returns>The next <see cref="ushort"/>.</returns>
        ushort ReadU2();
        
        /// <summary>
        /// Reads the next <see cref="short"/> from the <see cref="IDataSource"/>.
        /// </summary>
        /// <returns>The next <see cref="short"/>.</returns>
        short ReadI2();

        /// <summary>
        /// Reads the next <see cref="uint"/> from the <see cref="IDataSource"/>.
        /// </summary>
        /// <returns>The next <see cref="uint"/>.</returns>
        uint ReadU4();

        /// <summary>
        /// Reads the next <see cref="int"/> from the <see cref="IDataSource"/>.
        /// </summary>
        /// <returns>The next <see cref="int"/>.</returns>
        int ReadI4();

        /// <summary>
        /// Reads the next <see cref="ulong"/> from the <see cref="IDataSource"/>.
        /// </summary>
        /// <returns>The next <see cref="ulong"/>.</returns>
        ulong ReadU8();

        /// <summary>
        /// Reads the next <see cref="long"/> from the <see cref="IDataSource"/>.
        /// </summary>
        /// <returns>The next <see cref="long"/>.</returns>
        long ReadI8();

        /// <summary>
        /// Reads the next <see cref="float"/> from the <see cref="IDataSource"/>.
        /// </summary>
        /// <returns>The next <see cref="float"/>.</returns>
        float ReadR4();

        /// <summary>
        /// Reads the next <see cref="double"/> from the <see cref="IDataSource"/>.
        /// </summary>
        /// <returns>The next <see cref="double"/>.</returns>
        double ReadR8();
    }
}