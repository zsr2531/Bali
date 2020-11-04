using System;
using System.IO;
using System.Text;
using System.Threading;

namespace Bali.IO
{
    /// <summary>
    /// Provides <see cref="Decode"/> and <see cref="Encode"/> methods to consume Java's "modified UTF-8" data.
    /// </summary>
    public static class JavaUtf8
    {
        private static readonly ThreadLocal<StringBuilder> Builder =
            new ThreadLocal<StringBuilder>(() => new StringBuilder());

        /// <summary>
        /// Decodes <paramref name="length"/> amount of bytes from the <paramref name="stream"/> into a <see cref="string"/>.
        /// </summary>
        /// <param name="stream">The input <see cref="Stream"/> to read data from.</param>
        /// <param name="length">The amount of <b><i><see cref="byte"/>s</i></b> to decode.</param>
        /// <returns>The decoded <see cref="string"/>.</returns>
        /// <exception cref="InvalidDataException">When the data read from the input stream isn't valid JavaUtf8.</exception>
        /// <exception cref="InvalidOperationException">When more <see cref="byte"/>s get consumed than the <paramref name="length"/>.</exception>
        public static string Decode(Stream stream, int length)
        {
            var builder = Builder.Value;
            builder.Clear();

            for (int i = 0; i < length; i++)
            {
                if (i > length)
                    throw new InvalidOperationException("Consumed more bytes than the specified length.");

                byte first = ReadByte(stream);
                if (first >= 0x01 && first <= 0x7F)
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
                {
                    throw new InvalidDataException(
                        $"Invalid Java Utf-8: {first:X2}{second:X2}{third:X2}{fourth:X2}{fifth:X2}{sixth:X2}.");
                }

                i += 3;
                int sixByte = 0x1000 + ((second & 0x0F) << 16) + ((third & 0x3F) << 10) + ((fifth & 0x0F) << 6) +
                    (sixth & 0x3F);
                builder.Append((char) sixByte);
            }

            return builder.ToString();
        }

        /// <summary>
        /// Encodes the given <paramref name="text"/> into JavaUtf8 and writes it to the <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to write the encoded bytes to.</param>
        /// <param name="text">The <see cref="string"/> to encode.></param>
        public static void Encode(Stream stream, string text)
        {
            foreach (char character in text)
            {
                if (character == '\0')
                {
                    stream.WriteByte(0xC0);
                    stream.WriteByte(0x80);
                }
                else if (character >= 0x01 && character <= 0x7F)
                {
                    stream.WriteByte((byte) character);
                }
                else if (character <= 0x07FF)
                {
                    byte first = (byte) ((character >> 6) & 0x1F);
                    byte second = (byte) (character & 0x3F);
                    
                    stream.WriteByte(first);
                    stream.WriteByte(second);
                }
                else if (character <= 0xFFFF)
                {
                    byte first = (byte) ((character >> 12) & 0xF);
                    byte second = (byte) ((character >> 6) & 0x3F);
                    byte third = (byte) (character & 0x3F);
                    
                    stream.WriteByte(first);
                    stream.WriteByte(second);
                    stream.WriteByte(third);
                }
                else
                {
                    int value = character - 0x1000;
                    byte second = (byte) ((value >> 16) & 0x0F);
                    byte third = (byte) ((value >> 10) & 0x3F);
                    byte fifth = (byte) ((value >> 6) & 0x0F);
                    byte sixth = (byte) (value & 0x3F);
                    
                    stream.WriteByte(0xED);
                    stream.WriteByte(second);
                    stream.WriteByte(third);
                    stream.WriteByte(0xED);
                    stream.WriteByte(fifth);
                    stream.WriteByte(sixth);
                }
            }
        }

        private static byte ReadByte(Stream stream)
        {
            byte value = stream.ReadU1();
            if (value == 0 || value >= 0xF0 && value <= 0xFF)
                throw new InvalidDataException($"Invalid byte in Java UTF-8: {value:X2}.");

            return value;
        }
    }
}