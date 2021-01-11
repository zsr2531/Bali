using System;
using System.IO;
using Bali.IO;

namespace Bali.Constants
{
    /// <summary>
    /// Provides methods to deserialize <see cref="Constant"/>s from the given input <see cref="Stream"/>.
    /// </summary>
    public static class ConstantFactory
    {
        /// <summary>
        /// Reads the next <see cref="Constant"/> from the given input <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The input <see cref="Stream"/> to read data from.</param>
        /// <returns>The deserialized <see cref="Constant"/>.</returns>
        public static Constant CreateConstant(Stream stream)
        {
            byte tag = stream.ReadU1();

            return (ConstantKind) tag switch
            {
                ConstantKind.Class => CreateClassConstant(stream),
                ConstantKind.Fieldref => CreateFieldrefConstant(stream),
                ConstantKind.Methodref => CreateMethodrefConstant(stream),
                ConstantKind.InterfaceMethodref => CreateInterfaceMethodrefConstant(stream),
                ConstantKind.String => CreateStringConstant(stream),
                ConstantKind.Integer => CreateIntegerConstant(stream),
                ConstantKind.Float => CreateFloatConstant(stream),
                ConstantKind.Long => CreateLongConstant(stream),
                ConstantKind.Double => CreateDoubleConstant(stream),
                ConstantKind.NameAndType => CreateNameAndTypeConstant(stream),
                ConstantKind.Utf8 => CreateUtf8Constant(stream),
                ConstantKind.MethodHandle => CreateMethodHandleConstant(stream),
                ConstantKind.MethodType => CreateMethodTypeConstant(stream),
                ConstantKind.InvokeDynamic => CreateInvokeDynamicConstant(stream),
                _ => throw new NotSupportedException($"Not supported constant tag: 0x{tag}.")
            };
        }

        private static ClassConstant CreateClassConstant(Stream stream) =>
            new(stream.ReadU2());

        private static FieldrefConstant CreateFieldrefConstant(Stream stream) =>
            new(stream.ReadU2(), stream.ReadU2());

        private static MethodrefConstant CreateMethodrefConstant(Stream stream) =>
            new(stream.ReadU2(), stream.ReadU2());

        private static InterfaceMethodrefConstant CreateInterfaceMethodrefConstant(Stream stream) =>
            new(stream.ReadU2(), stream.ReadU2());

        private static StringConstant CreateStringConstant(Stream stream) =>
            new(stream.ReadU2());

        private static IntegerConstant CreateIntegerConstant(Stream stream) =>
            new(stream.ReadI4());

        private static FloatConstant CreateFloatConstant(Stream stream) =>
            new(stream.ReadR4());

        private static LongConstant CreateLongConstant(Stream stream) =>
            new(stream.ReadI8());

        private static DoubleConstant CreateDoubleConstant(Stream stream) =>
            new(stream.ReadR8());

        private static NameAndTypeConstant CreateNameAndTypeConstant(Stream stream) =>
            new(stream.ReadU2(), stream.ReadU2());

        private static Utf8Constant CreateUtf8Constant(Stream stream) =>
            new(JavaUtf8.Decode(stream, stream.ReadU2()));

        private static MethodHandleConstant CreateMethodHandleConstant(Stream stream) =>
            new((MethodReferenceKind) stream.ReadU1(), stream.ReadU2());

        private static MethodTypeConstant CreateMethodTypeConstant(Stream stream) =>
            new(stream.ReadU2());

        private static InvokeDynamicConstant CreateInvokeDynamicConstant(Stream stream) =>
            new(stream.ReadU2(), stream.ReadU2());
    }
}