using System.Linq;

namespace Bali.IO.Descriptors
{
    /// <summary>
    /// Represents a <see cref="FieldDescriptor"/> that has a non-primitive type.
    /// </summary>
    public sealed class NonPrimitiveFieldDescriptor : FieldDescriptor
    {
        /// <summary>
        /// Creates a new <see cref="NonPrimitiveFieldDescriptor"/> with the given <paramref name="arrayRank"/>
        /// and <paramref name="className"/>.
        /// </summary>
        /// <param name="arrayRank">The array rank.</param>
        /// <param name="className">The class name, which is the internal form of a type's name.</param>
        public NonPrimitiveFieldDescriptor(int arrayRank, string className)
            : base(arrayRank) => ClassName = className;

        /// <summary>
        /// The internal form of the type's name.
        /// </summary>
        public string ClassName
        {
            get;
        }

        public override string ToString() => $"{string.Join("", Enumerable.Repeat("[", ArrayRank))}L{ClassName};";
    }
}