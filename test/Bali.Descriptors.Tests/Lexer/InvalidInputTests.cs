using System;
using Xunit;

namespace Bali.Descriptors.Tests.Lexer
{
    public class InvalidInputTests
    {
        [Fact]
        public void EmptyInput()
        {
            var lexer = new DescriptorLexer("".AsMemory());
            
            Assert.Throws<ArgumentException>(() => lexer.Lex());
        }
    }
}