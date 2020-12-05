namespace Bali.Metadata.Builders
{
    public interface IJvmAttributeDirector
    {
        IJvmAttributeBuilder this[string name]
        {
            get;
            set;
        }

        void ConstructAttribute(JvmAttribute attribute);
    }
}