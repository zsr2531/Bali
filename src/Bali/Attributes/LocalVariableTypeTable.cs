using System.Collections.Generic;
using Bali.SourceGeneration;

namespace Bali.Attributes
{
    /// <summary>
    /// An attribute which provides information about local variables based in the program counter position.
    /// </summary>
    [AutoReader]
    [AutoWriter]
    public sealed class LocalVariableTypeTable : JvmAttribute
    {
        /// <summary>
        /// Creates a new <see cref="LocalVariableTypeTable"/> .
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the attribute.</param>
        /// <param name="variableTypeInfos">The list of <see cref="LocalVariableTypeInfo"/>s.</param>
        public LocalVariableTypeTable(ushort nameIndex, IList<LocalVariableTypeInfo> variableTypeInfos)
            : base(nameIndex)
        {
            VariableTypeInfos = variableTypeInfos;
        }

        /// <summary>
        /// Gets or set the list of <see cref="LocalVariableTypeInfo"/>s. 
        /// </summary>
        public IList<LocalVariableTypeInfo> VariableTypeInfos
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Indicates a range of code array offsets within which a local variable has a value.
    /// It also indicates the index into the local variable array of the current frame at which that local variable can be found.
    /// </summary>
    public sealed class LocalVariableTypeInfo
    {
        /// <summary>
        /// Creates a new <see cref="LocalVariableTypeInfo"/>.
        /// </summary>
        /// <param name="startPc">The program counter position.</param>
        /// <param name="length">Length of the code array range.</param>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> denoting a local variable.</param>
        /// <param name="signatureIndex">The index into the <see cref="ConstantPool"/> representing a field type signature.</param>
        /// <param name="index">The index of a local variable.</param>
        public LocalVariableTypeInfo(ushort startPc, ushort length, ushort nameIndex, ushort signatureIndex, ushort index)
        {
            StartPc = startPc;
            Length = length;
            NameIndex = nameIndex;
            SignatureIndex = signatureIndex;
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
        /// Gets or sets the signature index.
        /// </summary>
        public ushort SignatureIndex
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