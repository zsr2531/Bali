using System;
using System.Buffers;
using System.IO;
using Bali.IO;

namespace Bali.Constants
{
    /// <summary>
    /// Provides methods to serialize <see cref="Constant"/>s to the given output <see cref="Stream"/>.
    /// </summary>
    public static class ConstantWriter
    {
        private static readonly ArrayPool<byte> Pool = ArrayPool<byte>.Create();

        /// <summary>
        /// Writes the <paramref name="constant"/> to the given output <paramref name="writer"/>.
        /// </summary>
        /// <param name="constant">The <see cref="Constant"/> to serialize.</param>
        /// <param name="writer">The <see cref="BigEndianWriter"/> to write data to.</param>
        public static void BuildConstant(Constant constant, IBigEndianWriter writer)
        {
            writer.WriteU1((byte) constant.Tag);
            switch (constant)
            {
                case ClassConstant classConstant:
                    writer.WriteU2(classConstant.NameIndex);
                    break;

                case FieldrefConstant fieldrefConstant:
                    writer.WriteU2(fieldrefConstant.ClassIndex);
                    writer.WriteU2(fieldrefConstant.NameAndTypeIndex);
                    break;

                case MethodrefConstant methodrefConstant:
                    writer.WriteU2(methodrefConstant.ClassIndex);
                    writer.WriteU2(methodrefConstant.NameAndTypeIndex);
                    break;

                case InterfaceMethodrefConstant interfaceMethodrefConstant:
                    writer.WriteU2(interfaceMethodrefConstant.ClassIndex);
                    writer.WriteU2(interfaceMethodrefConstant.NameAndTypeIndex);
                    break;

                case StringConstant stringConstant:
                    writer.WriteU2(stringConstant.StringIndex);
                    break;

                case IntegerConstant integerConstant:
                    writer.WriteI4(integerConstant.Value);
                    break;

                case FloatConstant floatConstant:
                    writer.WriteR4(floatConstant.Value);
                    break;

                case LongConstant longConstant:
                    writer.WriteI8(longConstant.Value);
                    break;

                case DoubleConstant doubleConstant:
                    writer.WriteR8(doubleConstant.Value);
                    break;

                case NameAndTypeConstant nameAndTypeConstant:
                    writer.WriteU2(nameAndTypeConstant.NameIndex);
                    writer.WriteU2(nameAndTypeConstant.DescriptorIndex);
                    break;

                case Utf8Constant utf8Constant:
                    WriteUtf8Constant(utf8Constant, writer);
                    break;

                case MethodHandleConstant methodHandleConstant:
                    writer.WriteU1((byte) methodHandleConstant.ReferenceKind);
                    writer.WriteU2(methodHandleConstant.ReferenceIndex);
                    break;

                case MethodTypeConstant methodTypeConstant:
                    writer.WriteU2(methodTypeConstant.DescriptorIndex);
                    break;

                case InvokeDynamicConstant invokeDynamicConstant:
                    writer.WriteU2(invokeDynamicConstant.BootstrapMethodAttributeIndex);
                    writer.WriteU2(invokeDynamicConstant.NameAndTypeIndex);
                    break;

                default:
                    throw new NotSupportedException($"Unsupported constant type: {constant.GetType().FullName}");
            }
        }

        private static void WriteUtf8Constant(Utf8Constant constant, IBigEndianWriter writer)
        {
            var encoder = JavaUtf8.Instance;
            string value = constant.Value;
            byte[] array = Pool.Rent(encoder.GetMaxByteCount(value.Length));
            int chars = encoder.GetBytes(value, 0, value.Length, array, 0);
            
            writer.WriteU2((ushort) chars);
            writer.Write(array.AsSpan().Slice(0, chars));
            Pool.Return(array, true);
        }
    }
}