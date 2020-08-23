using System.Collections.Generic;

namespace Bali.IO.Descriptors
{
    /// <summary>
    /// Represents a Java method descriptor.
    /// </summary>
    public readonly struct MethodDescriptor
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
        /// The return type for the method.
        /// </summary>
        public FieldDescriptor ReturnType
        {
            get;
        }
        
        /// <summary>
        /// The parameters to the method.
        /// </summary>
        public IList<FieldDescriptor> Parameters
        {
            get;
        }

        /// <inheritdoc />
        public override string ToString() => $"({string.Join("", Parameters)}){ReturnType}";
    }
}