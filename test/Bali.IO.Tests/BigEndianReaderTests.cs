using FluentAssertions;
using Xunit;

namespace Bali.IO.Tests
{
    public class BigEndianReaderTests
    {
        [Theory]
        [InlineData(new byte[] { 0 }, 0)]
        [InlineData(new byte[] { 0x65 }, 0x65)]
        [InlineData(new byte[] { 0x76 }, 0x76)]
        [InlineData(new byte[] { 123 }, 123)]
        [InlineData(new byte[] { 0xff }, 0xff)]

        public void ReadU1(byte[] raw, byte expected)
        {
            var source = new ByteArrayDataSource(raw);
            var reader = new BigEndianReader(source);

            reader.ReadU1().Should().Be(expected);
        }
        
        [Theory]
        [InlineData(new byte[] { 0 }, 0)]
        [InlineData(new byte[] { 0x82 }, -126)]
        [InlineData(new byte[] { 87 }, 87)]
        [InlineData(new byte[] { 123 }, 123)]
        [InlineData(new byte[] { 0xff }, -1)]

        public void ReadI1(byte[] raw, sbyte expected)
        {
            var source = new ByteArrayDataSource(raw);
            var reader = new BigEndianReader(source);
            
            reader.ReadI1().Should().Be(expected);
        }
        
        [Theory]
        [InlineData(new byte[] { 0, 0 }, 0)]
        [InlineData(new byte[] { 0, 0x65 }, 0x65)]
        [InlineData(new byte[] { 0x76, 0 }, 0x76 << 8)]
        [InlineData(new byte[] { 0, 123 }, 123)]
        [InlineData(new byte[] { 0x2e, 0x1f }, (0x2e << 8) | 0x1f)]

        public void ReadU2(byte[] raw, ushort expected)
        {
            var source = new ByteArrayDataSource(raw);
            var reader = new BigEndianReader(source);
            
            reader.ReadU2().Should().Be(expected);
        }
        
        [Theory]
        [InlineData(new byte[] { 0, 0 }, 0)]
        [InlineData(new byte[] { 0xff, 0x82 }, -126)]
        [InlineData(new byte[] { 87, 65 }, (87 << 8) | 65)]
        [InlineData(new byte[] { 0, 123 }, 123)]
        [InlineData(new byte[] { 0xff, 0xff }, -1)]

        public void ReadI2(byte[] raw, short expected)
        {
            var source = new ByteArrayDataSource(raw);
            var reader = new BigEndianReader(source);
            
            reader.ReadI2().Should().Be(expected);
        }
    }
}