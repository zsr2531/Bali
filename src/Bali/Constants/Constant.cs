namespace Bali.Constants
{
    /// <summary>
    /// A base class for constants in the <see cref="ConstantPool"/>.
    /// </summary>
    public abstract class Constant
    {
        /// <summary>
        /// Initializes the <see cref="Tag"/>.
        /// </summary>
        /// <param name="tag">The <see cref="ConstantKind"/>.</param>
        protected Constant(ConstantKind tag) => Tag = tag;

        /// <summary>
        /// Gets the the type of the constant.
        /// </summary>
        public ConstantKind Tag
        {
            get;
        }
    }
}