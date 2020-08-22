using System.Collections.Generic;

namespace Bali.IO.Descriptors
{
    public readonly struct MethodDescriptor
    {
        public MethodDescriptor(FieldDescriptor returnType, IList<FieldDescriptor> parameters)
        {
            ReturnType = returnType;
            Parameters = parameters;
        }

        public FieldDescriptor ReturnType
        {
            get;
        }
        
        public IList<FieldDescriptor> Parameters
        {
            get;
        }

        public override string ToString() => $"({string.Join("", Parameters)}){ReturnType}";
    }
}