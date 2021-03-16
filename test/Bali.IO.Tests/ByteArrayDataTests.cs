using FluentAssertions;
using Xunit;

namespace Bali.IO.Tests
{
    public class ByteArrayDataTests
    {
        [Fact]
        public void DataReadFromSource()
        {
            var source = new ByteArrayDataSource(new byte[] { 0xca, 0xfe, 0xba, 0xbe });
            var reader = new BigEndianReader(source);

            reader.ReadU4().Should().Be(0xcafebabe);
        }

        [Fact]
        public void DataWrittenToDestination()
        {
            var destination = new ByteArrayDataDestination();
            var writer = new BigEndianWriter(destination);
            
            writer.WriteU4(0xcafebabe);

            destination.Buffer[..4].Should().Equal(0xca, 0xfe, 0xba, 0xbe);
        }
    }
}