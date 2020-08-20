namespace Bali.IO.Descriptors
{
    /// <summary>
    /// A simple data structure to represent the point at which a particular <see cref="Token"/> starts and ends.
    /// </summary>
    public readonly struct TextSpan
    {
        /// <summary>
        /// Creates a new <see cref="TextSpan"/>.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        public TextSpan(int start, int end)
        {
            Start = start;
            End = end;
        }

        /// <summary>
        /// The index at which the token begins on the source text.
        /// </summary>
        public int Start
        {
            get;
        }
        
        /// <summary>
        /// The index at which the token ends in the source text.
        /// </summary>
        public int End
        {
            get;
        }
    }
}