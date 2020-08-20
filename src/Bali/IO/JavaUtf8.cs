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
        private static readonly ThreadLocal<StringBuilder> Builder = new ThreadLocal<StringBuilder>(() => new StringBuilder());
        
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

            int i = 0;
            for (; i < length; i++)
            {
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
                    throw new InvalidDataException($"Invalid Java Utf-8: {first:X2}{second:X2}{third:X2}{fourth:X2}{fifth:X2}{sixth:X2}.");
                
                i += 3;
                int sixByte = 0x1000 + ((second & 0x0F) << 16) + ((third & 0x3F) << 10) + ((fifth & 0x0F) << 6) + (sixth & 0x3F);
                builder.Append((char) sixByte);
            }
            
            if (i > length)
                throw new InvalidOperationException("Consumed more bytes than the specified length.");

            return builder.ToString();
        }

        /// <summary>
        /// Encodes the given <paramref name="text"/> into JavaUtf8 and writes it to the <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to write the encoded bytes to.</param>
        /// <param name="text">The <see cref="string"/> to encode.></param>
        public static void Encode(Stream stream, string text)
        {
            throw new NotImplementedException();
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