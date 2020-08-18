using System;
using System.IO;

namespace Bali.IO
{
    public class ClassFileReader
    {
        private readonly Stream _inputStream;

        public ClassFileReader(Stream inputStream) => _inputStream = inputStream;

        public ClassFileHeader ReadHeader()
        {
            uint magic = _inputStream.ReadU4();
            
            if (magic != 0xCAFEBABE)
                throw new Exception($"Incorrect magic value: 0x{magic:X4}.");

            ushort minor = _inputStream.ReadU2();
            ushort major = _inputStream.ReadU2();
            ushort constantPoolCount = _inputStream.ReadU2();

            return new ClassFileHeader(magic, minor, major, constantPoolCount);
        }
    }
}