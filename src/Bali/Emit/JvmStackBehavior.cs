namespace Bali.Emit
{
    /// <summary>
    /// An enumeration representing the stack usage/behavior of a JVM instruction.
    /// </summary>
    public enum JvmStackBehavior : byte
    {
        /// <summary>
        /// The stack is not effected.
        /// </summary>
        Nop,
        
        /// <summary>
        /// The instruction pops 1 item off the stack.
        /// </summary>
        Pop1,
        
        /// <summary>
        /// The instruction pops 2 items off the stack.
        /// </summary>
        Pop2,
        
        /// <summary>
        /// The instruction pops 3 items off the stack.
        /// </summary>
        Pop3,
        
        /// <summary>
        /// The instruction pushes 1 item on the stack.
        /// </summary>
        Push1,
        
        /// <summary>
        /// The instruction pops 1 item off the stack and pushes 1 item on the stack.
        /// </summary>
        Pop1Push1,
        
        /// <summary>
        /// The instruction pops 1 item off the stack and pushes 2 item on the stack.
        /// </summary>
        Pop1Push2,
        
        /// <summary>
        /// The instruction pops 2 item off the stack and pushes 1 item on the stack.
        /// </summary>
        Pop2Push1,
        
        /// <summary>
        /// The instruction pops 2 item off the stack and pushes 2 item on the stack.
        /// </summary>
        Pop2Push2,
        
        /// <summary>
        /// The instruction pops 2 item off the stack and pushes 3 item on the stack.
        /// </summary>
        Pop2Push3,
        
        /// <summary>
        /// The instruction's stack usage is dynamic (ie. depends on the operand).
        /// </summary>
        Var,
        
        /// <summary>
        /// The instruction's stack usage is not defined.
        /// </summary>
        Undefined
    }
}