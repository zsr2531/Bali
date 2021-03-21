using Bali.SourceGeneration;

namespace Bali.Attributes
{
    /// <summary>
    /// An attribute which records generic signature information for any class, interface, constructor
    /// or member whose generic signature in the Java programming language would include
    /// references to type variables or parameterized types.
    /// </summary>
    [AutoReader]
    [AutoWriter]
    public sealed class SignatureAttribute : JvmAttribute
    {
        /// <summary>
        /// Creates a new <see cref="SignatureAttribute"/>.
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the attribute.</param>
        /// <param name="signatureIndex">The index into the <see cref="ConstantPool"/> representing the signature.</param>
        public SignatureAttribute(ushort nameIndex, ushort signatureIndex)
            : base(nameIndex)
        {
            SignatureIndex = signatureIndex;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> representing the signature.
        /// </summary>
        public ushort SignatureIndex
        {
            get;
            set;
        }
    }
}