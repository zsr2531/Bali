using System.IO;
using FluentAssertions;
using Xunit;

namespace Bali.IO.Tests
{
    public class BigEndianSegmentReaderTests
    {
        [Theory]
        [InlineData(178, 58)]
        [InlineData(176, 67)]
        [InlineData(471, 366)]
        [InlineData(101, 51)]
        [InlineData(131, 54)]
        [InlineData(277, 112)]
        [InlineData(253, 69)]
        [InlineData(239, 225)]
        [InlineData(261, 109)]
        [InlineData(455, 265)]
        public void U2Length(ushort bytes, ushort toRead)
        {
            using var source = new StreamDataSource(new MemoryStream(new byte[bytes]), true);
            using (var reader = new BigEndianReader(source).WithU2Length(toRead))
            {
                for (int i = 0; i < toRead / 2; i++)
                    reader.ReadU1();
            }

            long remaining = bytes - source.Position;
            remaining.Should().Be(bytes - toRead);
        }

        [Theory]
        [InlineData(4258, 2632)]
        [InlineData(3626, 2412)]
        [InlineData(3618, 3330)]
        [InlineData(4361, 854)]
        [InlineData(2689, 1485)]
        [InlineData(4391, 2617)]
        [InlineData(4332, 2980)]
        [InlineData(4114, 3651)]
        [InlineData(3933, 3250)]
        [InlineData(1383, 1152)]
        public void U4Length(uint bytes, uint toRead)
        {
            using var source = new StreamDataSource(new MemoryStream(new byte[bytes]), true);
            using (var reader = new BigEndianReader(source).WithU4Length(toRead))
            {
                for (int i = 0; i < toRead / 2; i++)
                    reader.ReadU1();
            }

            long remaining = bytes - source.Position;
            remaining.Should().Be(bytes - toRead);
        }
    }
}
