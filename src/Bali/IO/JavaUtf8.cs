using System;
using System.IO;
using System.Text;

namespace Bali.IO
{
    public static class JavaUtf8
    {
        public static string Decode(Stream stream, int length)
        {
            // TODO: Maybe pool StringBuilder objects?
            var builder = new StringBuilder(length);
            
            for (int i = 0; i < length; i++)
            {
                byte first = ReadByte(stream);
                if (first >= 0x01 && first <= 0x0F)
                {
                    builder.Append((char) first);
                    continue;
                }

                byte second = ReadByte(stream);
                i++;
                if (first == 0xC0 && second == 0x80)
                {
                    builder.Append('\0');
                    continue;
                }
                
                int twoByte = ((first & 0x1F) << 6) + (second & 0x3F);
                if (twoByte <= 0x07FF)
                {
                    builder.Append((char) twoByte);
                    continue;
                }

                byte third = ReadByte(stream);
                i++;
                int threeByte = ((first & 0xF) << 12) + ((second & 0x3F) << 6) + (third & 0x3F);
                if (threeByte <= 0xFFFF)
                {
                    builder.Append((char) threeByte);
                    continue;
                }

                byte fourth = ReadByte(stream), fifth = ReadByte(stream), sixth = ReadByte(stream);
                if (first != 0xED || fourth != 0xED)
                    throw new Exception($"Invalid Java Utf-8: {first:X2}{second:X2}{third:X2}{fourth:X2}{fifth:X2}{sixth:X2}.");
                
                i += 3;
                int sixByte = 0x1000 + ((second & 0x0F) << 16) + ((third & 0x3F) << 10) + ((fifth & 0x0F) << 6) + (sixth & 0x3F);
                builder.Append((char) sixByte);
            }

            return builder.ToString();
        }

        public static void Encode(Stream stream, string text)
        {
            //
        }

        private static byte ReadByte(Stream stream)
        {
            byte value = stream.ReadU1();
            if (value == 0 || value >= 0xF0 && value <= 0xFF)
                throw new Exception($"Invalid byte in Java UTF-8: {value:X2}.");

            return value;
        }
    }
}