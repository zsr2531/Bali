using Bali.SourceGeneration;

namespace Bali.Attributes
{
    [AutoReader]
    [AutoWriter]
    public sealed class AnnotationDefaultAttribute : JvmAttribute
    {
        public AnnotationDefaultAttribute(ushort nameIndex, ElementValue defaultValue)
            : base(nameIndex)
        {
            DefaultValue = defaultValue;
        }
        
        [CustomReaderConverter(@"
            var annotationReader = new AnnotationInfoReader(reader);
            var DefaultValue = annotationReader.ReadElementValue();
        ")]
        [CustomWriterConverter(@"
            var annotationWriter = new AnnotationInfoWriter(writer);
            annotationWriter.WriteElementValue(attribute.DefaultValue);
        ")]
        public ElementValue DefaultValue
        {
            get;
            set;
        }
    }
}