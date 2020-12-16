using System.Collections.Generic;
using Bali.Emit;
using Bali.SourceGeneration;

namespace Bali.Attributes
{
    /// <summary>
    /// An attribute which describes bootstrap method specifiers referenced by <see cref="JvmOpCodes.Invokedynamic"/> instructions.
    /// </summary>
    [AutoFactory]
    [AutoBuilder]
    public sealed class BootstrapMethodsAttribute : JvmAttribute
    {
        /// <summary>
        /// Creates a new <see cref="BootstrapMethodsAttribute"/>.
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the attribute.</param>
        /// <param name="bootstrapMethods">The list of <see cref="BootstrapInfo"/>s.</param>
        public BootstrapMethodsAttribute(ushort nameIndex, IList<BootstrapInfo> bootstrapMethods)
            : base(nameIndex)
        {
            BootstrapMethods = bootstrapMethods;
        }

        /// <summary>
        /// Gets or sets the list of <see cref="BootstrapInfo"/>s.
        /// </summary>
        public IList<BootstrapInfo> BootstrapMethods
        {
            get;
            set;
        }
    }

    /// <summary>
    /// A simple data structure to hold a bootstrap method and its arguments.
    /// </summary>
    public struct BootstrapInfo
    {
        /// <summary>
        /// Creates a new <see cref="BootstrapInfo"/>.
        /// </summary>
        /// <param name="bootstrapMethodHandleIndex">The index into the <see cref="ConstantPool"/> representing the handle of the bootstrap method.</param>
        /// <param name="bootstrapMethodArgumentIndices">The indices into the <see cref="ConstantPool"/> representing the arguments of the method.</param>
        public BootstrapInfo(ushort bootstrapMethodHandleIndex, IList<ushort> bootstrapMethodArgumentIndices)
        {
            BootstrapMethodHandleIndex = bootstrapMethodHandleIndex;
            BootstrapMethodArgumentIndices = bootstrapMethodArgumentIndices;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> representing the handle of the bootstrap method.
        /// </summary>
        public ushort BootstrapMethodHandleIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the indices into the <see cref="ConstantPool"/> representing the arguments of the method.
        /// </summary>
        public IList<ushort> BootstrapMethodArgumentIndices
        {
            get;
            set;
        }
    }
}