using FluentAssertions;
using Xunit;

namespace Bali.IO.Tests
{
    public class BigEndianWriterTests
    {
        [Theory]
        [InlineData(112)]
        [InlineData(79)]
        [InlineData(177)]
        [InlineData(166)]
        [InlineData(61)]
        [InlineData(121)]
        [InlineData(242)]
        [InlineData(181)]
        [InlineData(153)]
        [InlineData(215)]
        public void WriteU1(byte value)
        {
            var destination = new BufferDataDestination();
            var writer = new BigEndianWriter(destination);

            writer.WriteU1(value);

            Verify(value, destination);
        }

        [Theory]
        [InlineData(20)]
        [InlineData(-48)]
        [InlineData(-81)]
        [InlineData(72)]
        [InlineData(44)]
        [InlineData(-75)]
        [InlineData(30)]
        [InlineData(-117)]
        [InlineData(103)]
        [InlineData(-29)]
        public void WriteI1(sbyte value)
        {
            var destination = new BufferDataDestination();
            var writer = new BigEndianWriter(destination);

            writer.WriteI1(value);

            Verify(value, destination);
        }

        [Theory]
        [InlineData(65010)]
        [InlineData(33886)]
        [InlineData(37702)]
        [InlineData(14190)]
        [InlineData(15980)]
        [InlineData(31243)]
        [InlineData(21406)]
        [InlineData(53636)]
        [InlineData(45840)]
        [InlineData(50601)]
        public void WriteU2(ushort value)
        {
            var destination = new BufferDataDestination();
            var writer = new BigEndianWriter(destination);

            writer.WriteU2(value);

            Verify(value, destination);
        }

        [Theory]
        [InlineData(29134)]
        [InlineData(12095)]
        [InlineData(-3256)]
        [InlineData(2360)]
        [InlineData(19573)]
        [InlineData(-24296)]
        [InlineData(-16293)]
        [InlineData(-21796)]
        [InlineData(19547)]
        [InlineData(-8661)]
        public void WriteI2(short value)
        {
            var destination = new BufferDataDestination();
            var writer = new BigEndianWriter(destination);

            writer.WriteI2(value);

            Verify(value, destination);
        }

        [Theory]
        [InlineData(3205490900)]
        [InlineData(4153356819)]
        [InlineData(120954849)]
        [InlineData(1865702061)]
        [InlineData(3634914551)]
        [InlineData(2388933745)]
        [InlineData(262721887)]
        [InlineData(471512203)]
        [InlineData(3341731853)]
        [InlineData(2763229251)]
        public void WriteU4(uint value)
        {
            var destination = new BufferDataDestination();
            var writer = new BigEndianWriter(destination);

            writer.WriteU4(value);

            Verify(value, destination);
        }

        [Theory]
        [InlineData(2058979444)]
        [InlineData(525894149)]
        [InlineData(202301324)]
        [InlineData(1428068962)]
        [InlineData(1901932874)]
        [InlineData(468713508)]
        [InlineData(1523614481)]
        [InlineData(573576756)]
        [InlineData(834525311)]
        [InlineData(36060993)]
        public void WriteI4(int value)
        {
            var destination = new BufferDataDestination();
            var writer = new BigEndianWriter(destination);

            writer.WriteI4(value);

            Verify(value, destination);
        }

        [Theory]
        [InlineData(6516492810)]
        [InlineData(559288740)]
        [InlineData(774606310)]
        [InlineData(450674870)]
        [InlineData(1427018450)]
        [InlineData(9629651010)]
        [InlineData(11164425490)]
        [InlineData(852185440)]
        [InlineData(8382936220)]
        [InlineData(7107998100)]
        public void WriteU8(ulong value)
        {
            var destination = new BufferDataDestination();
            var writer = new BigEndianWriter(destination);

            writer.WriteU8(value);

            Verify(value, destination);
        }

        [Theory]
        [InlineData(3310171790)]
        [InlineData(-12114322200)]
        [InlineData(5095808820)]
        [InlineData(4908261960)]
        [InlineData(2097500630)]
        [InlineData(-847813090)]
        [InlineData(-1676976920)]
        [InlineData(-6237552690)]
        [InlineData(-9482799940)]
        [InlineData(687184780)]
        public void WriteI8(long value)
        {
            var destination = new BufferDataDestination();
            var writer = new BigEndianWriter(destination);

            writer.WriteI8(value);

            Verify(value, destination);
        }

        [Theory]
        [InlineData(10502386442.9051)]
        [InlineData(-2328673369.14374)]
        [InlineData(-1855265455.63566)]
        [InlineData(-8455693292.71138)]
        [InlineData(9179293520.63432)]
        [InlineData(7353682646.97929)]
        [InlineData(3101677279.50977)]
        [InlineData(5801257891.34457)]
        [InlineData(-3022811329.79469)]
        [InlineData(2833535608.21051)]
        public void WriteR4(float value)
        {
            var destination = new BufferDataDestination();
            var writer = new BigEndianWriter(destination);

            writer.WriteR4(value);

            Verify(value, destination);
        }

        [Theory]
        [InlineData(8806121488676.74)]
        [InlineData(55569701188923.6)]
        [InlineData(-76628913578398)]
        [InlineData(-9361067299350.27)]
        [InlineData(39894388569396.1)]
        [InlineData(-82689742867334.4)]
        [InlineData(-65774923408018.9)]
        [InlineData(75560142868353.1)]
        [InlineData(-33891005999326.6)]
        [InlineData(45342617787685.1)]
        public void WriteR8(double value)
        {
            var destination = new BufferDataDestination();
            var writer = new BigEndianWriter(destination);

            writer.WriteR8(value);

            Verify(value, destination);
        }

        private static unsafe void Verify<T>(T data, BufferDataDestination destination) where T : unmanaged
        {
            var buffer = destination.Buffer;
            destination.Position.Should().Be(sizeof(T));
            for (int i = 0; i < sizeof(T); i++)
            {
                byte value = *((byte*) &data + i);
                buffer[sizeof(nint) == 4 ? i : sizeof(T) - i - 1].Should().Be(value);
            }
        }
    }
}