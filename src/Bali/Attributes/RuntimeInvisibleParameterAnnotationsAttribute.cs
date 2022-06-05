using System.Collections.Generic;
using Bali.SourceGeneration;

namespace Bali.Attributes
{
    [AutoReader]
    [AutoWriter]
    public sealed class RuntimeInvisibleParameterAnnotationsAttribute : JvmAttribute
    {
        public RuntimeInvisibleParameterAnnotationsAttribute(ushort nameIndex, IList<IList<AnnotationInfo>> parameterAnnotations)
            : base(nameIndex)
        {
            ParameterAnnotations = parameterAnnotations;
        }
        
        [CustomReaderConverter(@"
            var ParameterAnnotations = new List<IList<AnnotationInfo>>(reader.ReadU1());
            var annotationReader = new AnnotationInfoReader(reader);
            for (int i = 0; i < ParameterAnnotations.Capacity; i++) {
                var annotations = new List<AnnotationInfo>(reader.ReadU2());
                for (int j = 0; j < annotations.Capacity; j++)
                    annotations.Add(annotationReader.ReadAnnotationInfo());
            }"
        )]
        [CustomWriterConverter(@"
            writer.WriteU1((byte) attribute.ParameterAnnotations.Count);
            var annotationWriter = new AnnotationInfoWriter(writer);
            foreach (var parameter in attribute.ParameterAnnotations) {
                writer.WriteU2((ushort) parameter.Count);
                foreach (var annotation in parameter)
                    annotationWriter.WriteAnnotationInfo(annotation);
            }
        ")]
        public IList<IList<AnnotationInfo>> ParameterAnnotations
        {
            get;
            set;
        }
    }
}