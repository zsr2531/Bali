using System;
using System.Collections.Generic;
using Bali.IO;

namespace Bali.Attributes.Readers
{
    internal readonly ref struct AnnotationInfoReader
    {
        private readonly IBigEndianReader _reader;

        internal AnnotationInfoReader(IBigEndianReader reader)
        {
            _reader = reader;
        }

        internal AnnotationInfo ReadAnnotationInfo()
        {
            ushort typeIndex = _reader.ReadU2();
            var pairs = new List<(ushort, ElementValue)>(_reader.ReadU2());

            for (int i = 0; i < pairs.Capacity; i++)
                pairs.Add((_reader.ReadU2(), ReadElementValue()));

            return new(typeIndex, pairs);
        }

        private ElementValue ReadElementValue()
        {
            var tag = (ElementValueTag) _reader.ReadU1();
            return tag switch
            {
                ElementValueTag.Byte or ElementValueTag.Char or ElementValueTag.Double
                    or ElementValueTag.Float or ElementValueTag.Integer or ElementValueTag.Long
                    or ElementValueTag.Short or ElementValueTag.Boolean or ElementValueTag.String
                    => ReadConstValue(tag),
                ElementValueTag.Enum => ReadEnumConstValue(tag),
                ElementValueTag.Class => ReadClassInfoValue(tag),
                ElementValueTag.AnnotationType => ReadAnnotationValue(tag),
                ElementValueTag.Array => ReadArrayValue(tag),
                _ => throw new ArgumentOutOfRangeException(nameof(tag))
            };
        }

        private ConstValue ReadConstValue(ElementValueTag tag) => new(tag, _reader.ReadU2());

        private EnumConstValue ReadEnumConstValue(ElementValueTag tag) => new(tag, _reader.ReadU2(), _reader.ReadU2());

        private ClassInfoValue ReadClassInfoValue(ElementValueTag tag) => new(tag, _reader.ReadU2());

        private AnnotationValue ReadAnnotationValue(ElementValueTag tag) => new(tag, ReadAnnotationInfo());

        private ArrayValue ReadArrayValue(ElementValueTag tag)
        {
            var values = new List<ElementValue>(_reader.ReadU2());
            for (int i = 0; i < values.Capacity; i++)
                values.Add(ReadElementValue());

            return new(tag, values);
        }
    }
}