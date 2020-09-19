using static Bali.Emit.JvmStackBehavior;
using static Bali.Emit.JvmFlowControl;
using static Bali.Emit.JvmOperandType;

namespace Bali.Emit
{
    public static class JvmOpCodes
    {
        public static readonly JvmOpCode[] OneByteOpCodes = new JvmOpCode[255];
        
        /// <inheritdoc cref="JvmCode.aaload" />
        public static readonly JvmOpCode aaload =
            new JvmOpCode(JvmCode.aaload, Pop2Push1, Fallthrough, None);
        
        /// <inheritdoc cref="JvmCode.aconst_null" />
        public static readonly JvmOpCode aastore =
            new JvmOpCode(JvmCode.aastore, Pop2Push1, Fallthrough, None);

        /// <inheritdoc cref="JvmCode.aconst_null" />
        public static readonly JvmOpCode aconst_null =
            new JvmOpCode(JvmCode.aconst_null, Push1, Fallthrough, None);
        
        /// <inheritdoc cref="JvmCode.aload" />
        public static readonly JvmOpCode aload =
            new JvmOpCode(JvmCode.aload, Push1, Fallthrough, Byte);
        
        /// <inheritdoc cref="JvmCode.aload_0" />
        public static readonly JvmOpCode aload_0 =
            new JvmOpCode(JvmCode.aload_0, Push1, Fallthrough, None);
        
        /// <inheritdoc cref="JvmCode.aload_1" />
        public static readonly JvmOpCode aload_1 =
            new JvmOpCode(JvmCode.aload_1, Push1, Fallthrough, None);
        
        /// <inheritdoc cref="JvmCode.aload_2" />
        public static readonly JvmOpCode aload_2 =
            new JvmOpCode(JvmCode.aload_2, Push1, Fallthrough, None);
        
        /// <inheritdoc cref="JvmCode.aload_3" />
        public static readonly JvmOpCode aload_3 =
            new JvmOpCode(JvmCode.aload_3, Push1, Fallthrough, None);
        
        /// <inheritdoc cref="JvmCode.anewarray" />
        public static readonly JvmOpCode anewarray =
            new JvmOpCode(JvmCode.anewarray, Pop1Push1, Fallthrough, Short);
            
        /// <inheritdoc cref="JvmCode.areturn" />
        public static readonly JvmOpCode areturn =
            new JvmOpCode(JvmCode.areturn, Pop1, Return, None);
            
        /// <inheritdoc cref="JvmCode.arraylength" />
        public static readonly JvmOpCode arraylength =
            new JvmOpCode(JvmCode.arraylength, Pop1Push1, Fallthrough, None);
            
        /// <inheritdoc cref="JvmCode.astore" />
        public static readonly JvmOpCode astore =
            new JvmOpCode(JvmCode.astore, Pop1, Fallthrough, Byte);
            
        /// <inheritdoc cref="JvmCode.astore_0" />
        public static readonly JvmOpCode astore_0 =
            new JvmOpCode(JvmCode.astore_0, Pop1, Fallthrough, None);
            
        /// <inheritdoc cref="JvmCode.astore_1" />
        public static readonly JvmOpCode astore_1 =
            new JvmOpCode(JvmCode.astore_1, Pop1, Fallthrough, None);
            
        /// <inheritdoc cref="JvmCode.astore_2" />
        public static readonly JvmOpCode astore_2 =
            new JvmOpCode(JvmCode.astore_2, Pop1, Fallthrough, None);
            
        /// <inheritdoc cref="JvmCode.astore_3" />
        public static readonly JvmOpCode astore_3 =
            new JvmOpCode(JvmCode.astore_3, Pop1, Fallthrough, None);
            
        /// <inheritdoc cref="JvmCode.athrow" />
        public static readonly JvmOpCode athrow =
            new JvmOpCode(JvmCode.athrow, Pop1, Throw, None);
            
        /// <inheritdoc cref="JvmCode.baload" />
        public static readonly JvmOpCode baload =
            new JvmOpCode(JvmCode.baload, Pop2Push1, Fallthrough, None);
    }
}