using System.Text;

namespace Bali.IO
{
    /// <summary>
    /// Provides methods to consume Java's "modified UTF-8" data.
    /// </summary>
    public class JavaUtf8 : Encoding
    {
        /// <summary>
        /// Provides a public singleton instance of this class.
        /// </summary>
        public static readonly JavaUtf8 Instance = new();

        private JavaUtf8()
        {
        }

        /// <inheritdoc />
        public override int GetByteCount(char[] chars, int index, int count)
        {
            int bytes = 0;

            for (int i = index; i < index + count; i++)
            {
                if (chars[i] == 0)
                    bytes += 2;
                else if (chars[i] <= 0x7f)
                    bytes++;
                else if (chars[i] <= 0x7ff)
                    bytes += 2;
                else if (chars[i] <= 0xffff)
                    bytes += 3;
                else
                    bytes += 6;
            }

            return bytes;
        }

        /// <inheritdoc />
        public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
        {
            int start = byteIndex;

            for (int i = charIndex; i < charIndex + charCount; i++)
            {
                char current = chars[i];
                
                if (current == '\0')
                {
                    // The null character is a special case we need to handle.
                    bytes[byteIndex++] = 0xc0;
                    bytes[byteIndex++] = 0x80;
                }
                else if (current <= 0x7f)
                {
                    bytes[byteIndex++] = (byte) current;
                }
                else if (current <= 0x7ff)
                {
                    bytes[byteIndex++] = (byte) (0b11000000 | (byte) ((current & 0x7c0) >> 6));
                    bytes[byteIndex++] = (byte) (0b10000000 | (byte) (current & 0x3f));
                }
                else if (current <= 0xffff)
                {
                    bytes[byteIndex++] = (byte) (0b11100000 | (byte) ((current & 0xf000) >> 12));
                    bytes[byteIndex++] = (byte) (0b10000000 | (byte) ((current & 0xfc0) >> 6));
                    bytes[byteIndex++] = (byte) (0b10000000 | (byte) (current & 0x3f));
                }
                else
                {
                    bytes[byteIndex++] = 0xed;
                    bytes[byteIndex++] = (byte) (0b10100000 | (byte) ((current & 0xf000) >> 16));
                    bytes[byteIndex++] = (byte) (0b10000000 | (byte) ((current & 0xfc00) >> 10));
                    bytes[byteIndex++] = 0xed;
                    bytes[byteIndex++] = (byte) (0b10110000 | (byte) ((current & 0x3c0) >> 6));
                    bytes[byteIndex++] = (byte) (0b10000000 | (byte) (current & 0x3f));
                }
            }

            return byteIndex - start;
        }

        /// <inheritdoc />
        public override int GetCharCount(byte[] bytes, int index, int count)
        {
            int chars = 0;
            
            for (int i = index; i < index + count; chars++)
            {
                if (bytes[i] >= 0x01 && bytes[i] <= 0x7f)
                    i++;
                else if (bytes[i] == 0xc0 && bytes[i + 1] == 0x80)
                    i += 2;
                else if (((bytes[i] & 0x1f) << 6) + (bytes[i + 1] & 0x3f) <= 0x7ff)
                    i += 2;
                else if (((bytes[i] & 0xf) << 12) + ((bytes[i + 1] & 0x3f) << 6) + (bytes[i + 2] & 0x3f) <= 0xffff)
                    i += 3;
                else
                    i += 6;
            }

            return chars;
        }

        /// <inheritdoc />
        public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
        {
            int start = charIndex;

            for (int i = byteIndex; i < byteIndex + byteCount; charIndex++)
            {
                byte first = bytes[i++];
                if (first <= 0x7f)
                {
                    chars[charIndex] = (char) first;
                    continue;
                }
                
                byte second = bytes[i++];
                if (first == 0xc0 && second == 0x80)
                {
                    chars[charIndex] = '\0';
                    continue;
                }

                int twoBytes = ((first & 0x1f) << 6) + (second & 0x3f);
                if (twoBytes <= 0x7ff)
                {
                    chars[charIndex] = (char) twoBytes;
                    continue;
                }

                byte third = bytes[i++];
                int threeBytes = ((first & 0xf) << 12) + ((second & 0x3f) << 6) + (third & 0x3f);
                if (threeBytes <= 0xffff)
                {
                    chars[charIndex] = (char) threeBytes;
                    continue;
                }

                _ = bytes[i++];
                byte fifth = bytes[i++];
                byte sixth = bytes[i++];

                int sixBytes = 0x1000 + ((second & 0xf) << 16) + ((third & 0x3f) << 10)
                    + ((fifth & 0xf) << 6) + (sixth & 0x3f);
                chars[charIndex] = (char) sixBytes;
            }

            return charIndex - start;
        }

        /// <inheritdoc />
        public override int GetMaxByteCount(int charCount) => charCount * 6;

        /// <inheritdoc />
        public override int GetMaxCharCount(int byteCount) => byteCount;
    }
}