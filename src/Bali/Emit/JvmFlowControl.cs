namespace Bali.Emit
{
    public enum JvmFlowControl : byte
    {
        Fallthrough,
        
        UnconditionalBranch,
        
        ConditionalBranch,
        
        Throw,
        
        Return,
        
        Undefined
    }
}