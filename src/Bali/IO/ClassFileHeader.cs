namespace Bali.IO
{
    public readonly struct ClassFileHeader
    {
        public readonly uint Magic;
        public readonly ushort Minor;
        public readonly ushort Major;
        public readonly ushort ConstantPoolCount;

        public ClassFileHeader(uint magic, ushort minor, ushort major, ushort constantPoolCount)
        {
            Magic = magic;
            Minor = minor;
            Major = major;
            ConstantPoolCount = constantPoolCount;
        }
    }
}