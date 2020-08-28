using System;
using Bali.IO.Descriptors;
using Xunit;

namespace Bali.Descriptors.Tests.Lexer
{
    public class PrimitiveTypeTests
    {
        [Fact]
        public void Byte() => Commence("B", DescriptorTokenKind.B);

        [Fact]
        public void Char() => Commence("C", DescriptorTokenKind.C);

        [Fact]
        public void Double() => Commence("D", DescriptorTokenKind.D);

        [Fact]
        public void Float() => Commence("F", DescriptorTokenKind.F);

        [Fact]
        public void Int() => Commence("I", DescriptorTokenKind.I);

        [Fact]
        public void Long() => Commence("J", DescriptorTokenKind.J);

        [Fact]
        public void Short() => Commence("S", DescriptorTokenKind.S);

        [Fact]
        public void Boolean() => Commence("Z", DescriptorTokenKind.Z);

        [Fact]
        public void Void() => Commence("V", DescriptorTokenKind.V);

        [Theory]
        [InlineData("[I", 1, DescriptorTokenKind.I)]
        public void Array(string input, int arrayDimension, DescriptorTokenKind tokenKind)
        {
            var lexer = new DescriptorLexer(input.AsMemory());
            var tokens = Utils.GetAllTokens(lexer.Lex());
            
            Assert.Equal(2 + arrayDimension, tokens.Count);
        }

        private static void Commence(string input, DescriptorTokenKind tokenKind)
        {
            var lexer = new DescriptorLexer(input.AsMemory());
            var tokens = Utils.GetAllTokens(lexer.Lex());
            
            Assert.Equal(2, tokens.Count);
            Assert.True(tokens[0].Kind == tokenKind, $"Expected <{tokenKind}>, but got <{tokens[0].Kind}>.");
        }
    }
}