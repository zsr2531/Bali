using System;
using System.Buffers;
using System.IO;
using Bali.IO;

namespace Bali.Constants
{
    /// <summary>
    /// Provides methods to serialize <see cref="Constant"/>s to the given output <see cref="Stream"/>.
    /// </summary>
    public static class ConstantBuilder
    {
        private static readonly ArrayPool<byte> Pool = ArrayPool<byte>.Create();

        /// <summary>
        /// Writes the <paramref name="constant"/> to the given output <paramref name="stream"/>.
        /// </summary>
        /// <param name="constant">The <see cref="Constant"/> to serialize.</param>
        /// <param name="stream">The input <see cref="Stream"/> to write data to.</param>
        public static void BuildConstant(Constant constant, Stream stream)
        {
            stream.WriteU1((byte) constant.Tag);
            switch (constant)
            {
                case ClassConstant classConstant:
                    stream.WriteU2(classConstant.NameIndex);
                    break;

                case FieldrefConstant fieldrefConstant:
                    stream.WriteU2(fieldrefConstant.ClassIndex);
                    stream.WriteU2(fieldrefConstant.NameAndTypeIndex);
                    break;

                case MethodrefConstant methodrefConstant:
                    stream.WriteU2(methodrefConstant.ClassIndex);
                    stream.WriteU2(methodrefConstant.NameAndTypeIndex);
                    break;

                case InterfaceMethodrefConstant interfaceMethodrefConstant:
                    stream.WriteU2(interfaceMethodrefConstant.ClassIndex);
                    stream.WriteU2(interfaceMethodrefConstant.NameAndTypeIndex);
                    break;

                case StringConstant stringConstant:
                    stream.WriteU2(stringConstant.StringIndex);
                    break;

                case IntegerConstant integerConstant:
                    stream.WriteI4(integerConstant.Value);
                    break;

                case FloatConstant floatConstant:
                    stream.WriteR4(floatConstant.Value);
                    break;

                case LongConstant longConstant:
                    stream.WriteI8(longConstant.Value);
                    break;

                case DoubleConstant doubleConstant:
                    stream.WriteR8(doubleConstant.Value);
                    break;

                case NameAndTypeConstant nameAndTypeConstant:
                    stream.WriteU2(nameAndTypeConstant.NameIndex);
                    stream.WriteU2(nameAndTypeConstant.DescriptorIndex);
                    break;

                case Utf8Constant utf8Constant:
                    var encoder = JavaUtf8.Instance;
                    string value = utf8Constant.Value;
                    byte[] array = Pool.Rent(encoder.GetMaxByteCount(value.Length));
                    int chars = encoder.GetBytes(value, 0, value.Length, array, 0);
                    stream.WriteU2((ushort) chars);
                    stream.Write(array, 0, chars);
                    Pool.Return(array, true);
                    break;

                case MethodHandleConstant methodHandleConstant:
                    stream.WriteU1((byte) methodHandleConstant.ReferenceKind);
                    stream.WriteU2(methodHandleConstant.ReferenceIndex);
                    break;

                case MethodTypeConstant methodTypeConstant:
                    stream.WriteU2(methodTypeConstant.DescriptorIndex);
                    break;

                case InvokeDynamicConstant invokeDynamicConstant:
                    stream.WriteU2(invokeDynamicConstant.BootstrapMethodAttributeIndex);
                    stream.WriteU2(invokeDynamicConstant.NameAndTypeIndex);
                    break;

                default:
                    throw new NotSupportedException($"Unsupported constant type: {constant.GetType().FullName}");
            }
        }
    }
}