using System.IO;
using FluentAssertions;
using Xunit;

namespace Bali.IO.Tests
{
    public class StreamDataTests
    {
        [Fact]
        public void DataReadFromSource()
        {
            var source = new StreamDataSource(new MemoryStream(new byte[] { 0xca, 0xfe, 0xba, 0xbe }));
            var reader = new BigEndianReader(source);

            reader.ReadU4().Should().Be(0xcafebabe);
        }

        [Fact]
        public void DataWrittenToDestination()
        {
            var stream = new MemoryStream();
            var destination = new StreamDataDestination(stream);
            var writer = new BigEndianWriter(destination);

            writer.WriteU4(0xcafebabe);

            stream.ToArray()[..4].Should().Equal(0xca, 0xfe, 0xba, 0xbe);
        }
    }
}