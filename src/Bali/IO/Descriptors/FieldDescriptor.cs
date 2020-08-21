namespace Bali.IO.Descriptors
{
    public abstract class FieldDescriptor
    {
        public FieldDescriptor(int arrayRank)
        {
            ArrayRank = arrayRank;
        }

        public int ArrayRank
        {
            get;
        }
    }
}