namespace Bali.Attributes
{
    public enum VerificationInfoTag : byte
    {
        Top = 0,
        Integer = 1,
        Float = 2,
        Long = 3,
        Double = 4,
        Null = 5,
        UninitializedThis = 6,
        Object = 7,
        Uninitialized = 8
    }

    public abstract class VerificationInfoBase
    {
        private protected VerificationInfoBase(VerificationInfoTag tag)
        {
            Tag = tag;
        }
        
        public VerificationInfoTag Tag
        {
            get;
        }
    }

    public sealed class TopVariableInfo : VerificationInfoBase
    {
        public TopVariableInfo()
            : base(VerificationInfoTag.Top)
        {
        }
    }

    public sealed class IntegerVariableInfo : VerificationInfoBase
    {
        public IntegerVariableInfo()
            : base(VerificationInfoTag.Integer)
        {
        }
    }
    
    public sealed class FloatVariableInfo : VerificationInfoBase
    {
        public FloatVariableInfo()
            : base(VerificationInfoTag.Float)
        {
        }
    }
    
    public sealed class LongVariableInfo : VerificationInfoBase
    {
        public LongVariableInfo()
            : base(VerificationInfoTag.Long)
        {
        }
    }
    
    public sealed class DoubleVariableInfo : VerificationInfoBase
    {
        public DoubleVariableInfo()
            : base(VerificationInfoTag.Double)
        {
        }
    }
    
    public sealed class NullVariableInfo : VerificationInfoBase
    {
        public NullVariableInfo()
            : base(VerificationInfoTag.Null)
        {
        }
    }
    
    public sealed class UninitializedThisVariableInfo : VerificationInfoBase
    {
        public UninitializedThisVariableInfo()
            : base(VerificationInfoTag.UninitializedThis)
        {
        }
    }
    
    public sealed class ObjectVariableInfo : VerificationInfoBase
    {
        public ObjectVariableInfo(ushort constantPoolIndex)
            : base(VerificationInfoTag.Object)
        {
            ConstantPoolIndex = constantPoolIndex;
        }
        
        public ushort ConstantPoolIndex
        {
            get;
            set;
        }
    }
    
    public sealed class UninitializedVariableInfo : VerificationInfoBase
    {
        public UninitializedVariableInfo(ushort offset)
            : base(VerificationInfoTag.Uninitialized)
        {
            Offset = offset;
        }
        
        public ushort Offset
        {
            get;
            set;
        }
    }
}