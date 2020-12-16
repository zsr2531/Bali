using System;
using Xunit;

namespace Bali.Descriptors.Tests.Lexer
{
    public class IdentifierTests
    {
        [Theory]
        [InlineData("java")]
        [InlineData("bali")]
        [InlineData("class")]
        public void ValidIdentifier(string input)
        {
            var lexer = new DescriptorLexer(input.AsMemory());
            var tokens = Utils.GetAllTokens(lexer.Lex());
            
            Assert.Equal(2, tokens.Count);
            Assert.Equal(DescriptorTokenKind.Identifier, tokens[0].Kind);
            Assert.Equal(input, tokens[0].Value.ToString());
        }

        [Fact]
        public void ValidIdentifierButContainsAngledBrackets()
        {
            var lexer = new DescriptorLexer("<init>".AsMemory());
            var tokens = Utils.GetAllTokens(lexer.Lex());
            
            Assert.Equal(4, tokens.Count);
            Assert.True(tokens[0].Kind == DescriptorTokenKind.LeftAngledBracket);
            Assert.True(tokens[1].Kind == DescriptorTokenKind.Identifier);
            Assert.True(tokens[2].Kind == DescriptorTokenKind.RightAngledBracket);
        }
    }
}