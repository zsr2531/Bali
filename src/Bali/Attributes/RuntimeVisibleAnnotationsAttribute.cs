using System.Collections.Generic;
using Bali.SourceGeneration;

namespace Bali.Attributes
{
    [AutoReader]
    [AutoWriter]
    public sealed class RuntimeVisibleAnnotationsAttribute : JvmAttribute
    {
        public RuntimeVisibleAnnotationsAttribute(ushort nameIndex, IList<AnnotationInfo> annotations)
            : base(nameIndex)
        {
            Annotations = annotations;
        }
        
        [CustomReaderConverter(@"
            var Annotations = new List<AnnotationInfo>(reader.ReadU2());
            var annotationReader = new AnnotationInfoReader(reader);
            for (int i = 0; i < Annotations.Capacity; i++)
                Annotations.Add(annotationReader.ReadAnnotationInfo());"
        )]
        [CustomWriterConverter(@"
            writer.WriteU2((ushort) attribute.Annotations.Count);
            var annotationWriter = new AnnotationInfoWriter(writer);
            foreach (var annotation in attribute.Annotations)
                annotationWriter.WriteAnnotationInfo(annotation);
        ")]
        public IList<AnnotationInfo> Annotations
        {
            get;
            set;
        }
    }
}