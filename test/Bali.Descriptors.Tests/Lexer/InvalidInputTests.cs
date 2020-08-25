using System;
using Bali.IO.Descriptors;
using Xunit;

namespace Bali.Descriptors.Tests.Lexer
{
    public class InvalidInputTests
    {
        [Theory]
        [InlineData("123")]
        [InlineData("{}")]
        [InlineData(",.@.")]
        [InlineData("asdasdl;")]
        [InlineData("<>u931082")]
        [InlineData("hfds';lasfd")]
        [InlineData("bfjdks9132")]
        [InlineData("78tgfs89yu  ast7")]
        [InlineData("   y79223")]
        [InlineData("\n\n\n\n")]
        public void BadToken(string input)
        {
            var lexer = new DescriptorLexer(input.AsMemory());
            var tokens = Utils.GetAllTokens(lexer.Lex());
            
            Assert.All(tokens, token =>
            {
                if (token.Kind == DescriptorTokenKind.EndOfFile)
                    return;

                string failMessage = $"Valid token encountered in input '{input}': {token}";
                Assert.True(token.Kind == DescriptorTokenKind.Bad, failMessage);
            });
        }

        [Fact]
        public void UnmatchedClassName()
        {
            var lexer = new DescriptorLexer("Ljava/lang/Object".AsMemory());
            var tokens = Utils.GetAllTokens(lexer.Lex());
            
            Assert.True(tokens.Count == 2);
            Assert.True(tokens[0].Kind == DescriptorTokenKind.Bad);
        }
    }
}