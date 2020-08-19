using System.IO;

namespace Bali.IO
{
    public class ClassFileHeaderReader
    {
        private readonly Stream _inputStream;

        public ClassFileHeaderReader(Stream inputStream) => _inputStream = inputStream;

        public ClassFileHeader ReadHeader()
        {
            uint magic = _inputStream.ReadU4();
            
            if (magic != 0xCAFEBABE)
                throw new InvalidMagicException();

            ushort minor = _inputStream.ReadU2();
            ushort major = _inputStream.ReadU2();

            return new ClassFileHeader(magic, minor, major);
        }
    }
}