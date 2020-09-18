namespace Bali.Emit
{
    public enum JvmOperandType : byte
    {
        None,
        
        Byte,
        Short,
        
        ConstantIndex,
        WideConstantIndex,
        
        LocalIndex,
        LocalConst,
        
        BranchOffset,
        WideBranchOffset,
        
        TableSwitch,
        LookupSwitch,
        
        WideIndexCountZero,
        WideIndexByte,
        
        PrimitiveType,
        
        FieldIndex,
        MethodIndex,
        ClassIndex,

        DynamicIndex
    }
}