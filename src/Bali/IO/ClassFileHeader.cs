namespace Bali.IO
{
    public readonly struct ClassFileHeader
    {
        public readonly uint Magic;
        public readonly ushort Minor;
        public readonly ushort Major;

        public ClassFileHeader(uint magic, ushort minor, ushort major)
        {
            Magic = magic;
            Minor = minor;
            Major = major;
        }
    }
}