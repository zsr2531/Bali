using System;
using System.Collections.Generic;
using System.IO;
using Bali.Emit.Operands;
using Bali.IO;

namespace Bali.Emit
{
    /// <summary>
    /// Provides a basic implementation of the <see cref="IJvmBytecodeDisassembler"/> contract.
    /// </summary>
    public class JvmBytecodeDisassembler : IJvmBytecodeDisassembler
    {
        /// <summary>
        /// Provides a singleton <see cref="JvmBytecodeDisassembler"/> instance.
        /// </summary>
        public static readonly JvmBytecodeDisassembler Instance = new();

        /// <summary>
        /// Default parameterless constructor.
        /// </summary>
        protected JvmBytecodeDisassembler() { }

        /// <inheritdoc />
        public IList<JvmInstruction> Disassemble(IBigEndianReader reader, uint count)
        {
            var instructions = new List<JvmInstruction>();
            bool isWide = false;
            bool needsAlignment = reader.Position % 4 == 0;
            long start = reader.Position;
            
            while (reader.Position - start < count)
            {
                int current = (int) (reader.Position - start);
                byte raw = reader.ReadU1();
                if (!JvmOpCodes.OpCodes.TryGetValue(raw, out var opCode))
                    throw new DisassemblyException($"Unknown opcode: 0x{raw:X2}");

                if (opCode == JvmOpCodes.Wide)
                {
                    isWide = true;
                    instructions.Add(new JvmInstruction(current, opCode));
                    continue;
                }

                var operand = isWide
                    ? ReadWideOperand(reader, opCode)
                    : ReadOperand(current, reader, opCode.OperandType, needsAlignment);
                
                instructions.Add(new JvmInstruction(current, opCode, operand));
                isWide = false;
            }

            return instructions;
        }

        /// <summary>
        /// Deserializes the operand based on the <paramref name="type"/>.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="reader">The <see cref="IBigEndianReader"/> to read from.</param>
        /// <param name="type">The <see cref="JvmOperandType"/> to read.</param>
        /// <param name="needsAlignment">Whether some operands need to be 4-byte aligned.</param>
        /// <returns>The deserialized operand.</returns>
        protected static object? ReadOperand(int offset, IBigEndianReader reader, JvmOperandType type, bool needsAlignment)
        {
            return type switch
            {
                JvmOperandType.None => null,
                JvmOperandType.BranchOffset => reader.ReadI2(),
                JvmOperandType.WideBranchOffset => reader.ReadI4(),
                JvmOperandType.KeyJumpTable => ReadLookupSwitchOperand(offset, reader, needsAlignment),
                JvmOperandType.IndexJumpTable => ReadTableSwitchOperand(offset, reader, needsAlignment),
                JvmOperandType.LocalIndex => reader.ReadU1(),
                JvmOperandType.LocalIndexWithSignedByte => new LocalIndexWithSignedByte(reader.ReadU1(), reader.ReadI1()),
                JvmOperandType.ConstantPoolIndex => reader.ReadU1(),
                JvmOperandType.WideConstantPoolIndex => reader.ReadU2(),
                JvmOperandType.WideConstantPoolIndexWithArrayDimensions => new WideConstantPoolIndexWithArrayDimensions(reader.ReadU2(), reader.ReadU1()),
                JvmOperandType.WideConstantPoolIndexWithTwoBytes => new WideConstantPoolIndexWithTwoBytes(reader.ReadU2(), reader.ReadU1(), reader.ReadU1()),
                JvmOperandType.ArrayType => (JvmPrimitiveArrayType) reader.ReadU1(),
                JvmOperandType.InlineByte => reader.ReadI1(),
                JvmOperandType.InlineShort => reader.ReadI2(),
                _ => throw new ArgumentOutOfRangeException(nameof(type))
            };
        }

        /// <summary>
        /// Deserializes the opcode's operand's wide version based on the <paramref name="opCode"/>.
        /// </summary>
        /// <param name="reader">The input <see cref="IBigEndianReader"/> to read from.</param>
        /// <param name="opCode">The <see cref="JvmOpCode"/> to deserialize the operand of.</param>
        /// <returns>The deserialized operand.</returns>
        protected static object ReadWideOperand(IBigEndianReader reader, JvmOpCode opCode)
        {
            if (opCode != JvmOpCodes.Iinc)
                return reader.ReadU2();
            
            ushort index = reader.ReadU2();
            short constant = reader.ReadI2();
            return new WideLocalIndexWithSignedShort(index, constant);
        }

        private static object ReadLookupSwitchOperand(int offset, IBigEndianReader reader, bool needsAlignment)
        {
            AlignOn4ByteBoundary(offset, reader, needsAlignment);
            int @default = reader.ReadI4();
            int count = reader.ReadI4();
            var buffer = new Dictionary<int, int>(count);

            for (int i = 0; i < count; i++)
                buffer.Add(reader.ReadI4(), reader.ReadI4());
            
            return new KeyJumpTable(@default, buffer);
        }

        private static object ReadTableSwitchOperand(int offset, IBigEndianReader reader, bool needsAlignment)
        {
            AlignOn4ByteBoundary(offset, reader, needsAlignment);
            int @default = reader.ReadI4();
            int low = reader.ReadI4();
            int high = reader.ReadI4();
            var buffer = new List<int>(high - low + 1);

            for (int i = 0; i < buffer.Capacity; i++)
                buffer.Add(reader.ReadI4());
            
            return new IndexJumpTable(@default, low, high, buffer);
        }

        private static void AlignOn4ByteBoundary(int offset, IBigEndianReader reader, bool needsAlignment)
        {
            if (!needsAlignment)
                return;
            
            int padding = offset % 4;
            for (int i = 0; i < padding; i++)
                reader.ReadU1();
        }
    }
}
