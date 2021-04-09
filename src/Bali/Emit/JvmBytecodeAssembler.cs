using System;
using System.Collections.Generic;
using System.IO;
using Bali.Emit.Operands;
using Bali.IO;

namespace Bali.Emit
{
    /// <summary>
    /// Provides a basic implementation of the <see cref="IJvmBytecodeAssembler"/> contract.
    /// </summary>
    public class JvmBytecodeAssembler : IJvmBytecodeAssembler
    {
        /// <summary>
        /// Provides a singleton <see cref="JvmBytecodeAssembler"/> instance.
        /// </summary>
        public static readonly JvmBytecodeAssembler Instance = new();

        /// <summary>
        /// Default parameterless constructor.
        /// </summary>
        protected JvmBytecodeAssembler() { }

        /// <inheritdoc />
        public void Assemble(IList<JvmInstruction> instructions, IBigEndianWriter writer)
        {
            bool isWide = false;

            foreach (var instruction in instructions)
            {
                writer.WriteU1((byte) instruction.OpCode.Code);
                
                if (instruction.OpCode == JvmOpCodes.Wide)
                {
                    isWide = true;
                    continue;
                }

                if (isWide)
                    WriteWideOperand(instruction, writer);
                else
                    WriteOperand(instruction, writer);
                
                isWide = false;
            }
        }

        /// <summary>
        /// Serializes the operand of a given <see cref="JvmInstruction"/>.
        /// </summary>
        /// <param name="instruction">The <see cref="JvmInstruction"/> to write the <see cref="JvmInstruction.Operand"/> of.</param>
        /// <param name="writer">The <see cref="IBigEndianWriter"/> to write data to.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// When the <paramref name="instruction"/>'s <see cref="JvmOpCode"/> has an <see cref="JvmOperandType.Undefined"/> operand type.
        /// </exception>
        protected static void WriteOperand(JvmInstruction instruction, IBigEndianWriter writer)
        {
            var operand = instruction.Operand;
            
            switch (instruction.OpCode.OperandType)
            {
                case JvmOperandType.None:
                    break;

                case JvmOperandType.WideBranchOffset:
                    writer.WriteI4(CastOperand<int>(operand));
                    break;

                case JvmOperandType.KeyJumpTable:
                    var keyJumpTable = CastOperand<KeyJumpTable>(operand);
                    AlignOn4ByteBoundary(writer);
                    writer.WriteI4(keyJumpTable.Default);
                    writer.WriteI4(keyJumpTable.Matches.Count);
                    foreach (var pair in keyJumpTable.Matches)
                    {
                        writer.WriteI4(pair.Key);
                        writer.WriteI4(pair.Value);
                    }
                    break;
                
                case JvmOperandType.IndexJumpTable:
                    var indexJumpTable = CastOperand<IndexJumpTable>(operand);
                    AlignOn4ByteBoundary(writer);
                    writer.WriteI4(indexJumpTable.Default);
                    writer.WriteI4(indexJumpTable.Low);
                    writer.WriteI4(indexJumpTable.High);
                    foreach (int offset in indexJumpTable.Offsets)
                        writer.WriteI4(offset);
                    break;

                case JvmOperandType.LocalIndexWithSignedByte:
                    var localIndexWithSignedByte = CastOperand<LocalIndexWithSignedByte>(operand);
                    writer.WriteU1(localIndexWithSignedByte.LocalIndex);
                    writer.WriteI1(localIndexWithSignedByte.SignedByte);
                    break;

                case JvmOperandType.LocalIndex:
                case JvmOperandType.ConstantPoolIndex:
                    writer.WriteU1(CastOperand<byte>(operand));
                    break;

                case JvmOperandType.WideConstantPoolIndex:
                    writer.WriteU2(CastOperand<ushort>(operand));
                    break;

                case JvmOperandType.WideConstantPoolIndexWithArrayDimensions:
                    var wideConstantPoolIndexWithArrayDimensions = CastOperand<WideConstantPoolIndexWithArrayDimensions>(operand);
                    writer.WriteU2(wideConstantPoolIndexWithArrayDimensions.WideConstantPoolIndex);
                    writer.WriteU1(wideConstantPoolIndexWithArrayDimensions.ArrayDimensions);
                    break;
                
                case JvmOperandType.WideConstantPoolIndexWithTwoBytes:
                    var wideConstantPoolIndexWithTwoBytes = CastOperand<WideConstantPoolIndexWithTwoBytes>(operand);
                    writer.WriteU2(wideConstantPoolIndexWithTwoBytes.WideConstantPoolIndex);
                    writer.WriteU1(wideConstantPoolIndexWithTwoBytes.ByteOne);
                    writer.WriteU1(wideConstantPoolIndexWithTwoBytes.ByteTwo);
                    break;

                case JvmOperandType.ArrayType:
                    writer.WriteU1((byte) CastOperand<JvmPrimitiveArrayType>(operand));
                    break;

                case JvmOperandType.InlineByte:
                    writer.WriteI1(CastOperand<sbyte>(operand));
                    break;

                case JvmOperandType.InlineShort:
                case JvmOperandType.BranchOffset:
                    writer.WriteI2(CastOperand<short>(operand));
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Serializes the wide version of the operand of a given <see cref="JvmInstruction"/>.
        /// </summary>
        /// <param name="instruction">The <see cref="JvmInstruction"/> to write the <see cref="JvmInstruction.Operand"/> of.</param>
        /// <param name="writer">The <see cref="IBigEndianWriter"/> to write data to.</param>
        protected static void WriteWideOperand(JvmInstruction instruction, IBigEndianWriter writer)
        {
            if (instruction.OpCode != JvmOpCodes.Iinc)
                writer.WriteU2(CastOperand<ushort>(instruction.Operand));

            var operand = CastOperand<WideLocalIndexWithSignedShort>(instruction.Operand);
            writer.WriteU2(operand.LocalIndex);
            writer.WriteI2(operand.SignedShort);
        }

        private static T CastOperand<T>(object? operand)
        {
            if (operand is T cast)
                return cast;
            
            string operandTypeName = operand?.GetType().Name ?? "null";
            string message = $"Operand type expected to be {typeof(T).Name} but instead is {operandTypeName}";
            throw new AssemblyException(message);
        }

        private static void AlignOn4ByteBoundary(IBigEndianWriter writer)
        {
            long padding = writer.Position % 4;
            for (int i = 0; i < padding; i++)
                writer.WriteU1(0);
        }
    }
}
