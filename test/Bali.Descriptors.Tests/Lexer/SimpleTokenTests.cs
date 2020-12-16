using System;
using Xunit;

namespace Bali.Descriptors.Tests.Lexer
{
    public class SimpleTokenTests
    {
        [Theory]
        [InlineData("<<<<<<<", 7)]
        [InlineData("<<", 2)]
        [InlineData("<<<<<<<<<", 9)]
        public void LeftAngledBracket(string input, int leftAngledBrackets) =>
            Commence(input, DescriptorTokenKind.LeftAngledBracket, leftAngledBrackets);

        [Theory]
        [InlineData(">>>>", 4)]
        [InlineData(">", 1)]
        [InlineData(">>>>>>", 6)]
        public void RightAngledBracket(string input, int rightAngledBrackets) =>
            Commence(input, DescriptorTokenKind.RightAngledBracket, rightAngledBrackets);

        [Theory]
        [InlineData("(((", 3)]
        [InlineData("((((((", 6)]
        [InlineData("((((", 4)]
        public void LeftParenthesis(string input, int leftParenthesis) =>
            Commence(input, DescriptorTokenKind.LeftParenthesis, leftParenthesis);

        [Theory]
        [InlineData(")))))))", 7)]
        [InlineData("))", 2)]
        [InlineData(")))))", 5)]
        public void RightParenthesis(string input, int rightParenthesis) =>
            Commence(input, DescriptorTokenKind.RightParenthesis, rightParenthesis);

        [Theory]
        [InlineData("[[[[[[", 6)]
        [InlineData("[", 1)]
        [InlineData("[[[[[[[[", 8)]
        public void LeftBracket(string input, int leftBrackets) =>
            Commence(input, DescriptorTokenKind.LeftBracket, leftBrackets);

        [Theory]
        [InlineData(";;;;;;;;", 8)]
        [InlineData(";;", 2)]
        [InlineData(";;;;;", 5)]
        public void Semicolon(string input, int semicolons) =>
            Commence(input, DescriptorTokenKind.Semicolon, semicolons);

        [Theory]
        [InlineData("/////", 5)]
        [InlineData("///", 3)]
        [InlineData("//////////", 10)]
        public void Slash(string input, int slashes) => Commence(input, DescriptorTokenKind.Slash, slashes);

        private static void Commence(string input, DescriptorTokenKind tokenKind, int tokenKindCount)
        {
            var lexer = new DescriptorLexer(input.AsMemory());
            var tokens = Utils.GetAllTokens(lexer.Lex());
            
            Assert.Equal(1 + tokenKindCount, tokens.Count);
            Assert.All(tokens, token =>
            {
                var type = token.Kind;
                Assert.True(type == tokenKind || type == DescriptorTokenKind.EndOfFile);
            });
        }
    }
}