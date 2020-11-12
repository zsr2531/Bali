using System;
using System.Collections.Generic;
using System.IO;
using Bali.Emit.Operands;
using Bali.IO;

namespace Bali.Emit
{
    public class JvmBytecodeDisassembler : IJvmBytecodeDisassembler
    {
        /// <inheritdoc />
        public IList<JvmInstruction> Disassemble(Stream stream, uint count)
        {
            var instructions = new List<JvmInstruction>();
            bool isWide = false;

            for (int i = 0; i < count; i++)
            {
                byte raw = stream.ReadU1();
                if (!JvmOpCodes.OpCodes.TryGetValue(raw, out var opCode))
                    throw null; // TODO: Throw more meaningful exception kekw

                if (opCode == JvmOpCodes.Wide)
                {
                    isWide = true;
                    instructions.Add(new JvmInstruction(i, opCode));
                    continue;
                }

                var operand = isWide
                    ? ReadWideOperand(stream, opCode)
                    : ReadOperand(i, stream, opCode.OperandType);
                
                instructions.Add(new JvmInstruction(i, opCode, operand));
                isWide = false;
            }

            return instructions;
        }

        /// <summary>
        /// Deserializes the operand based on the <paramref name="type"/>.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="stream">The input <see cref="Stream"/> to read from.</param>
        /// <param name="type">The <see cref="JvmOperandType"/> to read.</param>
        /// <returns>The deserialized operand.</returns>
        protected static object? ReadOperand(int offset, Stream stream, JvmOperandType type)
        {
            return type switch
            {
                JvmOperandType.None => null,
                JvmOperandType.BranchOffset => stream.ReadI1(),
                JvmOperandType.WideBranchOffset => stream.ReadI2(),
                JvmOperandType.LookupSwitchJumpTable => ReadLookupSwitchTable(offset, stream),
                JvmOperandType.TableSwitchJumpTable => ReadTableSwitchTable(offset, stream),
                JvmOperandType.LocalIndex => stream.ReadU1(),
                JvmOperandType.LocalIndexWithSignedByte => new LocalIndexWithSignedByte(stream.ReadU1(), stream.ReadI1()),
                JvmOperandType.ConstantPoolIndex => stream.ReadU1(),
                JvmOperandType.WideConstantPoolIndex => stream.ReadU2(),
                JvmOperandType.WideConstantPoolIndexWithArrayDimensions => new WideConstantPoolIndexWithArrayDimensions(stream.ReadU2(), stream.ReadU1()),
                JvmOperandType.WideConstantPoolIndexWithTwoBytes => new WideConstantPoolIndexWithTwoBytes(stream.ReadU2(), stream.ReadU1(), stream.ReadU1()),
                JvmOperandType.ArrayType => (JvmPrimitiveArrayType) stream.ReadU1(),
                JvmOperandType.InlineByte => stream.ReadI1(),
                JvmOperandType.InlineShort => stream.ReadI2(),
                _ => throw new ArgumentOutOfRangeException(nameof(type))
            };
        }

        /// <summary>
        /// Deserializes the opcode's operand's wide version based on the <paramref name="opCode"/>.
        /// </summary>
        /// <param name="stream">The input <see cref="Stream"/> to read from.</param>
        /// <param name="opCode">The <see cref="JvmOpCode"/> to deserialize the operand of.</param>
        /// <returns>The deserialized operand.</returns>
        protected static object ReadWideOperand(Stream stream, JvmOpCode opCode)
        {
            if (opCode != JvmOpCodes.Iinc)
                return stream.ReadU2();
            
            ushort index = stream.ReadU2();
            short constant = stream.ReadI2();
            return new WideLocalIndexWithSignedShort(index, constant);
        }

        private static object ReadLookupSwitchTable(int offset, Stream stream)
        {
            AlignOn4ByteBoundary(offset, stream);
            int @default = stream.ReadI4();
            int count = stream.ReadI4();
            var buffer = new Dictionary<int, int>(count);

            for (int i = 0; i < count; i++)
                buffer.Add(stream.ReadI4(), stream.ReadI4());
            
            return new LookupSwitchTable(@default, buffer);
        }

        private static object ReadTableSwitchTable(int offset, Stream stream)
        {
            AlignOn4ByteBoundary(offset, stream);
            int @default = stream.ReadI4();
            int low = stream.ReadI4();
            int high = stream.ReadI4();
            var buffer = new List<int>(high - low + 1);

            for (int i = 0; i < buffer.Capacity; i++)
                buffer.Add(stream.ReadI4());
            
            return new TableSwitchTable(@default, low, high, buffer);
        }

        private static void AlignOn4ByteBoundary(int offset, Stream stream)
        {
            int padding = offset % 4;
            for (int i = 0; i < padding; i++)
                stream.ReadU1();
        }
    }
}