using System;
using System.Collections.Generic;
using System.Linq;

namespace Bali.IO.Descriptors
{
    /// <summary>
    /// Represents a Java method descriptor.
    /// </summary>
    public readonly struct MethodDescriptor : IEquatable<MethodDescriptor>
    {
        /// <summary>
        /// Creates a new <see cref="MethodDescriptor"/>.
        /// </summary>
        /// <param name="returnType">The method's return type.</param>
        /// <param name="parameters">The method's parameters.</param>
        public MethodDescriptor(FieldDescriptor returnType, IList<FieldDescriptor> parameters)
        {
            ReturnType = returnType;
            Parameters = parameters;
        }

        /// <summary>
        /// The return type of the method.
        /// </summary>
        public FieldDescriptor ReturnType
        {
            get;
        }
        
        /// <summary>
        /// The parameters of the method.
        /// </summary>
        public IList<FieldDescriptor> Parameters
        {
            get;
        }

        /// <inheritdoc />
        public bool Equals(MethodDescriptor other) =>
            ReturnType.Equals(other.ReturnType) && Parameters.SequenceEqual(other.Parameters);

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is MethodDescriptor other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => Parameters.Aggregate(ReturnType.GetHashCode(), HashCode.Combine);
        

        /// <inheritdoc />
        public override string ToString() => $"({string.Join("", Parameters)}){ReturnType}";

        /// <summary>
        /// Determines whether <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </summary>
        /// <param name="left">The left side of the comparison.</param>
        /// <param name="right">The right side of the comparison.</param>
        /// <returns>Whether <paramref name="left"/> and <paramref name="right"/> are equal.</returns>
        public static bool operator ==(MethodDescriptor left, MethodDescriptor right) => left.Equals(right);

        /// <summary>
        /// Determines whether <paramref name="left"/> and <paramref name="right"/> are not equal.
        /// </summary>
        /// <param name="left">The left side of the comparison.</param>
        /// <param name="right">The right side of the comparison.</param>
        /// <returns>Whether <paramref name="left"/> and <paramref name="right"/> are not equal.</returns>
        public static bool operator !=(MethodDescriptor left, MethodDescriptor right) => !left.Equals(right);
    }
}