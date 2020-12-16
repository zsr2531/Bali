using System.Collections.Generic;

namespace Bali.Descriptors.Tests.Lexer
{
    public static class Utils
    {
        public static List<DescriptorToken> GetAllTokens(DescriptorTokenStream stream)
        {
            var tokens = new List<DescriptorToken>();

            while (true)
            {
                var token = stream.Next();
                
                tokens.Add(token);
                
                if (token.Kind == DescriptorTokenKind.EndOfFile)
                    break;
            }

            return tokens;
        }
    }
}