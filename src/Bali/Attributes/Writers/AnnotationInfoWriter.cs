using System;
using Bali.IO;

namespace Bali.Attributes.Writers
{
    internal readonly ref struct AnnotationInfoWriter
    {
        private readonly IBigEndianWriter _writer;

        internal AnnotationInfoWriter(IBigEndianWriter writer)
        {
            _writer = writer;
        }

        internal void WriteAnnotationInfo(AnnotationInfo annotationInfo)
        {
            _writer.WriteU2(annotationInfo.TypeIndex);
            _writer.WriteU2((ushort) annotationInfo.ElementValuePairs.Count);

            foreach ((ushort index, var value) in annotationInfo.ElementValuePairs)
            {
                _writer.WriteU2(index);
                WriteElementValue(value);
            }
        }

        internal void WriteElementValue(ElementValue value)
        {
            _writer.WriteU1((byte) value.Tag);
            
            switch (value)
            {
                case ConstValue constValue:
                    WriteElementValue(constValue);
                    break;

                case EnumConstValue enumConstValue:
                    WriteElementValue(enumConstValue);
                    break;

                case ClassInfoValue classInfoValue:
                    WriteElementValue(classInfoValue);
                    break;
                
                case AnnotationValue annotationValue:
                    WriteElementValue(annotationValue);
                    break;

                case ArrayValue arrayValue:
                    WriteElementValue(arrayValue);
                    break;
            }
        }

        private void WriteElementValue(ConstValue constValue) => _writer.WriteU2(constValue.ConstValueIndex);

        private void WriteElementValue(EnumConstValue enumConstValue)
        {
            _writer.WriteU2(enumConstValue.TypeNameIndex);
            _writer.WriteU2(enumConstValue.ConstNameIndex);
        }

        private void WriteElementValue(ClassInfoValue classInfoValue) => _writer.WriteU2(classInfoValue.ClassInfoIndex);

        private void WriteElementValue(AnnotationValue annotationValue) => WriteAnnotationInfo(annotationValue.Annotation);

        private void WriteElementValue(ArrayValue arrayValue)
        {
            _writer.WriteU2((ushort) arrayValue.Values.Count);
            foreach (var value in arrayValue.Values)
                WriteElementValue(value);
        }
    }
}