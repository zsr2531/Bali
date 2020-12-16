using System.Collections.Generic;
using Bali.Emit;

namespace Bali.Metadata.Attributes
{
    /// <summary>
    /// An attribute which describes a method's body.
    /// </summary>
    public sealed class CodeAttribute : JvmAttribute
    {
        /// <summary>
        /// Creates a new <see cref="CodeAttribute"/>.
        /// </summary>
        /// <param name="nameIndex">The index into the <see cref="ConstantPool"/> representing the name of the attribute.</param>
        /// <param name="maxStack">The maximum depth of the stack during any point during the execution of the method.</param>
        /// <param name="maxLocals">The maximum number of local variables of the method, including the parameters.</param>
        /// <param name="instructions">The list of <see cref="JvmInstruction"/>s.</param>
        /// <param name="exceptionHandlers">The list of <see cref="JvmExceptionHandler"/>s.</param>
        /// <param name="attributes">The list of <see cref="JvmAttribute"/>s.</param>
        public CodeAttribute(
            ushort nameIndex,
            ushort maxStack,
            ushort maxLocals,
            IList<JvmInstruction> instructions,
            IList<JvmExceptionHandler> exceptionHandlers,
            IList<JvmAttribute> attributes)
            : base(nameIndex)
        {
            MaxStack = maxStack;
            MaxLocals = maxLocals;
            Instructions = instructions;
            ExceptionHandlers = exceptionHandlers;
            Attributes = attributes;
        }

        /// <summary>
        /// Gets or sets the maximum depth of the stack during any point during the execution of the method.
        /// </summary>
        public ushort MaxStack
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the maximum number of local variables of the method, including the parameters.
        /// </summary>
        /// <remarks>Variables of type <c>float</c> and <c>double</c> take up 2 slots.</remarks>
        public ushort MaxLocals
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the list of <see cref="JvmInstruction"/>s.
        /// </summary>
        public IList<JvmInstruction> Instructions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the list of <see cref="JvmExceptionHandler"/>s.
        /// </summary>
        public IList<JvmExceptionHandler> ExceptionHandlers
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the list of <see cref="JvmAttribute"/>s.
        /// </summary>
        public IList<JvmAttribute> Attributes
        {
            get;
            set;
        }
    }
}