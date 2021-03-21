using System;
using System.Runtime.CompilerServices;
using FluentAssertions;
using Xunit;

namespace Bali.IO.Tests
{
    public class BigEndianReaderTests
    {
        [Theory]
        [InlineData(167)]
        [InlineData(154)]
        [InlineData(25)]
        [InlineData(10)]
        [InlineData(248)]
        [InlineData(143)]
        [InlineData(178)]
        [InlineData(230)]
        [InlineData(7)]
        [InlineData(97)]
        public void ReadU1(byte value)
        {
            var source = CreateMockDataSource(value);
            var reader = new BigEndianReader(source);

            reader.ReadU1().Should().Be(value);
        }

        [Theory]
        [InlineData(57)]
        [InlineData(13)]
        [InlineData(-106)]
        [InlineData(115)]
        [InlineData(-65)]
        [InlineData(-102)]
        [InlineData(85)]
        [InlineData(-85)]
        [InlineData(-1)]
        [InlineData(-53)]
        public void ReadI1(sbyte value)
        {
            var source = CreateMockDataSource(value);
            var reader = new BigEndianReader(source);

            reader.ReadI1().Should().Be(value);
        }

        [Theory]
        [InlineData(23707)]
        [InlineData(42024)]
        [InlineData(30925)]
        [InlineData(7106)]
        [InlineData(5631)]
        [InlineData(41963)]
        [InlineData(4155)]
        [InlineData(8369)]
        [InlineData(46536)]
        [InlineData(45241)]
        public void ReadU2(ushort value)
        {
            var source = CreateMockDataSource(value);
            var reader = new BigEndianReader(source);

            reader.ReadU2().Should().Be(value);
        }

        [Theory]
        [InlineData(27088)]
        [InlineData(-19455)]
        [InlineData(4782)]
        [InlineData(20499)]
        [InlineData(22090)]
        [InlineData(25967)]
        [InlineData(7176)]
        [InlineData(25595)]
        [InlineData(11787)]
        [InlineData(-31657)]
        public void ReadI2(short value)
        {
            var source = CreateMockDataSource(value);
            var reader = new BigEndianReader(source);

            reader.ReadI2().Should().Be(value);
        }

        [Theory]
        [InlineData(1230418533)]
        [InlineData(280429589)]
        [InlineData(1052808216)]
        [InlineData(1167140917)]
        [InlineData(177031737)]
        [InlineData(2009869557)]
        [InlineData(1024461346)]
        [InlineData(595459387)]
        [InlineData(2896699446)]
        [InlineData(779649052)]
        public void ReadU4(uint value)
        {
            var source = CreateMockDataSource(value);
            var reader = new BigEndianReader(source);

            reader.ReadU4().Should().Be(value);
        }

        [Theory]
        [InlineData(-786995417)]
        [InlineData(-1411413036)]
        [InlineData(1532057845)]
        [InlineData(1523671451)]
        [InlineData(2119078713)]
        [InlineData(142288543)]
        [InlineData(-677526750)]
        [InlineData(240635283)]
        [InlineData(-285350976)]
        [InlineData(-2050937051)]
        public void ReadI4(int value)
        {
            var source = CreateMockDataSource(value);
            var reader = new BigEndianReader(source);

            reader.ReadI4().Should().Be(value);
        }
        
        [Theory]
        [InlineData(5103317310)]
        [InlineData(5483313160)]
        [InlineData(6900380230)]
        [InlineData(469459260)]
        [InlineData(912228980)]
        [InlineData(10694833220)]
        [InlineData(10775215430)]
        [InlineData(1782866100)]
        [InlineData(8098409940)]
        [InlineData(7675846100)]
        public void ReadU8(ulong value)
        {
            var source = CreateMockDataSource(value);
            var reader = new BigEndianReader(source);

            reader.ReadU8().Should().Be(value);
        }

        [Theory]
        [InlineData(-12379946450)]
        [InlineData(-18023475840)]
        [InlineData(1301906690)]
        [InlineData(894226890)]
        [InlineData(378151930)]
        [InlineData(-731513010)]
        [InlineData(-2714355360)]
        [InlineData(15478951920)]
        [InlineData(1013930380)]
        [InlineData(-631530330)]
        public void ReadI8(long value)
        {
            var source = CreateMockDataSource(value);
            var reader = new BigEndianReader(source);

            reader.ReadI8().Should().Be(value);
        }

        [Theory]
        [InlineData(11704518995.4238)]
        [InlineData(-8266237945.29561)]
        [InlineData(-13744395417.6478)]
        [InlineData(1949221753.98332)]
        [InlineData(-4650133693.35379)]
        [InlineData(2382319093.77776)]
        [InlineData(84407087.5732237)]
        [InlineData(-7152360967.02946)]
        [InlineData(-13333915816.205)]
        [InlineData(1635419747.0641)]
        public void ReadR4(float value)
        {
            var source = CreateMockDataSource(value);
            var reader = new BigEndianReader(source);

            reader.ReadR4().Should().Be(value);
        }
        
        [Theory]
        [InlineData(1196991996296.93)]
        [InlineData(1049686036178.47)]
        [InlineData(-90234300638.9919)]
        [InlineData(-488720259010.802)]
        [InlineData(-1487411587475.53)]
        [InlineData(-241508474059.413)]
        [InlineData(-1771580036850.69)]
        [InlineData(752595169442.755)]
        [InlineData(-1646805489926.81)]
        [InlineData(-224630279698.552)]
        public void ReadR8(double value)
        {
            var source = CreateMockDataSource(value);
            var reader = new BigEndianReader(source);

            reader.ReadR8().Should().Be(value);
        }

        private static unsafe IDataSource CreateMockDataSource<T>(T data) where T : unmanaged
        {
            Span<byte> raw = stackalloc byte[sizeof(T)];
            if (sizeof(nint) == 4)
            {
                Unsafe.WriteUnaligned(ref raw[0], data);
            }
            else
            {
                for (int i = 0; i < sizeof(T); i++)
                    raw[raw.Length - i - 1] = *((byte*) &data + i);
            }

            return new BufferDataSource(raw.ToArray());
        }
    }
}