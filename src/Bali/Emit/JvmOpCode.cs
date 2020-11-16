using System;

namespace Bali.Emit
{
    /// <summary>
    /// Represents the opcode of a <see cref="JvmInstruction"/>.
    /// </summary>
    public readonly struct JvmOpCode : IEquatable<JvmOpCode>
    {
        private readonly uint _raw;

        private const uint OpCodeMask = 0xFFU;
        private const uint OperandTypeMask = 0xFFU << 8;
        private const uint FlowControlMask = 0xFFU << 16;
        private const uint StackBehaviorMask = 0xFFU << 24;

        internal JvmOpCode(
            JvmCode code, JvmOperandType operandType, JvmStackBehavior stackBehavior, JvmFlowControl flowControl)
        {
            _raw = (uint) code;
            _raw |= (uint) operandType << 8;
            _raw |= (uint) flowControl << 16;
            _raw |= (uint) stackBehavior << 24;
            
            JvmOpCodes.RawOpCodes[(byte) code] = this;
        }

        /// <summary>
        /// Gets the <see cref="JvmCode"/> of the opcode.
        /// </summary>
        public JvmCode Code => (JvmCode) (_raw & OpCodeMask);

        /// <summary>
        /// Gets the operand's type.
        /// </summary>
        public JvmOperandType OperandType => (JvmOperandType) ((_raw & OperandTypeMask) >> 8);

        /// <summary>
        /// Gets the flow control of the opcode.
        /// </summary>
        public JvmFlowControl FlowControl => (JvmFlowControl) ((_raw & FlowControlMask) >> 16);

        /// <summary>
        /// Gets the stack behavior of the opcode.
        /// </summary>
        public JvmStackBehavior StackBehavior => (JvmStackBehavior) ((_raw & StackBehaviorMask) >> 24);

        /// <inheritdoc />
        public bool Equals(JvmOpCode other) => GetHashCode() == other.GetHashCode();

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is JvmOpCode other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => HashCode.Combine(Code, StackBehavior, FlowControl, OperandType);

        /// <inheritdoc />
        public override string ToString() => $"{Code}";
        
        /// <summary>
        /// Determines whether two <see cref="JvmOpCode"/>s are equal.
        /// </summary>
        /// <param name="left">The left hand side of the comparison.</param>
        /// <param name="right">The right hand side of the comparison.</param>
        /// <returns>Whether the left and right hand side are equal.</returns>
        public static bool operator ==(JvmOpCode left, JvmOpCode right) => left.Equals(right);

        /// <summary>
        /// Determines whether two <see cref="JvmOpCode"/>s are not equal.
        /// </summary>
        /// <param name="left">The left hand side of the comparison.</param>
        /// <param name="right">The right hand side of the comparison.</param>
        /// <returns>Whether the left and right hand side are not equal.</returns>
        public static bool operator !=(JvmOpCode left, JvmOpCode right) => !(left == right);
    }
}