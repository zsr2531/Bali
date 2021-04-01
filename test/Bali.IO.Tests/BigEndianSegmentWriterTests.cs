using System.Buffers.Binary;
using FluentAssertions;
using Xunit;

namespace Bali.IO.Tests
{
    public class BigEndianSegmentWriterTests
    {
        [Theory]
        [InlineData(388)]
        [InlineData(110)]
        [InlineData(286)]
        [InlineData(166)]
        [InlineData(369)]
        [InlineData(147)]
        [InlineData(188)]
        [InlineData(137)]
        [InlineData(307)]
        [InlineData(486)]
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
        [InlineData(3149)]
        [InlineData(2595)]
        [InlineData(2610)]
        [InlineData(2148)]
        [InlineData(4442)]
        [InlineData(3516)]
        [InlineData(2645)]
        [InlineData(3321)]
        [InlineData(2950)]
        [InlineData(1087)]
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