using FluentAssertions;
using Xunit;

namespace Bali.IO.Tests
{
    public class BufferDataTests
    {
        [Fact]
        public void DataReadFromSource()
        {
            var source = new BufferDataSource(new byte[] { 0xca, 0xfe, 0xba, 0xbe });
            var reader = new BigEndianReader(source);

            reader.ReadU4().Should().Be(0xcafebabe);
        }

        [Fact]
        public void DataWrittenToDestination()
        {
            var destination = new BufferDataDestination();
            var writer = new BigEndianWriter(destination);
            
            writer.WriteU4(0xcafebabe);

            destination.Buffer.ToArray().Should().Equal(0xca, 0xfe, 0xba, 0xbe);
        }
    }
}