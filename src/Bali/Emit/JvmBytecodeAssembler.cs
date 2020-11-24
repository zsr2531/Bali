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
        public void Assemble(IList<JvmInstruction> instructions, Stream stream)
        {
            bool isWide = false, needsAlignment = stream.Position % 4 == 0;

            foreach (var instruction in instructions)
            {
                stream.WriteU1((byte) instruction.OpCode.Code);
                
                if (instruction.OpCode == JvmOpCodes.Wide)
                {
                    isWide = true;
                    continue;
                }

                if (isWide)
                    WriteWideOperand(instruction, stream);
                else
                    WriteOperand(instruction, stream, needsAlignment);
                
                isWide = false;
            }
        }

        protected static void WriteOperand(JvmInstruction instruction, Stream stream, bool needsAlignment)
        {
            var operand = instruction.Operand;
            
            switch (instruction.OpCode.OperandType)
            {
                case JvmOperandType.None:
                    break;

                case JvmOperandType.WideBranchOffset:
                    stream.WriteI4(CastOperand<int>(operand));
                    break;

                case JvmOperandType.KeyJumpTable:
                    break;

                case JvmOperandType.IndexJumpTable:
                    break;

                case JvmOperandType.LocalIndex:
                    stream.WriteU1(CastOperand<byte>(operand));
                    break;

                case JvmOperandType.LocalIndexWithSignedByte:
                    var real = CastOperand<LocalIndexWithSignedByte>(operand);
                    stream.WriteU2(real.LocalIndex);
                    stream.WriteI1(real.SignedByte);
                    break;

                case JvmOperandType.ConstantPoolIndex:
                    stream.WriteU1(CastOperand<byte>(operand));
                    break;

                case JvmOperandType.WideConstantPoolIndex:
                    stream.WriteU2(CastOperand<ushort>(operand));
                    break;

                case JvmOperandType.WideConstantPoolIndexWithArrayDimensions:
                    break;

                case JvmOperandType.WideConstantPoolIndexWithTwoBytes:
                    break;

                case JvmOperandType.ArrayType:
                    stream.WriteU1((byte) CastOperand<JvmPrimitiveArrayType>(operand));
                    break;

                case JvmOperandType.BranchOffset:
                case JvmOperandType.InlineByte:
                    stream.WriteI1(CastOperand<sbyte>(operand));
                    break;

                case JvmOperandType.InlineShort:
                    stream.WriteI2(CastOperand<short>(operand));
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected static void WriteWideOperand(JvmInstruction instruction, Stream stream)
        {
            if (instruction.OpCode != JvmOpCodes.Iinc)
                stream.WriteU2(CastOperand<ushort>(instruction.Operand));

            var operand = CastOperand<WideLocalIndexWithSignedShort>(instruction.Operand);
            stream.WriteU2(operand.LocalIndex);
            stream.WriteI2(operand.SignedShort);
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