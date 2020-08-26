using System;
using Bali.IO.Descriptors;
using Xunit;

namespace Bali.Descriptors.Tests.Lexer
{
    public class PrimitiveTypeTests
    {
        [Fact]
        public void Byte() => Commence("B", DescriptorTokenKind.Byte);

        [Fact]
        public void Char() => Commence("C", DescriptorTokenKind.Char);

        [Fact]
        public void Double() => Commence("D", DescriptorTokenKind.Double);

        [Fact]
        public void Float() => Commence("F", DescriptorTokenKind.Float);

        [Fact]
        public void Int() => Commence("I", DescriptorTokenKind.Int);

        [Fact]
        public void Long() => Commence("J", DescriptorTokenKind.Long);

        [Fact]
        public void Short() => Commence("S", DescriptorTokenKind.Short);

        [Fact]
        public void Boolean() => Commence("Z", DescriptorTokenKind.Boolean);

        [Fact]
        public void Void() => Commence("V", DescriptorTokenKind.Void);

        private static void Commence(string input, DescriptorTokenKind tokenKind)
        {
            var lexer = new DescriptorLexer(input.AsMemory());
            var tokens = Utils.GetAllTokens(lexer.Lex());
            
            Assert.Equal(2, tokens.Count);
            Assert.True(tokens[0].Kind == tokenKind, $"Expected <{tokenKind}>, but got <{tokens[0].Kind}>.");
        }
    }
}