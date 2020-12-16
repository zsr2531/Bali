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
        internal static readonly Dictionary<byte, JvmOpCode> RawOpCodes = new(205);
        
        /// <summary>
        /// All of the Jvm opcodes.
        /// </summary>
        public static readonly IReadOnlyDictionary<byte, JvmOpCode> OpCodes = RawOpCodes;
        
        /// <inheritdoc cref="JvmCode.Aaload" />
        public static readonly JvmOpCode Aaload = new(
            JvmCode.Aaload,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Aastore" />
        public static readonly JvmOpCode Aastore = new(
            JvmCode.Aastore,
            JvmOperandType.None,
            JvmStackBehavior.Pop3,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Aconst_Null" />
        public static readonly JvmOpCode Aconst_Null = new(
            JvmCode.Aconst_Null,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Aload" />
        public static readonly JvmOpCode Aload = new(
            JvmCode.Aload,
            JvmOperandType.LocalIndex,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Aload_0" />
        public static readonly JvmOpCode Aload_0 = new(
            JvmCode.Aload_0,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Aload_1" />
        public static readonly JvmOpCode Aload_1 = new(
            JvmCode.Aload_1,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Aload_2" />
        public static readonly JvmOpCode Aload_2 = new(
            JvmCode.Aload_2,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Aload_3" />
        public static readonly JvmOpCode Aload_3 = new(
            JvmCode.Aload_3,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Anewarray" />
        public static readonly JvmOpCode Anewarray = new(
            JvmCode.Anewarray,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Areturn" />
        public static readonly JvmOpCode Areturn = new(
            JvmCode.Areturn,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Return);

        /// <inheritdoc cref="JvmCode.Arraylength" />
        public static readonly JvmOpCode Arraylength = new(
            JvmCode.Arraylength,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Astore" />
        public static readonly JvmOpCode Astore = new(
            JvmCode.Astore,
            JvmOperandType.LocalIndex,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Astore_0" />
        public static readonly JvmOpCode Astore_0 = new(
            JvmCode.Astore_0,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Astore_1" />
        public static readonly JvmOpCode Astore_1 = new(
            JvmCode.Astore_1,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Astore_2" />
        public static readonly JvmOpCode Astore_2 = new(
            JvmCode.Astore_2,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Astore_3" />
        public static readonly JvmOpCode Astore_3 = new(
            JvmCode.Astore_3,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Athrow" />
        public static readonly JvmOpCode Athrow = new(
            JvmCode.Athrow,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Throw);

        /// <inheritdoc cref="JvmCode.Baload" />
        public static readonly JvmOpCode Baload = new(
            JvmCode.Baload,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Bastore" />
        public static readonly JvmOpCode Bastore = new(
            JvmCode.Bastore,
            JvmOperandType.None,
            JvmStackBehavior.Pop3,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Bipush" />
        public static readonly JvmOpCode Bipush = new(
            JvmCode.Bipush,
            JvmOperandType.InlineByte,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Caload" />
        public static readonly JvmOpCode Caload = new(
            JvmCode.Caload,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Castore" />
        public static readonly JvmOpCode Castore = new(
            JvmCode.Castore,
            JvmOperandType.None,
            JvmStackBehavior.Pop3,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Checkcast" />
        public static readonly JvmOpCode Checkcast = new(
            JvmCode.Checkcast,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.D2f" />
        public static readonly JvmOpCode D2f = new(
            JvmCode.D2f,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.D2i" />
        public static readonly JvmOpCode D2i = new(
            JvmCode.D2i,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.D2l" />
        public static readonly JvmOpCode D2l = new(
            JvmCode.D2l,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dadd" />
        public static readonly JvmOpCode Dadd = new(
            JvmCode.Dadd,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Daload" />
        public static readonly JvmOpCode Daload = new(
            JvmCode.Daload,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dastore" />
        public static readonly JvmOpCode Dastore = new(
            JvmCode.Dastore,
            JvmOperandType.None,
            JvmStackBehavior.Pop3,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dcmpg" />
        public static readonly JvmOpCode Dcmpg = new(
            JvmCode.Dcmpg,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dcmpl" />
        public static readonly JvmOpCode Dcmpl = new(
            JvmCode.Dcmpl,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dconst_0" />
        public static readonly JvmOpCode Dconst_0 = new(
            JvmCode.Dconst_0,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dconst_1" />
        public static readonly JvmOpCode Dconst_1 = new(
            JvmCode.Dconst_1,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ddiv" />
        public static readonly JvmOpCode Ddiv = new(
            JvmCode.Ddiv,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dload" />
        public static readonly JvmOpCode Dload = new(
            JvmCode.Dload,
            JvmOperandType.LocalIndex,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dload_0" />
        public static readonly JvmOpCode Dload_0 = new(
            JvmCode.Dload_0,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dload_1" />
        public static readonly JvmOpCode Dload_1 = new(
            JvmCode.Dload_1,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dload_2" />
        public static readonly JvmOpCode Dload_2 = new(
            JvmCode.Dload_2,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dload_3" />
        public static readonly JvmOpCode Dload_3 = new(
            JvmCode.Dload_3,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dmul" />
        public static readonly JvmOpCode Dmul = new(
            JvmCode.Dmul,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dneg" />
        public static readonly JvmOpCode Dneg = new(
            JvmCode.Dneg,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Drem" />
        public static readonly JvmOpCode Drem = new(
            JvmCode.Drem,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dreturn" />
        public static readonly JvmOpCode Dreturn = new(
            JvmCode.Dreturn,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Return);

        /// <inheritdoc cref="JvmCode.Dstore" />
        public static readonly JvmOpCode Dstore = new(
            JvmCode.Dstore,
            JvmOperandType.LocalIndex,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dstore_0" />
        public static readonly JvmOpCode Dstore_0 = new(
            JvmCode.Dstore_0,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dstore_1" />
        public static readonly JvmOpCode Dstore_1 = new(
            JvmCode.Dstore_1,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dstore_2" />
        public static readonly JvmOpCode Dstore_2 = new(
            JvmCode.Dstore_2,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dstore_3" />
        public static readonly JvmOpCode Dstore_3 = new(
            JvmCode.Dstore_3,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dsub" />
        public static readonly JvmOpCode Dsub = new(
            JvmCode.Dsub,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dup" />
        public static readonly JvmOpCode Dup = new(
            JvmCode.Dup,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push2,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dup_X1" />
        public static readonly JvmOpCode Dup_X1 = new(
            JvmCode.Dup_X1,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push3,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dup_X2" />
        public static readonly JvmOpCode Dup_X2 = new(
            JvmCode.Dup_X2,
            JvmOperandType.None,
            JvmStackBehavior.Var,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dup2" />
        public static readonly JvmOpCode Dup2 = new(
            JvmCode.Dup2,
            JvmOperandType.None,
            JvmStackBehavior.Var,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dup2_X1" />
        public static readonly JvmOpCode Dup2_X1 = new(
            JvmCode.Dup2_X1,
            JvmOperandType.None,
            JvmStackBehavior.Var,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Dup2_X2" />
        public static readonly JvmOpCode Dup2_X2 = new(
            JvmCode.Dup2_X2,
            JvmOperandType.None,
            JvmStackBehavior.Var,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.F2d" />
        public static readonly JvmOpCode F2d = new(
            JvmCode.F2d,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.F2i" />
        public static readonly JvmOpCode F2i = new(
            JvmCode.F2i,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.F2l" />
        public static readonly JvmOpCode F2l = new(
            JvmCode.F2l,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fadd" />
        public static readonly JvmOpCode Fadd = new(
            JvmCode.Fadd,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Faload" />
        public static readonly JvmOpCode Faload = new(
            JvmCode.Faload,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fastore" />
        public static readonly JvmOpCode Fastore = new(
            JvmCode.Fastore,
            JvmOperandType.None,
            JvmStackBehavior.Pop3,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fcmpg" />
        public static readonly JvmOpCode Fcmpg = new(
            JvmCode.Fcmpg,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fcmpl" />
        public static readonly JvmOpCode Fcmpl = new(
            JvmCode.Fcmpl,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fconst_0" />
        public static readonly JvmOpCode Fconst_0 = new(
            JvmCode.Fconst_0,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fconst_1" />
        public static readonly JvmOpCode Fconst_1 = new(
            JvmCode.Fconst_1,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fconst_2" />
        public static readonly JvmOpCode Fconst_2 = new(
            JvmCode.Fconst_2,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fdiv" />
        public static readonly JvmOpCode Fdiv = new(
            JvmCode.Fdiv,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fload" />
        public static readonly JvmOpCode Fload = new(
            JvmCode.Fload,
            JvmOperandType.LocalIndex,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fload_0" />
        public static readonly JvmOpCode Fload_0 = new(
            JvmCode.Fload_0,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fload_1" />
        public static readonly JvmOpCode Fload_1 = new(
            JvmCode.Fload_1,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fload_2" />
        public static readonly JvmOpCode Fload_2 = new(
            JvmCode.Fload_2,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fload_3" />
        public static readonly JvmOpCode Fload_3 = new(
            JvmCode.Fload_3,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fmul" />
        public static readonly JvmOpCode Fmul = new(
            JvmCode.Fmul,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fneg" />
        public static readonly JvmOpCode Fneg = new(
            JvmCode.Fneg,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Frem" />
        public static readonly JvmOpCode Frem = new(
            JvmCode.Frem,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Freturn" />
        public static readonly JvmOpCode Freturn = new(
            JvmCode.Freturn,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Return);

        /// <inheritdoc cref="JvmCode.Fstore" />
        public static readonly JvmOpCode Fstore = new(
            JvmCode.Fstore,
            JvmOperandType.LocalIndex,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fstore_0" />
        public static readonly JvmOpCode Fstore_0 = new(
            JvmCode.Fstore_0,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fstore_1" />
        public static readonly JvmOpCode Fstore_1 = new(
            JvmCode.Fstore_1,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fstore_2" />
        public static readonly JvmOpCode Fstore_2 = new(
            JvmCode.Fstore_2,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fstore_3" />
        public static readonly JvmOpCode Fstore_3 = new(
            JvmCode.Fstore_3,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Fsub" />
        public static readonly JvmOpCode Fsub = new(
            JvmCode.Fsub,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Getfield" />
        public static readonly JvmOpCode Getfield = new(
            JvmCode.Getfield,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Getstatic" />
        public static readonly JvmOpCode Getstatic = new(
            JvmCode.Getstatic,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Goto" />
        public static readonly JvmOpCode Goto = new(
            JvmCode.Goto,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Nop,
            JvmFlowControl.UnconditionalBranch);

        /// <inheritdoc cref="JvmCode.Goto_w" />
        public static readonly JvmOpCode Goto_w = new(
            JvmCode.Goto_w,
            JvmOperandType.WideBranchOffset,
            JvmStackBehavior.Nop,
            JvmFlowControl.UnconditionalBranch);

        /// <inheritdoc cref="JvmCode.I2b" />
        public static readonly JvmOpCode I2b = new(
            JvmCode.I2b,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.I2c" />
        public static readonly JvmOpCode I2c = new(
            JvmCode.I2c,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.I2d" />
        public static readonly JvmOpCode I2d = new(
            JvmCode.I2d,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.I2f" />
        public static readonly JvmOpCode I2f = new(
            JvmCode.I2f,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.I2l" />
        public static readonly JvmOpCode I2l = new(
            JvmCode.I2l,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.I2s" />
        public static readonly JvmOpCode I2s = new(
            JvmCode.I2s,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iadd" />
        public static readonly JvmOpCode Iadd = new(
            JvmCode.Iadd,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iaload" />
        public static readonly JvmOpCode Iaload = new(
            JvmCode.Iaload,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iand" />
        public static readonly JvmOpCode Iand = new(
            JvmCode.Iand,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iastore" />
        public static readonly JvmOpCode Iastore = new(
            JvmCode.Iastore,
            JvmOperandType.None,
            JvmStackBehavior.Pop3,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iconst_M1" />
        public static readonly JvmOpCode Iconst_M1 = new(
            JvmCode.Iconst_M1,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iconst_0" />
        public static readonly JvmOpCode Iconst_0 = new(
            JvmCode.Iconst_0,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iconst_1" />
        public static readonly JvmOpCode Iconst_1 = new(
            JvmCode.Iconst_1,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iconst_2" />
        public static readonly JvmOpCode Iconst_2 = new(
            JvmCode.Iconst_2,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iconst_3" />
        public static readonly JvmOpCode Iconst_3 = new(
            JvmCode.Iconst_3,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iconst_4" />
        public static readonly JvmOpCode Iconst_4 = new(
            JvmCode.Iconst_4,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iconst_5" />
        public static readonly JvmOpCode Iconst_5 = new(
            JvmCode.Iconst_5,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Idiv" />
        public static readonly JvmOpCode Idiv = new(
            JvmCode.Idiv,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.If_Acmpeq" />
        public static readonly JvmOpCode If_Acmpeq = new(
            JvmCode.If_Acmpeq,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop2,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.If_Acmpne" />
        public static readonly JvmOpCode If_Acmpne = new(
            JvmCode.If_Acmpne,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop2,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.If_Icmpeq" />
        public static readonly JvmOpCode If_Icmpeq = new(
            JvmCode.If_Icmpeq,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop2,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.If_Icmpne" />
        public static readonly JvmOpCode If_Icmpne = new(
            JvmCode.If_Icmpne,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop2,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.If_Icmplt" />
        public static readonly JvmOpCode If_Icmplt = new(
            JvmCode.If_Icmplt,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop2,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.If_Icmpge" />
        public static readonly JvmOpCode If_Icmpge = new(
            JvmCode.If_Icmpge,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop2,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.If_Icmpgt" />
        public static readonly JvmOpCode If_Icmpgt = new(
            JvmCode.If_Icmpgt,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop2,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.If_Icmple" />
        public static readonly JvmOpCode If_Icmple = new(
            JvmCode.If_Icmple,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop2,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.Ifeq" />
        public static readonly JvmOpCode Ifeq = new(
            JvmCode.Ifeq,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop1,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.Ifne" />
        public static readonly JvmOpCode Ifne = new(
            JvmCode.Ifne,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop1,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.Iflt" />
        public static readonly JvmOpCode Iflt = new(
            JvmCode.Iflt,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop1,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.Ifge" />
        public static readonly JvmOpCode Ifge = new(
            JvmCode.Ifge,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop1,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.Ifgt" />
        public static readonly JvmOpCode Ifgt = new(
            JvmCode.Ifgt,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop1,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.Ifle" />
        public static readonly JvmOpCode Ifle = new(
            JvmCode.Ifle,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop1,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.Ifnonnull" />
        public static readonly JvmOpCode Ifnonnull = new(
            JvmCode.Ifnonnull,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop1,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.Ifnull" />
        public static readonly JvmOpCode Ifnull = new(
            JvmCode.Ifnull,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Pop1,
            JvmFlowControl.ConditionalBranch);

        /// <inheritdoc cref="JvmCode.Iinc" />
        public static readonly JvmOpCode Iinc = new(
            JvmCode.Iinc,
            JvmOperandType.LocalIndexWithSignedByte,
            JvmStackBehavior.Nop,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iload" />
        public static readonly JvmOpCode Iload = new(
            JvmCode.Iload,
            JvmOperandType.LocalIndex,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iload_0" />
        public static readonly JvmOpCode Iload_0 = new(
            JvmCode.Iload_0,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iload_1" />
        public static readonly JvmOpCode Iload_1 = new(
            JvmCode.Iload_1,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iload_2" />
        public static readonly JvmOpCode Iload_2 = new(
            JvmCode.Iload_2,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iload_3" />
        public static readonly JvmOpCode Iload_3 = new(
            JvmCode.Iload_3,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Imul" />
        public static readonly JvmOpCode Imul = new(
            JvmCode.Imul,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ineg" />
        public static readonly JvmOpCode Ineg = new(
            JvmCode.Ineg,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Instanceof" />
        public static readonly JvmOpCode Instanceof = new(
            JvmCode.Instanceof,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Invokedynamic" />
        public static readonly JvmOpCode Invokedynamic = new(
            JvmCode.Invokedynamic,
            JvmOperandType.WideConstantPoolIndexWithTwoBytes,
            JvmStackBehavior.Var,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Invokeinterface" />
        public static readonly JvmOpCode Invokeinterface = new(
            JvmCode.Invokeinterface,
            JvmOperandType.WideConstantPoolIndexWithTwoBytes,
            JvmStackBehavior.Var,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Invokespecial" />
        public static readonly JvmOpCode Invokespecial = new(
            JvmCode.Invokespecial,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Var,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Invokestatic" />
        public static readonly JvmOpCode Invokestatic = new(
            JvmCode.Invokestatic,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Var,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Invokevirtual" />
        public static readonly JvmOpCode Invokevirtual = new(
            JvmCode.Invokevirtual,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Var,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ior" />
        public static readonly JvmOpCode Ior = new(
            JvmCode.Ior,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Irem" />
        public static readonly JvmOpCode Irem = new(
            JvmCode.Irem,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ireturn" />
        public static readonly JvmOpCode Ireturn = new(
            JvmCode.Ireturn,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Return);

        /// <inheritdoc cref="JvmCode.Ishl" />
        public static readonly JvmOpCode Ishl = new(
            JvmCode.Ishl,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ishr" />
        public static readonly JvmOpCode Ishr = new(
            JvmCode.Ishr,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Istore" />
        public static readonly JvmOpCode Istore = new(
            JvmCode.Istore,
            JvmOperandType.LocalIndex,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Istore_0" />
        public static readonly JvmOpCode Istore_0 = new(
            JvmCode.Istore_0,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Istore_1" />
        public static readonly JvmOpCode Istore_1 = new(
            JvmCode.Istore_1,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Istore_2" />
        public static readonly JvmOpCode Istore_2 = new(
            JvmCode.Istore_2,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Istore_3" />
        public static readonly JvmOpCode Istore_3 = new(
            JvmCode.Istore_3,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Isub" />
        public static readonly JvmOpCode Isub = new(
            JvmCode.Isub,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Iushr" />
        public static readonly JvmOpCode Iushr = new(
            JvmCode.Iushr,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ixor" />
        public static readonly JvmOpCode Ixor = new(
            JvmCode.Ixor,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Jsr" />
        public static readonly JvmOpCode Jsr = new(
            JvmCode.Jsr,
            JvmOperandType.BranchOffset,
            JvmStackBehavior.Push1,
            JvmFlowControl.UnconditionalBranch);

        /// <inheritdoc cref="JvmCode.Jsr_W" />
        public static readonly JvmOpCode Jsr_W = new(
            JvmCode.Jsr_W,
            JvmOperandType.WideBranchOffset,
            JvmStackBehavior.Push1,
            JvmFlowControl.UnconditionalBranch);

        /// <inheritdoc cref="JvmCode.L2d" />
        public static readonly JvmOpCode L2d = new(
            JvmCode.L2d,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.L2f" />
        public static readonly JvmOpCode L2f = new(
            JvmCode.L2f,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.L2i" />
        public static readonly JvmOpCode L2i = new(
            JvmCode.L2i,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ladd" />
        public static readonly JvmOpCode Ladd = new(
            JvmCode.Ladd,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Laload" />
        public static readonly JvmOpCode Laload = new(
            JvmCode.Laload,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Land" />
        public static readonly JvmOpCode Land = new(
            JvmCode.Land,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lastore" />
        public static readonly JvmOpCode Lastore = new(
            JvmCode.Lastore,
            JvmOperandType.None,
            JvmStackBehavior.Pop3,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lcmp" />
        public static readonly JvmOpCode Lcmp = new(
            JvmCode.Lcmp,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lconst_0" />
        public static readonly JvmOpCode Lconst_0 = new(
            JvmCode.Lconst_0,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lconst_1" />
        public static readonly JvmOpCode Lconst_1 = new(
            JvmCode.Lconst_1,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ldc" />
        public static readonly JvmOpCode Ldc = new(
            JvmCode.Ldc,
            JvmOperandType.ConstantPoolIndex,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ldc_W" />
        public static readonly JvmOpCode Ldc_W = new(
            JvmCode.Ldc_W,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ldc2_W" />
        public static readonly JvmOpCode Ldc2_W = new(
            JvmCode.Ldc2_W,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ldiv" />
        public static readonly JvmOpCode Ldiv = new(
            JvmCode.Ldiv,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lload" />
        public static readonly JvmOpCode Lload = new(
            JvmCode.Lload,
            JvmOperandType.LocalIndex,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lload_0" />
        public static readonly JvmOpCode Lload_0 = new(
            JvmCode.Lload_0,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lload_1" />
        public static readonly JvmOpCode Lload_1 = new(
            JvmCode.Lload_1,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lload_2" />
        public static readonly JvmOpCode Lload_2 = new(
            JvmCode.Lload_2,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lload_3" />
        public static readonly JvmOpCode Lload_3 = new(
            JvmCode.Lload_3,
            JvmOperandType.None,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lmul" />
        public static readonly JvmOpCode Lmul = new(
            JvmCode.Lmul,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lneg" />
        public static readonly JvmOpCode Lneg = new(
            JvmCode.Lneg,
            JvmOperandType.None,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lookupswitch" />
        public static readonly JvmOpCode Lookupswitch = new(
            JvmCode.Lookupswitch,
            JvmOperandType.KeyJumpTable,
            JvmStackBehavior.Pop1,
            JvmFlowControl.UnconditionalBranch);

        /// <inheritdoc cref="JvmCode.Lor" />
        public static readonly JvmOpCode Lor = new(
            JvmCode.Lor,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lrem" />
        public static readonly JvmOpCode Lrem = new(
            JvmCode.Lrem,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lreturn" />
        public static readonly JvmOpCode Lreturn = new(
            JvmCode.Lreturn,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Return);

        /// <inheritdoc cref="JvmCode.Lshl" />
        public static readonly JvmOpCode Lshl = new(
            JvmCode.Lshl,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lshr" />
        public static readonly JvmOpCode Lshr = new(
            JvmCode.Lshr,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lstore" />
        public static readonly JvmOpCode Lstore = new(
            JvmCode.Lstore,
            JvmOperandType.LocalIndex,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lstore_0" />
        public static readonly JvmOpCode Lstore_0 = new(
            JvmCode.Lstore_0,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lstore_1" />
        public static readonly JvmOpCode Lstore_1 = new(
            JvmCode.Lstore_1,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lstore_2" />
        public static readonly JvmOpCode Lstore_2 = new(
            JvmCode.Lstore_2,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lstore_3" />
        public static readonly JvmOpCode Lstore_3 = new(
            JvmCode.Lstore_3,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lsub" />
        public static readonly JvmOpCode Lsub = new(
            JvmCode.Lsub,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lushr" />
        public static readonly JvmOpCode Lushr = new(
            JvmCode.Lushr,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Lxor" />
        public static readonly JvmOpCode Lxor = new(
            JvmCode.Lxor,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Monitorenter" />
        public static readonly JvmOpCode Monitorenter = new(
            JvmCode.Monitorenter,
            JvmOperandType.None,
            JvmStackBehavior.Undefined,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Monitorexit" />
        public static readonly JvmOpCode Monitorexit = new(
            JvmCode.Monitorexit,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Multinewarray" />
        public static readonly JvmOpCode Multinewarray = new(
            JvmCode.Multinewarray,
            JvmOperandType.WideConstantPoolIndexWithArrayDimensions,
            JvmStackBehavior.Var,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.New" />
        public static readonly JvmOpCode New = new(
            JvmCode.New,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Newarray" />
        public static readonly JvmOpCode Newarray = new(
            JvmCode.Newarray,
            JvmOperandType.ArrayType,
            JvmStackBehavior.Pop1Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Nop" />
        public static readonly JvmOpCode Nop = new(
            JvmCode.Nop,
            JvmOperandType.None,
            JvmStackBehavior.Nop,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Pop" />
        public static readonly JvmOpCode Pop = new(
            JvmCode.Pop,
            JvmOperandType.None,
            JvmStackBehavior.Pop1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Pop2" />
        public static readonly JvmOpCode Pop2 = new(
            JvmCode.Pop2,
            JvmOperandType.None,
            JvmStackBehavior.Var,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Putfield" />
        public static readonly JvmOpCode Putfield = new(
            JvmCode.Putfield,
            JvmOperandType.None,
            JvmStackBehavior.Undefined,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Putstatic" />
        public static readonly JvmOpCode Putstatic = new(
            JvmCode.Putstatic,
            JvmOperandType.WideConstantPoolIndex,
            JvmStackBehavior.Pop2,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Ret" />
        public static readonly JvmOpCode Ret = new(
            JvmCode.Ret,
            JvmOperandType.LocalIndex,
            JvmStackBehavior.Pop1,
            JvmFlowControl.UnconditionalBranch);

        /// <inheritdoc cref="JvmCode.Return" />
        public static readonly JvmOpCode Return = new(
            JvmCode.Return,
            JvmOperandType.None,
            JvmStackBehavior.Nop,
            JvmFlowControl.Return);

        /// <inheritdoc cref="JvmCode.Saload" />
        public static readonly JvmOpCode Saload = new(
            JvmCode.Saload,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Sastore" />
        public static readonly JvmOpCode Sastore = new(
            JvmCode.Sastore,
            JvmOperandType.None,
            JvmStackBehavior.Pop3,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Sipush" />
        public static readonly JvmOpCode Sipush = new(
            JvmCode.Sipush,
            JvmOperandType.InlineShort,
            JvmStackBehavior.Push1,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Swap" />
        public static readonly JvmOpCode Swap = new(
            JvmCode.Swap,
            JvmOperandType.None,
            JvmStackBehavior.Pop2Push2,
            JvmFlowControl.Fallthrough);

        /// <inheritdoc cref="JvmCode.Tableswitch" />
        public static readonly JvmOpCode Tableswitch = new(
            JvmCode.Tableswitch,
            JvmOperandType.IndexJumpTable,
            JvmStackBehavior.Pop1,
            JvmFlowControl.UnconditionalBranch);

        /// <inheritdoc cref="JvmCode.Wide" />
        public static readonly JvmOpCode Wide = new(
            JvmCode.Wide,
            JvmOperandType.None,
            JvmStackBehavior.Nop,
            JvmFlowControl.Fallthrough);
        
        /// <inheritdoc cref="JvmCode.Imdep1"/>
        public static readonly JvmOpCode Imdep1 = new(
            JvmCode.Imdep1,
            JvmOperandType.Undefined,
            JvmStackBehavior.Undefined,
            JvmFlowControl.Undefined);
            
        /// <inheritdoc cref="JvmCode.Imdep2"/>
        public static readonly JvmOpCode Imdep2 = new(
            JvmCode.Imdep2,
            JvmOperandType.Undefined,
            JvmStackBehavior.Undefined,
            JvmFlowControl.Undefined);
        
        /// <inheritdoc cref="JvmCode.Breakpoint"/>
        public static readonly JvmOpCode Breakpoint = new(
            JvmCode.Breakpoint,
            JvmOperandType.Undefined,
            JvmStackBehavior.Undefined,
            JvmFlowControl.Undefined);
    }
}