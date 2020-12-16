namespace Bali.Descriptors
{
    /// <summary>
    /// The types of tokens that can occur in a Java field/method descriptor.
    /// </summary>
    public enum DescriptorTokenKind
    {
        /// <summary>
        /// The character <c>&lt;</c>.
        /// </summary>
        LeftAngledBracket,
        
        /// <summary>
        /// The character <c>></c>.
        /// </summary>
        RightAngledBracket,
        
        /// <summary>
        /// The character <c>(</c>.
        /// </summary>
        LeftParenthesis,
        
        /// <summary>
        /// The character <c>)</c>.
        /// </summary>
        RightParenthesis,
        
        /// <summary>
        /// The character <c>[</c>.
        /// </summary>
        LeftBracket,
        
        /// <summary>
        /// The character <c>B</c>.
        /// </summary>
        B,
        
        /// <summary>
        /// The character <c>C</c>.
        /// </summary>
        C,
        
        /// <summary>
        /// The character <c>D</c>.
        /// </summary>
        D,
        
        /// <summary>
        /// The character <c>F</c>.
        /// </summary>
        F,
        
        /// <summary>
        /// The character <c>I</c>.
        /// </summary>
        I,
        
        /// <summary>
        /// The character <c>J</c>.
        /// </summary>
        J,
        
        /// <summary>
        /// The character <c>S</c>.
        /// </summary>
        S,
        
        /// <summary>
        /// The character <c>Z</c>.
        /// </summary>
        Z,
        
        /// <summary>
        /// The character <c>V</c>.
        /// </summary>
        V,
        
        /// <summary>
        /// The character <c>L</c>.
        /// </summary>
        L,
        
        /// <summary>
        /// The character <c>;</c>.
        /// </summary>
        Semicolon,
        
        /// <summary>
        /// The character <c>/</c>.
        /// </summary>
        Slash,
        
        /// <summary>
        /// A valid unqualified name.
        /// An unqualified name must not contain any of the ASCII characters <c>. ; [ /</c>.
        /// </summary>
        /// <remarks>
        /// Method names are further constrained so that, with the exception of the special method names
        /// <c>&lt;init></c> and <c>&lt;clinit></c> (§2.9), they must not contain the ASCII characters
        /// <c>&lt;</c> or <c>></c>.
        /// </remarks>
        Identifier,
        
        /// <summary>
        /// Indicates a bad token.
        /// </summary>
        Bad,
        
        /// <summary>
        /// Indicates that the end of the input has been reached.
        /// </summary>
        EndOfFile,
    }
}