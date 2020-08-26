using System;
using System.Linq;
using Bali.IO.Descriptors;
using Xunit;

namespace Bali.Descriptors.Tests.Lexer
{
    public class ClassNameTests
    {
        [Theory]
        [InlineData("Ljava/lang/Object;")]
        [InlineData("Ljava/lang/String;")]
        [InlineData("Lcom/my/company/Main;")]
        public void Normal(string input)
        {
            var lexer = new DescriptorLexer(input.AsMemory());
            var tokens = Utils.GetAllTokens(lexer.Lex());
            
            Assert.Equal(2, tokens.Count);
            Assert.True(tokens[0].Value.ToString() == input);
            Assert.Equal(DescriptorTokenKind.ClassName, tokens[0].Kind);
        }

        [Theory]
        [InlineData("[Ljava/lang/String;", 1)]
        [InlineData("[[[[Ljava/lang/Integer;", 4)]
        [InlineData("[[Lcom/my/company/contracts/IStringReturner;", 2)]
        public void Array(string input, int arrayDimension)
        {
            var lexer = new DescriptorLexer(input.AsMemory());
            var tokens = Utils.GetAllTokens(lexer.Lex());
            
            Assert.Equal(2 + arrayDimension, tokens.Count);
            Assert.Equal(arrayDimension, tokens.Count(t => t.Kind == DescriptorTokenKind.LeftBracket));
            Assert.Equal(DescriptorTokenKind.ClassName, tokens[arrayDimension].Kind);
        }
    }
}