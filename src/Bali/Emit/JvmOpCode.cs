namespace Bali.Emit
{
    public readonly struct JvmOpCode
    {
        private readonly uint _raw;

        private const uint OperandTypeMask = 0xFFU;
        private const uint OpCodeMask = 0xFFU << 8;
        private const uint FlowControlMask = 0xFFU << 16;
        private const uint StackBehaviorMask = 0xFFU << 24;

        internal JvmOpCode(uint raw) => _raw = raw;

        internal JvmOpCode(
            JvmCode code, JvmStackBehavior stackBehavior, JvmFlowControl flowControl, JvmOperandType operandType)
        {
            _raw = (uint) operandType;
            _raw |= (uint) code << 8;
            _raw |= (uint) flowControl << 16;
            _raw |= (uint) stackBehavior << 24;
        }

        public JvmCode Code => (JvmCode) ((_raw & OpCodeMask) >> 8);

        public JvmStackBehavior StackBehavior => (JvmStackBehavior) ((_raw & StackBehaviorMask) >> 24);
        
        public JvmFlowControl FlowControl => (JvmFlowControl) ((_raw & FlowControlMask) >> 16);

        public JvmOperandType OperandType => (JvmOperandType) (_raw & OperandTypeMask);
    }
}