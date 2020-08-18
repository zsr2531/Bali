using System;
using System.IO;

namespace Bali.IO
{
    public static class JavaUtf8
    {
        public static string Decode(Stream stream, int length)
        {
            return null;
        }

        public static void Encode(Stream stream, string text)
        {
            //
        }

        private static byte ReadByte(Stream stream)
        {
            byte value = stream.ReadU1();
            if (value == 0 || value >= 0xF0 && value <= 0xFF)
                throw new Exception($"Invalid byte in string literal: {value:X2}.");

            return value;
        }
    }
}