using System.Diagnostics.CodeAnalysis;
using static Bali.Emit.JvmStackBehavior;
using static Bali.Emit.JvmFlowControl;
using static Bali.Emit.JvmOperandType;

namespace Bali.Emit
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public static class JvmOpCodes
    {
        public static readonly JvmOpCode[] OpCodes = new JvmOpCode[255];
        
        /// <inheritdoc cref="JvmCode.Aaload" />
        public static readonly JvmOpCode aaload =
            new JvmOpCode(JvmCode.Aaload, Pop2Push1, Fallthrough, None);
        
        /// <inheritdoc cref="JvmCode.Aastore" />
        public static readonly JvmOpCode aastore =
            new JvmOpCode(JvmCode.Aastore, Pop2Push1, Fallthrough, None);

        /// <inheritdoc cref="JvmCode.Aconst_Null" />
        public static readonly JvmOpCode aconst_null =
            new JvmOpCode(JvmCode.Aconst_Null, Push1, Fallthrough, None);
        
        /// <inheritdoc cref="JvmCode.Aload" />
        public static readonly JvmOpCode aload =
            new JvmOpCode(JvmCode.Aload, Push1, Fallthrough, Byte);
        
        /// <inheritdoc cref="JvmCode.Aload_0" />
        public static readonly JvmOpCode aload_0 =
            new JvmOpCode(JvmCode.Aload_0, Push1, Fallthrough, None);
        
        /// <inheritdoc cref="JvmCode.Aload_1" />
        public static readonly JvmOpCode aload_1 =
            new JvmOpCode(JvmCode.Aload_1, Push1, Fallthrough, None);
        
        /// <inheritdoc cref="JvmCode.Aload_2" />
        public static readonly JvmOpCode aload_2 =
            new JvmOpCode(JvmCode.Aload_2, Push1, Fallthrough, None);
        
        /// <inheritdoc cref="JvmCode.Aload_3" />
        public static readonly JvmOpCode aload_3 =
            new JvmOpCode(JvmCode.Aload_3, Push1, Fallthrough, None);
        
        /// <inheritdoc cref="JvmCode.Anewarray" />
        public static readonly JvmOpCode anewarray =
            new JvmOpCode(JvmCode.Anewarray, Pop1Push1, Fallthrough, Short);
            
        /// <inheritdoc cref="JvmCode.Areturn" />
        public static readonly JvmOpCode areturn =
            new JvmOpCode(JvmCode.Areturn, Pop1, Return, None);
            
        /// <inheritdoc cref="JvmCode.Arraylength" />
        public static readonly JvmOpCode arraylength =
            new JvmOpCode(JvmCode.Arraylength, Pop1Push1, Fallthrough, None);
            
        /// <inheritdoc cref="JvmCode.Astore" />
        public static readonly JvmOpCode astore =
            new JvmOpCode(JvmCode.Astore, Pop1, Fallthrough, Byte);
            
        /// <inheritdoc cref="JvmCode.Astore_0" />
        public static readonly JvmOpCode astore_0 =
            new JvmOpCode(JvmCode.Astore_0, Pop1, Fallthrough, None);
            
        /// <inheritdoc cref="JvmCode.Astore_1" />
        public static readonly JvmOpCode astore_1 =
            new JvmOpCode(JvmCode.Astore_1, Pop1, Fallthrough, None);
            
        /// <inheritdoc cref="JvmCode.Astore_2" />
        public static readonly JvmOpCode astore_2 =
            new JvmOpCode(JvmCode.Astore_2, Pop1, Fallthrough, None);
            
        /// <inheritdoc cref="JvmCode.Astore_3" />
        public static readonly JvmOpCode astore_3 =
            new JvmOpCode(JvmCode.Astore_3, Pop1, Fallthrough, None);
            
        /// <inheritdoc cref="JvmCode.Athrow" />
        public static readonly JvmOpCode athrow =
            new JvmOpCode(JvmCode.Athrow, Pop1, Throw, None);
            
        /// <inheritdoc cref="JvmCode.Baload" />
        public static readonly JvmOpCode baload =
            new JvmOpCode(JvmCode.Baload, Pop2Push1, Fallthrough, None);
    }
}