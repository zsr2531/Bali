using System.IO;
using FluentAssertions;
using Xunit;

namespace Bali.IO.Tests
{
    public class FileDataTests
    {
        [Fact]
        public void DataReadFromSource()
        {
            string path = Path.GetRandomFileName();
            File.WriteAllBytes(path, new byte[] { 0xca, 0xfe, 0xba, 0xbe });
            using var source = new FileDataSource(path);
            var reader = new BigEndianReader(source);

            reader.ReadU4().Should().Be(0xcafebabe);
        }

        [Fact]
        public void DataWrittenToDestination()
        {
            string path = Path.GetRandomFileName();
            var destination = new FileDataDestination(path);
            var writer = new BigEndianWriter(destination);

            writer.WriteU4(0xcafebabe);

            destination.Dispose();
            File.ReadAllBytes(path).Should().Equal(0xca, 0xfe, 0xba, 0xbe);
        }
    }
}