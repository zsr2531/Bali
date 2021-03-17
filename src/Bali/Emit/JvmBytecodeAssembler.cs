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
            bool isWide = false, needsAlignment = writer.Position % 4 == 0;

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
                    WriteOperand(instruction, writer, needsAlignment);
                
                isWide = false;
            }
        }

        /// <summary>
        /// Serializes the operand of a given <see cref="JvmInstruction"/>.
        /// </summary>
        /// <param name="instruction">The <see cref="JvmInstruction"/> to write the <see cref="JvmInstruction.Operand"/> of.</param>
        /// <param name="writer">The <see cref="IBigEndianWriter"/> to write data to.</param>
        /// <param name="needsAlignment">Whether some operands need to be 4-byte aligned.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// When the <paramref name="instruction"/>'s <see cref="JvmOpCode"/> has an <see cref="JvmOperandType.Undefined"/> operand type.
        /// </exception>
        protected static void WriteOperand(JvmInstruction instruction, IBigEndianWriter writer, bool needsAlignment)
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
                case JvmOperandType.IndexJumpTable:
                    throw new NotImplementedException();

                case JvmOperandType.LocalIndex:
                    writer.WriteU1(CastOperand<byte>(operand));
                    break;

                case JvmOperandType.LocalIndexWithSignedByte:
                    var real = CastOperand<LocalIndexWithSignedByte>(operand);
                    writer.WriteU1(real.LocalIndex);
                    writer.WriteI1(real.SignedByte);
                    break;

                case JvmOperandType.ConstantPoolIndex:
                    writer.WriteU1(CastOperand<byte>(operand));
                    break;

                case JvmOperandType.WideConstantPoolIndex:
                    writer.WriteU2(CastOperand<ushort>(operand));
                    break;

                case JvmOperandType.WideConstantPoolIndexWithArrayDimensions:
                    var op = CastOperand<WideConstantPoolIndexWithArrayDimensions>(operand);
                    writer.WriteU2(op.WideConstantPoolIndex);
                    writer.WriteU1(op.ArrayDimensions);
                    break;
                
                case JvmOperandType.WideConstantPoolIndexWithTwoBytes:
                    var op1 = CastOperand<WideConstantPoolIndexWithTwoBytes>(operand);
                    writer.WriteU2(op1.WideConstantPoolIndex);
                    writer.WriteU1(op1.ByteOne);
                    writer.WriteU1(op1.ByteTwo);
                    break;

                case JvmOperandType.ArrayType:
                    writer.WriteU1((byte) CastOperand<JvmPrimitiveArrayType>(operand));
                    break;

                case JvmOperandType.BranchOffset:
                    writer.WriteI2(CastOperand<short>(operand));
                    break;
                
                case JvmOperandType.InlineByte:
                    writer.WriteI1(CastOperand<sbyte>(operand));
                    break;

                case JvmOperandType.InlineShort:
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
    }
}
