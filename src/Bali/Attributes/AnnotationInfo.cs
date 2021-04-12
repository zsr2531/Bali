using System;
using System.Collections.Generic;

namespace Bali.Attributes
{
    public sealed class AnnotationInfo
    {
        public AnnotationInfo(ushort typeIndex, IList<(ushort ElementNameIndex, ElementValue Value)> elementValuePairs)
        {
            TypeIndex = typeIndex;
            ElementValuePairs = elementValuePairs;
        }

        public ushort TypeIndex
        {
            get;
            set;
        }
        
        public IList<(ushort ElementNameIndex, ElementValue Value)> ElementValuePairs
        {
            get;
            set;
        }
    }

    public enum ElementValueTag : byte
    {
        Byte = (byte) 'B',
        Char = (byte) 'C',
        Double = (byte) 'D',
        Float = (byte) 'F',
        Integer = (byte) 'I',
        Long = (byte) 'L',
        Short = (byte) 'S',
        Boolean = (byte) 'Z',
        
        String = (byte) 's',
        Enum = (byte) 'e',
        Class = (byte) 'c',
        AnnotationType = (byte) '@',
        Array = (byte) '['
    }

    public abstract class ElementValue
    {
        private protected ElementValue(ElementValueTag tag)
        {
            Tag = tag;
        }

        public ElementValueTag Tag
        {
            get;
        }
    }
    
    public sealed class ConstValue : ElementValue
    {
        public ConstValue(ElementValueTag tag, ushort constValueIndex)
            : base(tag)
        {
            if (tag is not ElementValueTag.Byte and not ElementValueTag.Char and not ElementValueTag.Double
                and not ElementValueTag.Float and not ElementValueTag.Integer and not ElementValueTag.Long
                and not ElementValueTag.Short and not ElementValueTag.Boolean and not ElementValueTag.String)
                throw new ArgumentOutOfRangeException(nameof(tag));
            
            ConstValueIndex = constValueIndex;
        }
        
        public ushort ConstValueIndex
        {
            get;
            set;
        }
    }
    
    public sealed class EnumConstValue : ElementValue
    {
        public EnumConstValue(ElementValueTag tag, ushort typeNameIndex, ushort constNameIndex)
            : base(tag)
        {
            if (tag is not ElementValueTag.Enum)
                throw new ArgumentOutOfRangeException(nameof(tag));
            
            TypeNameIndex = typeNameIndex;
            ConstNameIndex = constNameIndex;
        }
        
        public ushort TypeNameIndex
        {
            get;
            set;
        }
        
        public ushort ConstNameIndex
        {
            get;
            set;
        }
    }
    
    public sealed class ClassInfoValue : ElementValue
    {
        public ClassInfoValue(ElementValueTag tag, ushort classInfoIndex)
            : base(tag)
        {
            if (tag is not ElementValueTag.Class)
                throw new ArgumentOutOfRangeException(nameof(tag));
            
            ClassInfoIndex = classInfoIndex;
        }
        
        public ushort ClassInfoIndex
        {
            get;
            set;
        }
    }
    
    public sealed class AnnotationValue : ElementValue
    {
        public AnnotationValue(ElementValueTag tag, AnnotationInfo annotation)
            : base(tag)
        {
            if (tag is not ElementValueTag.AnnotationType)
                throw new ArgumentOutOfRangeException(nameof(tag));
            
            Annotation = annotation;
        }
        
        public AnnotationInfo Annotation
        {
            get;
            set;
        }
    }
    
    public sealed class ArrayValue : ElementValue
    {
        public ArrayValue(ElementValueTag tag, IList<ElementValue> values)
            : base(tag)
        {
            if (tag is not ElementValueTag.Array)
                throw new ArgumentOutOfRangeException(nameof(tag));
            
            Values = values;
        }
        
        public IList<ElementValue> Values
        {
            get;
            set;
        }
    }
}