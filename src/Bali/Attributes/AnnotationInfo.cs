using System;
using System.Collections.Generic;

namespace Bali.Attributes
{
    /// <summary>
    /// Represents a single run-time visible annotation on a program element.
    /// </summary>
    public sealed class AnnotationInfo
    {
        /// <summary>
        /// Creates a new <see cref="AnnotationInfo"/>.
        /// </summary>
        /// <param name="typeIndex">The index into the <see cref="ConstantPool"/> representing a field descriptor representing the annotation type.</param>
        /// <param name="elementValuePairs">The list of element-value pairs.</param>
        public AnnotationInfo(ushort typeIndex, IList<(ushort ElementNameIndex, ElementValue Value)> elementValuePairs)
        {
            TypeIndex = typeIndex;
            ElementValuePairs = elementValuePairs;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/>
        /// representing a field descriptor representing the annotation type.
        /// </summary>
        public ushort TypeIndex
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets the list of element-value pairs where
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// ElementNameIndex: An index into the <see cref="ConstantPool"/> representing a valid field descriptor
        /// denoting the name of the annotation type.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Value: The <see cref="ElementValue"/> of the pair.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        public IList<(ushort ElementNameIndex, ElementValue Value)> ElementValuePairs
        {
            get;
            set;
        }
    }

    /// <summary>
    /// An enumeration of all types of <see cref="ElementValue"/>s.
    /// </summary>
    public enum ElementValueTag : byte
    {
        /// <summary>
        /// Indicates that the <see cref="ElementValue"/> is a <see cref="ConstValue"/> with type <c>byte</c>.
        /// </summary>
        Byte = (byte) 'B',

        /// <summary>
        /// Indicates that the <see cref="ElementValue"/> is a <see cref="ConstValue"/> with type <c>char</c>.
        /// </summary>
        Char = (byte) 'C',

        /// <summary>
        /// Indicates that the <see cref="ElementValue"/> is a <see cref="ConstValue"/> with type <c>double</c>.
        /// </summary>
        Double = (byte) 'D',

        /// <summary>
        /// Indicates that the <see cref="ElementValue"/> is a <see cref="ConstValue"/> with type <c>float</c>.
        /// </summary>
        Float = (byte) 'F',

        /// <summary>
        /// Indicates that the <see cref="ElementValue"/> is a <see cref="ConstValue"/> with type <c>int</c>.
        /// </summary>
        Integer = (byte) 'I',

        /// <summary>
        /// Indicates that the <see cref="ElementValue"/> is a <see cref="ConstValue"/> with type <c>long</c>.
        /// </summary>
        Long = (byte) 'L',

        /// <summary>
        /// Indicates that the <see cref="ElementValue"/> is a <see cref="ConstValue"/> with type <c>short</c>.
        /// </summary>
        Short = (byte) 'S',

        /// <summary>
        /// Indicates that the <see cref="ElementValue"/> is a <see cref="ConstValue"/> with type <c>boolean</c>.
        /// </summary>
        Boolean = (byte) 'Z',

        /// <summary>
        /// Indicates that the <see cref="ElementValue"/> is a <see cref="ConstValue"/> with type <c>String</c>.
        /// </summary>
        String = (byte) 's',

        /// <summary>
        /// Indicates that the <see cref="ElementValue"/> is a <see cref="EnumConstValue"/>.
        /// </summary>
        Enum = (byte) 'e',

        /// <summary>
        /// Indicates that the <see cref="ElementValue"/> is a <see cref="ClassInfoValue"/>.
        /// </summary>
        Class = (byte) 'c',

        /// <summary>
        /// Indicates that the <see cref="ElementValue"/> an <see cref="AnnotationValue"/>.
        /// </summary>
        AnnotationType = (byte) '@',

        /// <summary>
        /// Indicates that the <see cref="ElementValue"/> is an <see cref="ArrayValue"/>.
        /// </summary>
        Array = (byte) '['
    }

    /// <summary>
    /// Provides a contract for annotation element values.
    /// </summary>
    public abstract class ElementValue
    {
        private protected ElementValue(ElementValueTag tag)
        {
            Tag = tag;
        }

        /// <summary>
        /// Gets the <see cref="ElementValueTag"/>.
        /// </summary>
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