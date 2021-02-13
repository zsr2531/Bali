using System.Collections.Generic;
using Bali.SourceGeneration;

namespace Bali.Attributes
{
    /// <summary>
    /// An attribute which provides information about local variables based in the program counter position.
    /// </summary>
    [AutoReader]
    [AutoWriter]
    public sealed class LocalVariableTableAttribute : JvmAttribute
    {
        /// <summary>
        /// Creates a new <see cref="LocalVariableTableAttribute"/> .
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the attribute.</param>
        /// <param name="variableInfos">The list of <see cref="LocalVariableInfo"/>s.</param>
        public LocalVariableTableAttribute(ushort nameIndex, IList<LocalVariableInfo> variableInfos)
            : base(nameIndex)
        {
            VariableInfos = variableInfos;
        }

        /// <summary>
        /// Gets or set the list of <see cref="LocalVariableInfo"/>s. 
        /// </summary>
        public IList<LocalVariableInfo> VariableInfos
        {
            get;
            set;
        }
    }
    
    /// <summary>
    /// Indicates a range of code array offsets within which a local variable has a value.
    /// It also indicates the index into the local variable array of the current frame at which that local variable can be found.
    /// </summary>
    public struct LocalVariableInfo
    {
        /// <summary>
        /// Creates a new <see cref="LocalVariableInfo"/>.
        /// </summary>
        /// <param name="startPc">The program counter position.</param>
        /// <param name="length">Length of the code array range.</param>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> denoting a local variable.</param>
        /// <param name="descriptorIndex">The index into the <see cref="ConstantPool"/> representing a field descriptor.</param>
        /// <param name="index">The index of a local variable.</param>
        public LocalVariableInfo(ushort startPc, ushort length, ushort nameIndex, ushort descriptorIndex, ushort index)
        {
            StartPc = startPc;
            Length = length;
            NameIndex = nameIndex;
            DescriptorIndex = descriptorIndex;
            Index = index;
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
        /// Gets or sets the exclusive upper bound of the code array.
        /// </summary>
        public ushort Length
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name index.
        /// </summary>
        public ushort NameIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the descriptor index.
        /// </summary>
        public ushort DescriptorIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the local index.
        /// </summary>
        public ushort Index
        {
            get;
            set;
        }
    }
}