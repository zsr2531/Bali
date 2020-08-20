namespace Bali.IO.Descriptors
{
    /// <summary>
    /// The types of tokens that can occur in a Java field/method descriptor.
    /// </summary>
    public enum TokenKind
    {
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
        Byte,
        
        /// <summary>
        /// The character <c>C</c>.
        /// </summary>
        Char,
        
        /// <summary>
        /// The character <c>D</c>.
        /// </summary>
        Double,
        
        /// <summary>
        /// The character <c>F</c>.
        /// </summary>
        Float,
        
        /// <summary>
        /// The character <c>I</c>.
        /// </summary>
        Int,
        
        /// <summary>
        /// The character <c>J</c>.
        /// </summary>
        Long,
        
        /// <summary>
        /// The character <c>S</c>.
        /// </summary>
        Short,
        
        /// <summary>
        /// The character <c>Z</c>.
        /// </summary>
        Boolean,
        
        /// <summary>
        /// The character <c>V</c>.
        /// </summary>
        Void,
        
        /// <summary>
        /// The sequence <c>Lclassname;</c>, where <c>classname</c> is the internal form of a class name.
        /// </summary>
        ClassName,
        
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