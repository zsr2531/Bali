using System.Buffers.Binary;
using FluentAssertions;
using Xunit;

namespace Bali.IO.Tests
{
    public class BigEndianSegmentWriterTests
    {
        [Theory]
        [InlineData(177)]
        [InlineData(158)]
        [InlineData(195)]
        [InlineData(131)]
        [InlineData(199)]
        [InlineData(174)]
        [InlineData(161)]
        [InlineData(142)]
        [InlineData(113)]
        [InlineData(91)]
        public void U2Length(ushort bytes)
        {
            using var destination = new BufferDataDestination();
            using (var writer = new BigEndianWriter(destination).WithU2Length())
            {
                for (int i = 0; i < bytes; i++)
                    writer.WriteU1(123);
            }
            
            var length = destination.Buffer[..2];
            BinaryPrimitives.ReadUInt16BigEndian(length).Should().Be(bytes);
        }

        [Theory]
        [InlineData(711)]
        [InlineData(512)]
        [InlineData(636)]
        [InlineData(860)]
        [InlineData(562)]
        [InlineData(830)]
        [InlineData(618)]
        [InlineData(712)]
        [InlineData(857)]
        [InlineData(878)]
        public void U4Length(uint bytes)
        {
            using var destination = new BufferDataDestination();
            using (var writer = new BigEndianWriter(destination).WithU4Length())
            {
                for (int i = 0; i < bytes; i++)
                    writer.WriteU1(123);
            }

            var length = destination.Buffer[..4];
            BinaryPrimitives.ReadUInt32BigEndian(length).Should().Be(bytes);
        }
    }
}