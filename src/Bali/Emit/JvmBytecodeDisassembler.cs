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
        /// Provides a singleton JvmBytecodeDisassembler instance.
        /// </summary>
        public static readonly JvmBytecodeDisassembler Instance = new();

        /// <summary>
        /// Default parameterless constructor.
        /// </summary>
        protected JvmBytecodeDisassembler() { }

        /// <inheritdoc />
        public IList<JvmInstruction> Disassemble(Stream stream, uint count)
        {
            var instructions = new List<JvmInstruction>();
            bool isWide = false;
            bool needsAlignment = stream.Position % 4 == 0;
            long start = stream.Position;
            
            while (stream.Position - start < count)
            {
                int current = (int) (stream.Position - start);
                byte raw = stream.ReadU1();
                if (!JvmOpCodes.OpCodes.TryGetValue(raw, out var opCode))
                    throw new DisassemblyException($"Unknown opcode: 0x{raw:X2}");

                if (opCode == JvmOpCodes.Wide)
                {
                    isWide = true;
                    instructions.Add(new JvmInstruction(current, opCode));
                    continue;
                }

                var operand = isWide
                    ? ReadWideOperand(stream, opCode)
                    : ReadOperand(current, stream, opCode.OperandType, needsAlignment);
                
                instructions.Add(new JvmInstruction(current, opCode, operand));
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
        /// <param name="needsAlignment">Whether some operands need to be 4-byte aligned.</param>
        /// <returns>The deserialized operand.</returns>
        protected static object? ReadOperand(int offset, Stream stream, JvmOperandType type, bool needsAlignment)
        {
            return type switch
            {
                JvmOperandType.None => null,
                JvmOperandType.BranchOffset => stream.ReadI2(),
                JvmOperandType.WideBranchOffset => stream.ReadI4(),
                JvmOperandType.KeyJumpTable => ReadLookupSwitchOperand(offset, stream, needsAlignment),
                JvmOperandType.IndexJumpTable => ReadTableSwitchOperand(offset, stream, needsAlignment),
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

        private static object ReadLookupSwitchOperand(int offset, Stream stream, bool needsAlignment)
        {
            AlignOn4ByteBoundary(offset, stream, needsAlignment);
            int @default = stream.ReadI4();
            int count = stream.ReadI4();
            var buffer = new Dictionary<int, int>(count);

            for (int i = 0; i < count; i++)
                buffer.Add(stream.ReadI4(), stream.ReadI4());
            
            return new KeyJumpTable(@default, buffer);
        }

        private static object ReadTableSwitchOperand(int offset, Stream stream, bool needsAlignment)
        {
            AlignOn4ByteBoundary(offset, stream, needsAlignment);
            int @default = stream.ReadI4();
            int low = stream.ReadI4();
            int high = stream.ReadI4();
            var buffer = new List<int>(high - low + 1);

            for (int i = 0; i < buffer.Capacity; i++)
                buffer.Add(stream.ReadI4());
            
            return new IndexJumpTable(@default, low, high, buffer);
        }

        private static void AlignOn4ByteBoundary(int offset, Stream stream, bool needsAlignment)
        {
            if (!needsAlignment)
                return;
            
            int padding = offset % 4;
            for (int i = 0; i < padding; i++)
                stream.ReadU1();
        }
    }
}