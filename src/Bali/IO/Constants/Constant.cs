namespace Bali.IO.Constants
{
    public abstract class Constant
    {
        protected Constant(ConstantKind tag) => Tag = tag;

        public ConstantKind Tag
        {
            get;
        }
    }
}