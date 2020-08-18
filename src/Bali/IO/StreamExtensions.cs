using System;
using System.IO;

namespace Bali.IO
{
    internal static class StreamExtensions
    {
        internal static byte ReadU1(this Stream stream)
        {
            int value = stream.ReadByte();
            if (value == -1)
                throw new Exception("Unexpected end of stream.");

            return (byte) value;
        }

        internal static ushort ReadU2(this Stream stream) =>
            (ushort) ((stream.ReadU1() << 8) | stream.ReadU1());

        internal static uint ReadU4(this Stream stream) =>
            (uint) ((stream.ReadU2() << 16) | stream.ReadU2());
        
        internal static ulong ReadU8(this Stream stream) =>
            (ulong) stream.ReadU4() << 32 | stream.ReadU4();
    }
}