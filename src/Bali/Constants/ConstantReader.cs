using System;
using System.Buffers;
using System.IO;
using Bali.IO;

namespace Bali.Constants
{
    /// <summary>
    /// Provides methods to deserialize <see cref="Constant"/>s from the given input <see cref="Stream"/>.
    /// </summary>
    public static class ConstantReader
    {
        private static readonly ArrayPool<byte> Pool = ArrayPool<byte>.Create();
        
        /// <summary>
        /// Reads the next <see cref="Constant"/> from the given input <paramref name="reader"/>.
        /// </summary>
        /// <param name="reader">The input <see cref="IBigEndianReader"/> to read data from.</param>
        /// <returns>The deserialized <see cref="Constant"/>.</returns>
        public static Constant CreateConstant(IBigEndianReader reader)
        {
            byte tag = reader.ReadU1();

            return (ConstantKind) tag switch
            {
                ConstantKind.Class => CreateClassConstant(reader),
                ConstantKind.Fieldref => CreateFieldrefConstant(reader),
                ConstantKind.Methodref => CreateMethodrefConstant(reader),
                ConstantKind.InterfaceMethodref => CreateInterfaceMethodrefConstant(reader),
                ConstantKind.String => CreateStringConstant(reader),
                ConstantKind.Integer => CreateIntegerConstant(reader),
                ConstantKind.Float => CreateFloatConstant(reader),
                ConstantKind.Long => CreateLongConstant(reader),
                ConstantKind.Double => CreateDoubleConstant(reader),
                ConstantKind.NameAndType => CreateNameAndTypeConstant(reader),
                ConstantKind.Utf8 => CreateUtf8Constant(reader),
                ConstantKind.MethodHandle => CreateMethodHandleConstant(reader),
                ConstantKind.MethodType => CreateMethodTypeConstant(reader),
                ConstantKind.InvokeDynamic => CreateInvokeDynamicConstant(reader),
                _ => throw new NotSupportedException($"Not supported constant tag: 0x{tag}.")
            };
        }

        private static ClassConstant CreateClassConstant(IBigEndianReader reader) =>
            new(reader.ReadU2());

        private static FieldrefConstant CreateFieldrefConstant(IBigEndianReader reader) =>
            new(reader.ReadU2(), reader.ReadU2());

        private static MethodrefConstant CreateMethodrefConstant(IBigEndianReader reader) =>
            new(reader.ReadU2(), reader.ReadU2());

        private static InterfaceMethodrefConstant CreateInterfaceMethodrefConstant(IBigEndianReader reader) =>
            new(reader.ReadU2(), reader.ReadU2());

        private static StringConstant CreateStringConstant(IBigEndianReader reader) =>
            new(reader.ReadU2());

        private static IntegerConstant CreateIntegerConstant(IBigEndianReader reader) =>
            new(reader.ReadI4());

        private static FloatConstant CreateFloatConstant(IBigEndianReader reader) =>
            new(reader.ReadR4());

        private static LongConstant CreateLongConstant(IBigEndianReader reader) =>
            new(reader.ReadI8());

        private static DoubleConstant CreateDoubleConstant(IBigEndianReader reader) =>
            new(reader.ReadR8());

        private static NameAndTypeConstant CreateNameAndTypeConstant(IBigEndianReader reader) =>
            new(reader.ReadU2(), reader.ReadU2());

        private static Utf8Constant CreateUtf8Constant(IBigEndianReader reader)
        {
            ushort length = reader.ReadU2();
            byte[] array = Pool.Rent(length);
            reader.Read(array.AsSpan().Slice(0, length));
            string text = JavaUtf8.Instance.GetString(array, 0, length);
            Pool.Return(array, true);
            return new(text);
        }

        private static MethodHandleConstant CreateMethodHandleConstant(IBigEndianReader reader) =>
            new((MethodReferenceKind) reader.ReadU1(), reader.ReadU2());

        private static MethodTypeConstant CreateMethodTypeConstant(IBigEndianReader reader) =>
            new(reader.ReadU2());

        private static InvokeDynamicConstant CreateInvokeDynamicConstant(IBigEndianReader reader) =>
            new(reader.ReadU2(), reader.ReadU2());
    }
}