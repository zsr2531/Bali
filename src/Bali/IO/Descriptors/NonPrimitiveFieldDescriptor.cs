namespace Bali.IO.Descriptors
{
    public sealed class NonPrimitiveFieldDescriptor : FieldDescriptor
    {
        public NonPrimitiveFieldDescriptor(int arrayRank, string className)
            : base(arrayRank) => ClassName = className;

        public string ClassName
        {
            get;
        }
    }
}