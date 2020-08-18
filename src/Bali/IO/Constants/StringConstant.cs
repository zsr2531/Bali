using System;
using System.Buffers.Binary;
using System.IO;

namespace Bali.IO.Constants
{
    public class StringConstant : Constant
    {
        public StringConstant(ushort stringIndex)
            : base(ConstantKind.String) => StringIndex = stringIndex;

        public ushort StringIndex
        {
            get;
        }

        public static StringConstant Create(Stream stream)
        {
            Span<byte> buffer = stackalloc byte[2];
            int value = stream.ReadByte();
            if (value == -1)
                throw new Exception("Unexpected end of stream.");
            buffer[0] = (byte) value;
            value = stream.ReadByte();
            if (value == -1)
                throw new Exception("Unexpected end of stream.");
            buffer[1] = (byte) value;

            ushort stringIndex = BinaryPrimitives.ReadUInt16BigEndian(buffer);
            return new StringConstant(stringIndex);
        }
    }
}