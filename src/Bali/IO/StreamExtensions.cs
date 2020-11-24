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

        internal static sbyte ReadI1(this Stream stream) => (sbyte) stream.ReadU1();

        internal static short ReadI2(this Stream stream) => (short) stream.ReadU2();

        internal static int ReadI4(this Stream stream) => (int) stream.ReadU4();

        internal static void WriteU1(this Stream stream, byte value) => stream.WriteByte(value);

        internal static void WriteU2(this Stream stream, ushort value)
        {
            stream.WriteU1((byte) (value >> 8));
            stream.WriteU1((byte) (value & 0xFF));
        }

        internal static void WriteU4(this Stream stream, uint value)
        {
            stream.WriteU2((ushort) (value >> 16));
            stream.WriteU2((ushort) (value & 0xFFFF));
        }

        internal static void WriteU8(this Stream stream, ulong value)
        {
            stream.WriteU4((uint) (value >> 32));
            stream.WriteU4((uint) (value & 0xFFFFFFFF));
        }

        internal static void WriteI1(this Stream stream, sbyte value) => stream.WriteU1((byte) value);
        
        internal static void WriteI2(this Stream stream, short value) => stream.WriteU2((ushort) value);

        internal static void WriteI4(this Stream stream, int value) => stream.WriteU4((uint) value);

        internal static void WriteI8(this Stream stream, long value) => stream.WriteU8((ulong) value);
    }
}