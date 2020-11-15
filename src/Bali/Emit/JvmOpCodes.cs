using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Bali.Emit
{
    /// <summary>
    /// Provides all Jvm opcodes semantically modelled.
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public static class JvmOpCodes
    {
        /// <summary>
        /// All of the Jvm opcodes.
        /// </summary>
        public static readonly IReadOnlyDictionary<byte, JvmOpCode> OpCodes;
        
        internal static readonly Dictionary<byte, JvmOpCode> RawOpCodes;

        static JvmOpCodes()
        {
            RawOpCodes = new Dictionary<byte, JvmOpCode>(205);
            OpCodes = RawOpCodes;
        }
        
        /// <inheritdoc cref="JvmCode.Aaload" />
        public static readonly JvmOpCode Aaload = new JvmOpCode(
            JvmCode.Aaload,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Aastore" />
        public static readonly JvmOpCode Aastore = new JvmOpCode(
            JvmCode.Aastore,
            JvmOperandType.None,
            JvmStackBehavior.Pop3,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Aconst_Null" />
        public static readonly JvmOpCode Aconst_Null = new JvmOpCode(
            JvmCode.Aconst_Null,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Aload" />
        public static readonly JvmOpCode Aload = new JvmOpCode(
            JvmCode.Aload,
            JvmOperandType.LocalIndex,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Aload_0" />
        public static readonly JvmOpCode Aload_0 = new JvmOpCode(
            JvmCode.Aload_0,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Aload_1" />
        public static readonly JvmOpCode Aload_1 = new JvmOpCode(
            JvmCode.Aload_1,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Aload_2" />
        public static readonly JvmOpCode Aload_2 = new JvmOpCode(
            JvmCode.Aload_2,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Aload_3" />
        public static readonly JvmOpCode Aload_3 = new JvmOpCode(
            JvmCode.Aload_3,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Anewarray" />
        public static readonly JvmOpCode Anewarray = new JvmOpCode(
            JvmCode.Anewarray,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Areturn" />
        public static readonly JvmOpCode Areturn = new JvmOpCode(
            JvmCode.Areturn,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Return);

        /// <inheritdoc cref="JvmCode.Arraylength" />
        public static readonly JvmOpCode Arraylength = new JvmOpCode(
            JvmCode.Arraylength,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Astore" />
        public static readonly JvmOpCode Astore = new JvmOpCode(
            JvmCode.Astore,
            JvmOperandType.LocalIndex,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Astore_0" />
        public static readonly JvmOpCode Astore_0 = new JvmOpCode(
            JvmCode.Astore_0,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Astore_1" />
        public static readonly JvmOpCode Astore_1 = new JvmOpCode(
            JvmCode.Astore_1,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Astore_2" />
        public static readonly JvmOpCode Astore_2 = new JvmOpCode(
            JvmCode.Astore_2,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Astore_3" />
        public static readonly JvmOpCode Astore_3 = new JvmOpCode(
            JvmCode.Astore_3,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Athrow" />
        public static readonly JvmOpCode Athrow = new JvmOpCode(
            JvmCode.Athrow,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Throw);

        /// <inheritdoc cref="JvmCode.Baload" />
        public static readonly JvmOpCode Baload = new JvmOpCode(
            JvmCode.Baload,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Bastore" />
        public static readonly JvmOpCode Bastore = new JvmOpCode(
            JvmCode.Bastore,
            JvmOperandType.None,
            JvmStackBehavior.Pop3,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Bipush" />
        public static readonly JvmOpCode Bipush = new JvmOpCode(
            JvmCode.Bipush,
            JvmOperandType.InlineByte,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Caload" />
        public static readonly JvmOpCode Caload = new JvmOpCode(
            JvmCode.Caload,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Castore" />
        public static readonly JvmOpCode Castore = new JvmOpCode(
            JvmCode.Castore,
            JvmOperandType.None,
            JvmStackBehavior.Pop3,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Checkcast" />
        public static readonly JvmOpCode Checkcast = new JvmOpCode(
            JvmCode.Checkcast,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.D2f" />
        public static readonly JvmOpCode D2f = new JvmOpCode(
            JvmCode.D2f,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.D2i" />
        public static readonly JvmOpCode D2i = new JvmOpCode(
            JvmCode.D2i,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.D2l" />
        public static readonly JvmOpCode D2l = new JvmOpCode(
            JvmCode.D2l,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dadd" />
        public static readonly JvmOpCode Dadd = new JvmOpCode(
            JvmCode.Dadd,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Daload" />
        public static readonly JvmOpCode Daload = new JvmOpCode(
            JvmCode.Daload,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dastore" />
        public static readonly JvmOpCode Dastore = new JvmOpCode(
            JvmCode.Dastore,
            JvmOperandType.None,
            JvmStackBehavior.Pop3,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dcmpg" />
        public static readonly JvmOpCode Dcmpg = new JvmOpCode(
            JvmCode.Dcmpg,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dcmpl" />
        public static readonly JvmOpCode Dcmpl = new JvmOpCode(
            JvmCode.Dcmpl,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dconst_0" />
        public static readonly JvmOpCode Dconst_0 = new JvmOpCode(
            JvmCode.Dconst_0,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dconst_1" />
        public static readonly JvmOpCode Dconst_1 = new JvmOpCode(
            JvmCode.Dconst_1,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ddiv" />
        public static readonly JvmOpCode Ddiv = new JvmOpCode(
            JvmCode.Ddiv,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dload" />
        public static readonly JvmOpCode Dload = new JvmOpCode(
            JvmCode.Dload,
            JvmOperandType.LocalIndex,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dload_0" />
        public static readonly JvmOpCode Dload_0 = new JvmOpCode(
            JvmCode.Dload_0,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dload_1" />
        public static readonly JvmOpCode Dload_1 = new JvmOpCode(
            JvmCode.Dload_1,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dload_2" />
        public static readonly JvmOpCode Dload_2 = new JvmOpCode(
            JvmCode.Dload_2,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dload_3" />
        public static readonly JvmOpCode Dload_3 = new JvmOpCode(
            JvmCode.Dload_3,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dmul" />
        public static readonly JvmOpCode Dmul = new JvmOpCode(
            JvmCode.Dmul,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dneg" />
        public static readonly JvmOpCode Dneg = new JvmOpCode(
            JvmCode.Dneg,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Drem" />
        public static readonly JvmOpCode Drem = new JvmOpCode(
            JvmCode.Drem,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dreturn" />
        public static readonly JvmOpCode Dreturn = new JvmOpCode(
            JvmCode.Dreturn,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Return);

        /// <inheritdoc cref="JvmCode.Dstore" />
        public static readonly JvmOpCode Dstore = new JvmOpCode(
            JvmCode.Dstore,
            JvmOperandType.LocalIndex,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dstore_0" />
        public static readonly JvmOpCode Dstore_0 = new JvmOpCode(
            JvmCode.Dstore_0,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dstore_1" />
        public static readonly JvmOpCode Dstore_1 = new JvmOpCode(
            JvmCode.Dstore_1,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dstore_2" />
        public static readonly JvmOpCode Dstore_2 = new JvmOpCode(
            JvmCode.Dstore_2,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dstore_3" />
        public static readonly JvmOpCode Dstore_3 = new JvmOpCode(
            JvmCode.Dstore_3,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dsub" />
        public static readonly JvmOpCode Dsub = new JvmOpCode(
            JvmCode.Dsub,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dup" />
        public static readonly JvmOpCode Dup = new JvmOpCode(
            JvmCode.Dup,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push2,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dup_X1" />
        public static readonly JvmOpCode Dup_X1 = new JvmOpCode(
            JvmCode.Dup_X1,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push3,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dup_X2" />
        public static readonly JvmOpCode Dup_X2 = new JvmOpCode(
            JvmCode.Dup_X2,
            JvmOperandType.None,
            JvmStackBehavior.Var,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dup2" />
        public static readonly JvmOpCode Dup2 = new JvmOpCode(
            JvmCode.Dup2,
            JvmOperandType.None,
            JvmStackBehavior.Var,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dup2_X1" />
        public static readonly JvmOpCode Dup2_X1 = new JvmOpCode(
            JvmCode.Dup2_X1,
            JvmOperandType.None,
            JvmStackBehavior.Var,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dup2_X2" />
        public static readonly JvmOpCode Dup2_X2 = new JvmOpCode(
            JvmCode.Dup2_X2,
            JvmOperandType.None,
            JvmStackBehavior.Var,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.F2d" />
        public static readonly JvmOpCode F2d = new JvmOpCode(
            JvmCode.F2d,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.F2i" />
        public static readonly JvmOpCode F2i = new JvmOpCode(
            JvmCode.F2i,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.F2l" />
        public static readonly JvmOpCode F2l = new JvmOpCode(
            JvmCode.F2l,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fadd" />
        public static readonly JvmOpCode Fadd = new JvmOpCode(
            JvmCode.Fadd,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Faload" />
        public static readonly JvmOpCode Faload = new JvmOpCode(
            JvmCode.Faload,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fastore" />
        public static readonly JvmOpCode Fastore = new JvmOpCode(
            JvmCode.Fastore,
            JvmOperandType.None,
            JvmStackBehavior.Pop3,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fcmpg" />
        public static readonly JvmOpCode Fcmpg = new JvmOpCode(
            JvmCode.Fcmpg,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fcmpl" />
        public static readonly JvmOpCode Fcmpl = new JvmOpCode(
            JvmCode.Fcmpl,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fconst_0" />
        public static readonly JvmOpCode Fconst_0 = new JvmOpCode(
            JvmCode.Fconst_0,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fconst_1" />
        public static readonly JvmOpCode Fconst_1 = new JvmOpCode(
            JvmCode.Fconst_1,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fconst_2" />
        public static readonly JvmOpCode Fconst_2 = new JvmOpCode(
            JvmCode.Fconst_2,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fdiv" />
        public static readonly JvmOpCode Fdiv = new JvmOpCode(
            JvmCode.Fdiv,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fload" />
        public static readonly JvmOpCode Fload = new JvmOpCode(
            JvmCode.Fload,
            JvmOperandType.LocalIndex,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fload_0" />
        public static readonly JvmOpCode Fload_0 = new JvmOpCode(
            JvmCode.Fload_0,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fload_1" />
        public static readonly JvmOpCode Fload_1 = new JvmOpCode(
            JvmCode.Fload_1,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fload_2" />
        public static readonly JvmOpCode Fload_2 = new JvmOpCode(
            JvmCode.Fload_2,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fload_3" />
        public static readonly JvmOpCode Fload_3 = new JvmOpCode(
            JvmCode.Fload_3,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fmul" />
        public static readonly JvmOpCode Fmul = new JvmOpCode(
            JvmCode.Fmul,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fneg" />
        public static readonly JvmOpCode Fneg = new JvmOpCode(
            JvmCode.Fneg,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Frem" />
        public static readonly JvmOpCode Frem = new JvmOpCode(
            JvmCode.Frem,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Freturn" />
        public static readonly JvmOpCode Freturn = new JvmOpCode(
            JvmCode.Freturn,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Return);

        /// <inheritdoc cref="JvmCode.Fstore" />
        public static readonly JvmOpCode Fstore = new JvmOpCode(
            JvmCode.Fstore,
            JvmOperandType.LocalIndex,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fstore_0" />
        public static readonly JvmOpCode Fstore_0 = new JvmOpCode(
            JvmCode.Fstore_0,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fstore_1" />
        public static readonly JvmOpCode Fstore_1 = new JvmOpCode(
            JvmCode.Fstore_1,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fstore_2" />
        public static readonly JvmOpCode Fstore_2 = new JvmOpCode(
            JvmCode.Fstore_2,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fstore_3" />
        public static readonly JvmOpCode Fstore_3 = new JvmOpCode(
            JvmCode.Fstore_3,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fsub" />
        public static readonly JvmOpCode Fsub = new JvmOpCode(
            JvmCode.Fsub,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Getfield" />
        public static readonly JvmOpCode Getfield = new JvmOpCode(
            JvmCode.Getfield,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Getstatic" />
        public static readonly JvmOpCode Getstatic = new JvmOpCode(
            JvmCode.Getstatic,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Goto" />
        public static readonly JvmOpCode Goto = new JvmOpCode(
            JvmCode.Goto,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Nop,
            JvmFlowControl.UnconditionalBranch);

        /// <inheritdoc cref="JvmCode.Goto_w" />
        public static readonly JvmOpCode Goto_w = new JvmOpCode(
            JvmCode.Goto_w,
            JvmOperandType.WideBranchOffset,
            JvmStackBehavior.Nop,
            JvmFlowControl.UnconditionalBranch);

        /// <inheritdoc cref="JvmCode.I2b" />
        public static readonly JvmOpCode I2b = new JvmOpCode(
            JvmCode.I2b,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.I2c" />
        public static readonly JvmOpCode I2c = new JvmOpCode(
            JvmCode.I2c,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.I2d" />
        public static readonly JvmOpCode I2d = new JvmOpCode(
            JvmCode.I2d,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.I2f" />
        public static readonly JvmOpCode I2f = new JvmOpCode(
            JvmCode.I2f,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.I2l" />
        public static readonly JvmOpCode I2l = new JvmOpCode(
            JvmCode.I2l,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.I2s" />
        public static readonly JvmOpCode I2s = new JvmOpCode(
            JvmCode.I2s,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iadd" />
        public static readonly JvmOpCode Iadd = new JvmOpCode(
            JvmCode.Iadd,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iaload" />
        public static readonly JvmOpCode Iaload = new JvmOpCode(
            JvmCode.Iaload,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iand" />
        public static readonly JvmOpCode Iand = new JvmOpCode(
            JvmCode.Iand,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iastore" />
        public static readonly JvmOpCode Iastore = new JvmOpCode(
            JvmCode.Iastore,
            JvmOperandType.None,
            JvmStackBehavior.Pop3,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iconst_M1" />
        public static readonly JvmOpCode Iconst_M1 = new JvmOpCode(
            JvmCode.Iconst_M1,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iconst_0" />
        public static readonly JvmOpCode Iconst_0 = new JvmOpCode(
            JvmCode.Iconst_0,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iconst_1" />
        public static readonly JvmOpCode Iconst_1 = new JvmOpCode(
            JvmCode.Iconst_1,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iconst_2" />
        public static readonly JvmOpCode Iconst_2 = new JvmOpCode(
            JvmCode.Iconst_2,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iconst_3" />
        public static readonly JvmOpCode Iconst_3 = new JvmOpCode(
            JvmCode.Iconst_3,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iconst_4" />
        public static readonly JvmOpCode Iconst_4 = new JvmOpCode(
            JvmCode.Iconst_4,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iconst_5" />
        public static readonly JvmOpCode Iconst_5 = new JvmOpCode(
            JvmCode.Iconst_5,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Idiv" />
        public static readonly JvmOpCode Idiv = new JvmOpCode(
            JvmCode.Idiv,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.If_Acmpeq" />
        public static readonly JvmOpCode If_Acmpeq = new JvmOpCode(
            JvmCode.If_Acmpeq,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop2,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.If_Acmpne" />
        public static readonly JvmOpCode If_Acmpne = new JvmOpCode(
            JvmCode.If_Acmpne,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop2,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.If_Icmpeq" />
        public static readonly JvmOpCode If_Icmpeq = new JvmOpCode(
            JvmCode.If_Icmpeq,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop2,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.If_Icmpne" />
        public static readonly JvmOpCode If_Icmpne = new JvmOpCode(
            JvmCode.If_Icmpne,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop2,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.If_Icmplt" />
        public static readonly JvmOpCode If_Icmplt = new JvmOpCode(
            JvmCode.If_Icmplt,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop2,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.If_Icmpge" />
        public static readonly JvmOpCode If_Icmpge = new JvmOpCode(
            JvmCode.If_Icmpge,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop2,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.If_Icmpgt" />
        public static readonly JvmOpCode If_Icmpgt = new JvmOpCode(
            JvmCode.If_Icmpgt,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop2,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.If_Icmple" />
        public static readonly JvmOpCode If_Icmple = new JvmOpCode(
            JvmCode.If_Icmple,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop2,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.Ifeq" />
        public static readonly JvmOpCode Ifeq = new JvmOpCode(
            JvmCode.Ifeq,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop1,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.Ifne" />
        public static readonly JvmOpCode Ifne = new JvmOpCode(
            JvmCode.Ifne,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop1,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.Iflt" />
        public static readonly JvmOpCode Iflt = new JvmOpCode(
            JvmCode.Iflt,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop1,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.Ifge" />
        public static readonly JvmOpCode Ifge = new JvmOpCode(
            JvmCode.Ifge,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop1,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.Ifgt" />
        public static readonly JvmOpCode Ifgt = new JvmOpCode(
            JvmCode.Ifgt,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop1,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.Ifle" />
        public static readonly JvmOpCode Ifle = new JvmOpCode(
            JvmCode.Ifle,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop1,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.Ifnonnull" />
        public static readonly JvmOpCode Ifnonnull = new JvmOpCode(
            JvmCode.Ifnonnull,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop1,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.Ifnull" />
        public static readonly JvmOpCode Ifnull = new JvmOpCode(
            JvmCode.Ifnull,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop1,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.Iinc" />
        public static readonly JvmOpCode Iinc = new JvmOpCode(
            JvmCode.Iinc,
            JvmOperandType.LocalIndexWithSignedByte,
            JvmStackBehavior.Nop,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iload" />
        public static readonly JvmOpCode Iload = new JvmOpCode(
            JvmCode.Iload,
            JvmOperandType.LocalIndex,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iload_0" />
        public static readonly JvmOpCode Iload_0 = new JvmOpCode(
            JvmCode.Iload_0,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iload_1" />
        public static readonly JvmOpCode Iload_1 = new JvmOpCode(
            JvmCode.Iload_1,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iload_2" />
        public static readonly JvmOpCode Iload_2 = new JvmOpCode(
            JvmCode.Iload_2,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iload_3" />
        public static readonly JvmOpCode Iload_3 = new JvmOpCode(
            JvmCode.Iload_3,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Imul" />
        public static readonly JvmOpCode Imul = new JvmOpCode(
            JvmCode.Imul,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ineg" />
        public static readonly JvmOpCode Ineg = new JvmOpCode(
            JvmCode.Ineg,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Instanceof" />
        public static readonly JvmOpCode Instanceof = new JvmOpCode(
            JvmCode.Instanceof,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Invokedynamic" />
        public static readonly JvmOpCode Invokedynamic = new JvmOpCode(
            JvmCode.Invokedynamic,
            JvmOperandType.WideConstantPoolIndexWithTwoBytes,
            JvmStackBehavior.Var,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Invokeinterface" />
        public static readonly JvmOpCode Invokeinterface = new JvmOpCode(
            JvmCode.Invokeinterface,
            JvmOperandType.WideConstantPoolIndexWithTwoBytes,
            JvmStackBehavior.Var,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Invokespecial" />
        public static readonly JvmOpCode Invokespecial = new JvmOpCode(
            JvmCode.Invokespecial,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Var,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Invokestatic" />
        public static readonly JvmOpCode Invokestatic = new JvmOpCode(
            JvmCode.Invokestatic,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Var,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Invokevirtual" />
        public static readonly JvmOpCode Invokevirtual = new JvmOpCode(
            JvmCode.Invokevirtual,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Var,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ior" />
        public static readonly JvmOpCode Ior = new JvmOpCode(
            JvmCode.Ior,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Irem" />
        public static readonly JvmOpCode Irem = new JvmOpCode(
            JvmCode.Irem,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ireturn" />
        public static readonly JvmOpCode Ireturn = new JvmOpCode(
            JvmCode.Ireturn,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Return);

        /// <inheritdoc cref="JvmCode.Ishl" />
        public static readonly JvmOpCode Ishl = new JvmOpCode(
            JvmCode.Ishl,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ishr" />
        public static readonly JvmOpCode Ishr = new JvmOpCode(
            JvmCode.Ishr,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Istore" />
        public static readonly JvmOpCode Istore = new JvmOpCode(
            JvmCode.Istore,
            JvmOperandType.LocalIndex,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Istore_0" />
        public static readonly JvmOpCode Istore_0 = new JvmOpCode(
            JvmCode.Istore_0,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Istore_1" />
        public static readonly JvmOpCode Istore_1 = new JvmOpCode(
            JvmCode.Istore_1,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Istore_2" />
        public static readonly JvmOpCode Istore_2 = new JvmOpCode(
            JvmCode.Istore_2,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Istore_3" />
        public static readonly JvmOpCode Istore_3 = new JvmOpCode(
            JvmCode.Istore_3,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Isub" />
        public static readonly JvmOpCode Isub = new JvmOpCode(
            JvmCode.Isub,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iushr" />
        public static readonly JvmOpCode Iushr = new JvmOpCode(
            JvmCode.Iushr,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ixor" />
        public static readonly JvmOpCode Ixor = new JvmOpCode(
            JvmCode.Ixor,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Jsr" />
        public static readonly JvmOpCode Jsr = new JvmOpCode(
            JvmCode.Jsr,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Push1,
            JvmFlowControl.UnconditionalBranch);

        /// <inheritdoc cref="JvmCode.Jsr_W" />
        public static readonly JvmOpCode Jsr_W = new JvmOpCode(
            JvmCode.Jsr_W,
            JvmOperandType.WideBranchOffset,
            JvmStackBehavior.Push1,
            JvmFlowControl.UnconditionalBranch);

        /// <inheritdoc cref="JvmCode.L2d" />
        public static readonly JvmOpCode L2d = new JvmOpCode(
            JvmCode.L2d,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.L2f" />
        public static readonly JvmOpCode L2f = new JvmOpCode(
            JvmCode.L2f,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.L2i" />
        public static readonly JvmOpCode L2i = new JvmOpCode(
            JvmCode.L2i,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ladd" />
        public static readonly JvmOpCode Ladd = new JvmOpCode(
            JvmCode.Ladd,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Laload" />
        public static readonly JvmOpCode Laload = new JvmOpCode(
            JvmCode.Laload,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Land" />
        public static readonly JvmOpCode Land = new JvmOpCode(
            JvmCode.Land,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lastore" />
        public static readonly JvmOpCode Lastore = new JvmOpCode(
            JvmCode.Lastore,
            JvmOperandType.None,
            JvmStackBehavior.Pop3,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lcmp" />
        public static readonly JvmOpCode Lcmp = new JvmOpCode(
            JvmCode.Lcmp,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lconst_0" />
        public static readonly JvmOpCode Lconst_0 = new JvmOpCode(
            JvmCode.Lconst_0,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lconst_1" />
        public static readonly JvmOpCode Lconst_1 = new JvmOpCode(
            JvmCode.Lconst_1,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ldc" />
        public static readonly JvmOpCode Ldc = new JvmOpCode(
            JvmCode.Ldc,
            JvmOperandType.ConstantPoolIndex,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ldc_W" />
        public static readonly JvmOpCode Ldc_W = new JvmOpCode(
            JvmCode.Ldc_W,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ldc2_W" />
        public static readonly JvmOpCode Ldc2_W = new JvmOpCode(
            JvmCode.Ldc2_W,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ldiv" />
        public static readonly JvmOpCode Ldiv = new JvmOpCode(
            JvmCode.Ldiv,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lload" />
        public static readonly JvmOpCode Lload = new JvmOpCode(
            JvmCode.Lload,
            JvmOperandType.LocalIndex,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lload_0" />
        public static readonly JvmOpCode Lload_0 = new JvmOpCode(
            JvmCode.Lload_0,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lload_1" />
        public static readonly JvmOpCode Lload_1 = new JvmOpCode(
            JvmCode.Lload_1,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lload_2" />
        public static readonly JvmOpCode Lload_2 = new JvmOpCode(
            JvmCode.Lload_2,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lload_3" />
        public static readonly JvmOpCode Lload_3 = new JvmOpCode(
            JvmCode.Lload_3,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lmul" />
        public static readonly JvmOpCode Lmul = new JvmOpCode(
            JvmCode.Lmul,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lneg" />
        public static readonly JvmOpCode Lneg = new JvmOpCode(
            JvmCode.Lneg,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lookupswitch" />
        public static readonly JvmOpCode Lookupswitch = new JvmOpCode(
            JvmCode.Lookupswitch,
            JvmOperandType.KeyJumpTable,
            JvmStackBehavior.Pop1,
            JvmFlowControl.UnconditionalBranch);

        /// <inheritdoc cref="JvmCode.Lor" />
        public static readonly JvmOpCode Lor = new JvmOpCode(
            JvmCode.Lor,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lrem" />
        public static readonly JvmOpCode Lrem = new JvmOpCode(
            JvmCode.Lrem,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lreturn" />
        public static readonly JvmOpCode Lreturn = new JvmOpCode(
            JvmCode.Lreturn,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Return);

        /// <inheritdoc cref="JvmCode.Lshl" />
        public static readonly JvmOpCode Lshl = new JvmOpCode(
            JvmCode.Lshl,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lshr" />
        public static readonly JvmOpCode Lshr = new JvmOpCode(
            JvmCode.Lshr,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lstore" />
        public static readonly JvmOpCode Lstore = new JvmOpCode(
            JvmCode.Lstore,
            JvmOperandType.LocalIndex,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lstore_0" />
        public static readonly JvmOpCode Lstore_0 = new JvmOpCode(
            JvmCode.Lstore_0,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lstore_1" />
        public static readonly JvmOpCode Lstore_1 = new JvmOpCode(
            JvmCode.Lstore_1,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lstore_2" />
        public static readonly JvmOpCode Lstore_2 = new JvmOpCode(
            JvmCode.Lstore_2,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lstore_3" />
        public static readonly JvmOpCode Lstore_3 = new JvmOpCode(
            JvmCode.Lstore_3,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lsub" />
        public static readonly JvmOpCode Lsub = new JvmOpCode(
            JvmCode.Lsub,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lushr" />
        public static readonly JvmOpCode Lushr = new JvmOpCode(
            JvmCode.Lushr,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lxor" />
        public static readonly JvmOpCode Lxor = new JvmOpCode(
            JvmCode.Lxor,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Monitorenter" />
        public static readonly JvmOpCode Monitorenter = new JvmOpCode(
            JvmCode.Monitorenter,
            JvmOperandType.None,
            JvmStackBehavior.Undefined,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Monitorexit" />
        public static readonly JvmOpCode Monitorexit = new JvmOpCode(
            JvmCode.Monitorexit,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Multinewarray" />
        public static readonly JvmOpCode Multinewarray = new JvmOpCode(
            JvmCode.Multinewarray,
            JvmOperandType.WideConstantPoolIndexWithArrayDimensions,
            JvmStackBehavior.Var,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.New" />
        public static readonly JvmOpCode New = new JvmOpCode(
            JvmCode.New,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Newarray" />
        public static readonly JvmOpCode Newarray = new JvmOpCode(
            JvmCode.Newarray,
            JvmOperandType.ArrayType,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Nop" />
        public static readonly JvmOpCode Nop = new JvmOpCode(
            JvmCode.Nop,
            JvmOperandType.None,
            JvmStackBehavior.Nop,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Pop" />
        public static readonly JvmOpCode Pop = new JvmOpCode(
            JvmCode.Pop,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Pop2" />
        public static readonly JvmOpCode Pop2 = new JvmOpCode(
            JvmCode.Pop2,
            JvmOperandType.None,
            JvmStackBehavior.Var,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Putfield" />
        public static readonly JvmOpCode Putfield = new JvmOpCode(
            JvmCode.Putfield,
            JvmOperandType.None,
            JvmStackBehavior.Undefined,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Putstatic" />
        public static readonly JvmOpCode Putstatic = new JvmOpCode(
            JvmCode.Putstatic,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Pop2,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ret" />
        public static readonly JvmOpCode Ret = new JvmOpCode(
            JvmCode.Ret,
            JvmOperandType.LocalIndex,
            JvmStackBehavior.Pop1,
            JvmFlowControl.UnconditionalBranch);

        /// <inheritdoc cref="JvmCode.Return" />
        public static readonly JvmOpCode Return = new JvmOpCode(
            JvmCode.Return,
            JvmOperandType.None,
            JvmStackBehavior.Nop,
            JvmFlowControl.Return);

        /// <inheritdoc cref="JvmCode.Saload" />
        public static readonly JvmOpCode Saload = new JvmOpCode(
            JvmCode.Saload,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Sastore" />
        public static readonly JvmOpCode Sastore = new JvmOpCode(
            JvmCode.Sastore,
            JvmOperandType.None,
            JvmStackBehavior.Pop3,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Sipush" />
        public static readonly JvmOpCode Sipush = new JvmOpCode(
            JvmCode.Sipush,
            JvmOperandType.InlineShort,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Swap" />
        public static readonly JvmOpCode Swap = new JvmOpCode(
            JvmCode.Swap,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push2,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Tableswitch" />
        public static readonly JvmOpCode Tableswitch = new JvmOpCode(
            JvmCode.Tableswitch,
            JvmOperandType.IndexJumpTable,
            JvmStackBehavior.Pop1,
            JvmFlowControl.UnconditionalBranch);

        /// <inheritdoc cref="JvmCode.Wide" />
        public static readonly JvmOpCode Wide = new JvmOpCode(
            JvmCode.Wide,
            JvmOperandType.None,
            JvmStackBehavior.Nop,
            JvmFlowControl.Fallthrough);
        
        /// <inheritdoc cref="JvmCode.Imdep1"/>
        public static readonly JvmOpCode Imdep1 = new JvmOpCode(
            JvmCode.Imdep1,
            JvmOperandType.None,
            JvmStackBehavior.Undefined,
            JvmFlowControl.Undefined);
            
        /// <inheritdoc cref="JvmCode.Imdep2"/>
        public static readonly JvmOpCode Imdep2 = new JvmOpCode(
            JvmCode.Imdep2,
            JvmOperandType.None,
            JvmStackBehavior.Undefined,
            JvmFlowControl.Undefined);
        
        /// <inheritdoc cref="JvmCode.Breakpoint"/>
        public static readonly JvmOpCode Breakpoint = new JvmOpCode(
            JvmCode.Breakpoint,
            JvmOperandType.None,
            JvmStackBehavior.Undefined,
            JvmFlowControl.Undefined);
    }
}