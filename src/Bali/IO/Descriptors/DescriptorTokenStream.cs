using System;

namespace Bali.IO.Descriptors
{
    /// <summary>
    /// A simple <see cref="DescriptorToken"/> stream that can look ahead by 1 token.
    /// </summary>
    public sealed class DescriptorTokenStream
    {
        private readonly Func<DescriptorToken> _supply;

        private DescriptorToken? _lookahead;

        /// <summary>
        /// Creates a new <see cref="DescriptorTokenStream"/> with the given <paramref name="supply"/> function.
        /// </summary>
        /// <param name="supply">The function that provides new tokens.</param>
        public DescriptorTokenStream(Func<DescriptorToken> supply) => _supply = supply;

        /// <summary>
        /// Advance the token stream to the next token.
        /// </summary>
        /// <returns>The next <see cref="DescriptorToken"/>.</returns>
        public DescriptorToken Next()
        {
            if (_lookahead is null)
                return _supply();
            
            var temp = _lookahead;
            _lookahead = null;
                
            return temp.Value;
        }

        /// <summary>
        /// Previews what the next token will be.
        /// </summary>
        /// <returns>The next token that will be returned by <see cref="Next"/>.</returns>
        public DescriptorToken Lookahead() => _lookahead ?? (_lookahead = _supply()).Value;
    }
}