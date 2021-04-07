using Bali.Constants;
using Bali.Emit;

namespace Bali.Attributes
{
    /// <summary>
    /// An enumeration of all types of <see cref="VerificationInfo"/>s.
    /// </summary>
    public enum VerificationInfoTag : byte
    {
        /// <summary>
        /// Indicates that the <see cref="VerificationInfo"/> is a <see cref="TopVariableInfo"/>.
        /// </summary>
        Top = 0,
        
        /// <summary>
        /// Indicates that the <see cref="VerificationInfo"/> is an <see cref="IntegerVariableInfo"/>.
        /// </summary>
        Integer = 1,
        
        /// <summary>
        /// Indicates that the <see cref="VerificationInfo"/> is a <see cref="FloatVariableInfo"/>.
        /// </summary>
        Float = 2,
        
        /// <summary>
        /// Indicates that the <see cref="VerificationInfo"/> is a <see cref="LongVariableInfo"/>.
        /// </summary>
        Long = 3,
        
        /// <summary>
        /// Indicates that the <see cref="VerificationInfo"/> is a <see cref="DoubleVariableInfo"/>.
        /// </summary>
        Double = 4,
        
        /// <summary>
        /// Indicates that the <see cref="VerificationInfo"/> is a <see cref="NullVariableInfo"/>.
        /// </summary>
        Null = 5,
        
        /// <summary>
        /// Indicates that the <see cref="VerificationInfo"/> is an <see cref="UninitializedThisVariableInfo"/>.
        /// </summary>
        UninitializedThis = 6,
        
        /// <summary>
        /// Indicates that the <see cref="VerificationInfo"/> is an <see cref="ObjectVariableInfo"/>.
        /// </summary>
        Object = 7,
        
        /// <summary>
        /// Indicates that the <see cref="VerificationInfo"/> is an <see cref="UninitializedVariableInfo"/>.
        /// </summary>
        Uninitialized = 8
    }

    /// <summary>
    /// Provides a contract for verification types.
    /// </summary>
    public abstract class VerificationInfo
    {
        private protected VerificationInfo(VerificationInfoTag tag)
        {
            Tag = tag;
        }
        
        /// <summary>
        /// Gets the <see cref="VerificationInfoTag"/>.
        /// </summary>
        public VerificationInfoTag Tag
        {
            get;
        }
    }

    /// <summary>
    /// Indicates that the verification type is <c>top</c>.
    /// </summary>
    public sealed class TopVariableInfo : VerificationInfo
    {
        /// <summary>
        /// Creates a new <see cref="TopVariableInfo"/>.
        /// </summary>
        public TopVariableInfo()
            : base(VerificationInfoTag.Top)
        {
        }
    }

    /// <summary>
    /// Indicates that the verification type is <c>int</c>.
    /// </summary>
    public sealed class IntegerVariableInfo : VerificationInfo
    {
        /// <summary>
        /// Creates a new <see cref="IntegerVariableInfo"/>.
        /// </summary>
        public IntegerVariableInfo()
            : base(VerificationInfoTag.Integer)
        {
        }
    }
    
    /// <summary>
    /// Indicates that the verification type is <c>float</c>.
    /// </summary>
    public sealed class FloatVariableInfo : VerificationInfo
    {
        /// <summary>
        /// Creates a new <see cref="FloatVariableInfo"/>.
        /// </summary>
        public FloatVariableInfo()
            : base(VerificationInfoTag.Float)
        {
        }
    }
    
    /// <summary>
    /// Indicates that the verification type is <c>long</c>.
    /// </summary>
    public sealed class LongVariableInfo : VerificationInfo
    {
        /// <summary>
        /// Creates a new <see cref="LongVariableInfo"/>.
        /// </summary>
        public LongVariableInfo()
            : base(VerificationInfoTag.Long)
        {
        }
    }
    
    /// <summary>
    /// Indicates that the verification type is <c>double</c>.
    /// </summary>
    public sealed class DoubleVariableInfo : VerificationInfo
    {
        /// <summary>
        /// Creates a new <see cref="DoubleVariableInfo"/>.
        /// </summary>
        public DoubleVariableInfo()
            : base(VerificationInfoTag.Double)
        {
        }
    }
    
    /// <summary>
    /// Indicates that the verification type is <c>null</c>.
    /// </summary>
    public sealed class NullVariableInfo : VerificationInfo
    {
        /// <summary>
        /// Creates a new <see cref="NullVariableInfo"/>.
        /// </summary>
        public NullVariableInfo()
            : base(VerificationInfoTag.Null)
        {
        }
    }
    
    /// <summary>
    /// Indicates that the verification type is <c>uninitializedThis</c>.
    /// </summary>
    public sealed class UninitializedThisVariableInfo : VerificationInfo
    {
        /// <summary>
        /// Creates a new <see cref="UninitializedThisVariableInfo"/>.
        /// </summary>
        public UninitializedThisVariableInfo()
            : base(VerificationInfoTag.UninitializedThis)
        {
        }
    }
    
    /// <summary>
    /// Indicates that the verification type is represented by a <see cref="ClassConstant"/> that can be resolved
    /// via the <see cref="ConstantPoolIndex"/>.
    /// </summary>
    public sealed class ObjectVariableInfo : VerificationInfo
    {
        /// <summary>
        /// Creates a new <see cref="ObjectVariableInfo"/>.
        /// </summary>
        /// <param name="constantPoolIndex">The index into the <see cref="ConstantPool"/> to a <see cref="ClassConstant"/>.</param>
        public ObjectVariableInfo(ushort constantPoolIndex)
            : base(VerificationInfoTag.Object)
        {
            ConstantPoolIndex = constantPoolIndex;
        }
        
        /// <summary>
        /// Gets the index into the <see cref="ConstantPool"/> to a <see cref="ClassConstant"/>.
        /// </summary>
        public ushort ConstantPoolIndex
        {
            get;
        }
    }
    
    /// <summary>
    /// Indicates that the verification type is an uninitialized object (these are created by the <see cref="JvmOpCodes.New"/> instruction).
    /// </summary>
    public sealed class UninitializedVariableInfo : VerificationInfo
    {
        /// <summary>
        /// Creates a new <see cref="UninitializedVariableInfo"/>.
        /// </summary>
        /// <param name="offset">The offset into the method body to a <see cref="JvmOpCodes.New"/> instruction.</param>
        public UninitializedVariableInfo(ushort offset)
            : base(VerificationInfoTag.Uninitialized)
        {
            Offset = offset;
        }
        
        /// <summary>
        /// Gets the offset into the method body to a <see cref="JvmOpCodes.New"/> instruction.
        /// </summary>
        public ushort Offset
        {
            get;
        }
    }
}