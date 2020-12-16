using System;
using System.Collections.Generic;
using System.Linq;

namespace Bali.Descriptors
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
        /// <param name="genericParameters">The generic type parameters.</param>
        public NonPrimitiveFieldDescriptor(int arrayRank, string className, IReadOnlyList<FieldDescriptor> genericParameters)
            : base(arrayRank)
        {
            ClassName = className;
            GenericParameters = genericParameters;
        }

        /// <summary>
        /// The internal form of the type's name.
        /// </summary>
        public string ClassName
        {
            get;
        }

        /// <summary>
        /// The generic type parameters to the <see cref="FieldDescriptor"/>.
        /// </summary>
        public IReadOnlyList<FieldDescriptor> GenericParameters
        {
            get;
        }
        
        /// <inheritdoc />
        public override bool Equals(FieldDescriptor? other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return GetHashCode() == other.GetHashCode();
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (!(obj is FieldDescriptor other))
                return false;

            return Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode() => HashCode.Combine(ArrayRank, ClassName);

        /// <inheritdoc />
        public override string ToString() =>
            $"{string.Join("", Enumerable.Repeat("[", ArrayRank))}L{ClassName}{(GenericParameters.Count == 0 ? "" : $"<{string.Join("", GenericParameters)}>")};";
    }
}