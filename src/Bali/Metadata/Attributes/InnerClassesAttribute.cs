using System.Collections.Generic;
using Bali.SourceGeneration;

namespace Bali.Metadata.Attributes
{
    /// <summary>
    /// An attribute which describes nested classes of a given class.
    /// </summary>
    [AutoFactory]
    [AutoBuilder]
    public sealed class InnerClassesAttribute : JvmAttribute
    {
        /// <summary>
        /// Creates a new <see cref="InnerClassesAttribute"/>.
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the attribute.</param>
        /// <param name="innerClasses">The <see cref="InnerClassInfo"/>s.</param>
        public InnerClassesAttribute(ushort nameIndex, IList<InnerClassInfo> innerClasses)
            : base(nameIndex)
        {
            InnerClasses = innerClasses;
        }

        /// <summary>
        /// Gets or sets the <see cref="InnerClassInfo"/>s.
        /// </summary>
        public IList<InnerClassInfo> InnerClasses
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Represents information about an inner class and its containing class.
    /// </summary>
    public struct InnerClassInfo
    {
        /// <summary>
        /// Creates a new <see cref="InnerClassInfo"/>.
        /// </summary>
        /// <param name="innerClassIndex">The index into the <see cref="ConstantPool"/> representing the inner class.</param>
        /// <param name="outerClassIndex">The index into the <see cref="ConstantPool"/> representing the outer class.</param>
        /// <param name="innerNameIndex">The index into the <see cref="ConstantPool"/> representing the name of the inner class.</param>
        /// <param name="innerAccessFlags">The <see cref="ClassAccessFlags"/> of the inner class.</param>
        public InnerClassInfo(
            ushort innerClassIndex,
            ushort outerClassIndex,
            ushort innerNameIndex,
            ClassAccessFlags innerAccessFlags)
        {
            InnerClassIndex = innerClassIndex;
            OuterClassIndex = outerClassIndex;
            InnerNameIndex = innerNameIndex;
            InnerAccessFlags = innerAccessFlags;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> representing the inner class.
        /// </summary>
        public ushort InnerClassIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> representing the outer class.
        /// </summary>
        public ushort OuterClassIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> representing the name of the inner class.
        /// </summary>
        public ushort InnerNameIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the <see cref="ClassAccessFlags"/> of the inner class.
        /// </summary>
        public ClassAccessFlags InnerAccessFlags
        {
            get;
            set;
        }
    }
}