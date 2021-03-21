using System.Collections.Generic;
using Bali.SourceGeneration;

namespace Bali.Attributes
{
    /// <summary>
    /// An attribute which provides information about line numbers based on the program counter position.
    /// </summary>
    [AutoReader]
    [AutoWriter]
    public sealed class LineNumberTableAttribute : JvmAttribute
    {
        /// <summary>
        /// Creates a new <see cref="LineNumberTableAttribute"/>.
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the attribute.</param>
        /// <param name="lineNumbers">The list of <see cref="LineNumberInfo"/>s.</param>
        public LineNumberTableAttribute(ushort nameIndex, IList<LineNumberInfo> lineNumbers)
            : base(nameIndex)
        {
            LineNumbers = lineNumbers;
        }
        
        /// <summary>
        /// Gets or sets the list of <see cref="LineNumberInfo"/>s.
        /// </summary>
        public IList<LineNumberInfo> LineNumbers
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Represents the line number at a given offset.
    /// </summary>
    public sealed class LineNumberInfo
    {
        /// <summary>
        /// Creates a new <see cref="LineNumberInfo"/>.
        /// </summary>
        /// <param name="startPc">The program counter position</param>
        /// <param name="lineNumber">The line number.</param>
        public LineNumberInfo(ushort startPc, ushort lineNumber)
        {
            StartPc = startPc;
            LineNumber = lineNumber;
        }

        /// <summary>
        /// Gets or sets the program counter position.
        /// </summary>
        public ushort StartPc
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets the line number.
        /// </summary>
        public ushort LineNumber
        {
            get;
            set;
        }
    }
}