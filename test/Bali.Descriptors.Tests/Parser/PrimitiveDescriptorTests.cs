using System;
using Bali.IO.Descriptors;
using Xunit;

namespace Bali.Descriptors.Tests.Parser
{
    public class PrimitiveDescriptorTests
    {
        [Theory]
        [InlineData("B", PrimitiveKind.Byte)]
        [InlineData("Z", PrimitiveKind.Boolean)]
        [InlineData("C", PrimitiveKind.Char)]
        [InlineData("S", PrimitiveKind.Short)]
        [InlineData("I", PrimitiveKind.Int)]
        [InlineData("J", PrimitiveKind.Long)]
        [InlineData("F", PrimitiveKind.Float)]
        [InlineData("D", PrimitiveKind.Double)]
        [InlineData("V", PrimitiveKind.Void)]
        public void Normal(string input, PrimitiveKind primitiveKind)
        {
            var lexer = new DescriptorLexer(input.AsMemory());
            var parser = new FieldDescriptorParser(lexer.Lex());
            var descriptor = parser.Parse();

            Assert.Equal(0, descriptor.ArrayRank);
            Assert.Equal(primitiveKind, Assert.IsType<PrimitiveFieldDescriptor>(descriptor).Kind);
        }

        [Theory]
        [InlineData("[B", 1, PrimitiveKind.Byte)]
        [InlineData("[[[B", 3, PrimitiveKind.Byte)]
        [InlineData("[Z", 1, PrimitiveKind.Boolean)]
        [InlineData("[[[Z", 3, PrimitiveKind.Boolean)]
        [InlineData("[C", 1, PrimitiveKind.Char)]
        [InlineData("[[[C", 3, PrimitiveKind.Char)]
        [InlineData("[S", 1, PrimitiveKind.Short)]
        [InlineData("[[[S", 3, PrimitiveKind.Short)]
        [InlineData("[I", 1, PrimitiveKind.Int)]
        [InlineData("[[[I", 3, PrimitiveKind.Int)]
        [InlineData("[J", 1, PrimitiveKind.Long)]
        [InlineData("[[[J", 3, PrimitiveKind.Long)]
        [InlineData("[F", 1, PrimitiveKind.Float)]
        [InlineData("[[[F", 3, PrimitiveKind.Float)]
        [InlineData("[D", 1, PrimitiveKind.Double)]
        [InlineData("[[[D", 3, PrimitiveKind.Double)]
        [InlineData("[V", 1, PrimitiveKind.Void)]
        [InlineData("[[[V", 3, PrimitiveKind.Void)]
        public void Array(string input, int arrayRank, PrimitiveKind primitiveKind)
        {
            var lexer = new DescriptorLexer(input.AsMemory());
            var parser = new FieldDescriptorParser(lexer.Lex());
            var descriptor = parser.Parse();
            
            Assert.Equal(arrayRank, descriptor.ArrayRank);
            Assert.Equal(primitiveKind, Assert.IsType<PrimitiveFieldDescriptor>(descriptor).Kind);
        }
    }
}