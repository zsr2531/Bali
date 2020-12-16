using System;
using Bali.Attributes;

// GetHashCode not overriden... blah blah blah
#pragma warning disable 660,661,659

namespace Bali.Emit
{
    /// <summary>
    /// Represents a JVM instruction in a method's <see cref="CodeAttribute"/>.
    /// </summary>
    public sealed class JvmInstruction : IEquatable<JvmInstruction>
    {
        /// <summary>
        /// Creates a new <see cref="JvmInstruction"/>.
        /// </summary>
        /// <param name="opCode">The <see cref="JvmOpCode"/> of the instruction.</param>
        /// <param name="operand">The instruction's operand.</param>
        public JvmInstruction(JvmOpCode opCode, object? operand = null)
            : this(-1, opCode, operand)
        {
        }

        /// <summary>
        /// Creates a new <see cref="JvmInstruction"/>.
        /// </summary>
        /// <param name="offset">The offset to the instruction from the start of the method body.</param>
        /// <param name="opCode">The <see cref="JvmOpCode"/> of the instruction.</param>
        /// <param name="operand">The instruction's operand.</param>
        public JvmInstruction(int offset, JvmOpCode opCode, object? operand = null)
        {
            Offset = offset;
            OpCode = opCode;
            Operand = operand;
        }

        /// <summary>
        /// Gets the offset of the instruction in the method body.
        /// </summary>
        public int Offset
        {
            get;
        }
                
        /// <summary>
        /// Gets or sets the opcode of the instruction.
        /// </summary>
        public JvmOpCode OpCode
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets the operand of the instruction.
        /// </summary>
        public object? Operand
        {
            get;
            set;
        }
        
        /// <inheritdoc />
        public bool Equals(JvmInstruction other) => OpCode == other.OpCode && Equals(Operand, other.Operand);
        
        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is JvmInstruction instruction && Equals(instruction);
        
        /// <inheritdoc />
        public override string ToString() => $"{OpCode}{(Operand is null ? "" : " ")}{Operand}";
        
        /// <summary>
        /// Determines whether two <see cref="JvmInstruction"/>s are equal.
        /// </summary>
        /// <param name="left">The left hand side of the comparison.</param>
        /// <param name="right">The right hand side of the comparison.</param>
        /// <returns>Whether the left and right hand side are equal.</returns>
        public static bool operator ==(JvmInstruction left, JvmInstruction right) => Equals(left, right);

        /// <summary>
        /// Determines whether two <see cref="JvmInstruction"/>s are not equal.
        /// </summary>
        /// <param name="left">The left hand side of the comparison.</param>
        /// <param name="right">The right hand side of the comparison.</param>
        /// <returns>Whether the left and right hand side are not equal.</returns>
        public static bool operator !=(JvmInstruction left, JvmInstruction right) => !(left == right);
    }
}