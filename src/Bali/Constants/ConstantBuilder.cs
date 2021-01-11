using System;
using System.IO;
using Bali.IO;

namespace Bali.Constants
{
    /// <summary>
    /// Provides methods to deserialize <see cref="Constant"/>s from the given input <see cref="Stream"/>.
    /// </summary>
    public static class ConstantBuilder
    {
        /// <summary>
        /// Reads the next <see cref="Constant"/> from the given input <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The input <see cref="Stream"/> to read data from.</param>
        /// <returns>The deserialized <see cref="Constant"/>.</returns>
        public static Constant BuildConstant(Stream stream)
        {
            byte tag = stream.ReadU1();

            return (ConstantKind) tag switch
            {
                ConstantKind.Class => BuildClassConstant(stream),
                ConstantKind.Fieldref => BuildFieldrefConstant(stream),
                ConstantKind.Methodref => BuildMethodrefConstant(stream),
                ConstantKind.InterfaceMethodref => BuildInterfaceMethodrefConstant(stream),
                ConstantKind.String => BuildStringConstant(stream),
                ConstantKind.Integer => BuildIntegerConstant(stream),
                ConstantKind.Float => BuildFloatConstant(stream),
                ConstantKind.Long => BuildLongConstant(stream),
                ConstantKind.Double => BuildDoubleConstant(stream),
                ConstantKind.NameAndType => BuildNameAndTypeConstant(stream),
                ConstantKind.Utf8 => BuildUtf8Constant(stream),
                ConstantKind.MethodHandle => BuildMethodHandleConstant(stream),
                ConstantKind.MethodType => BuildMethodTypeConstant(stream),
                ConstantKind.InvokeDynamic => BuildInvokeDynamicConstant(stream),
                _ => throw new NotSupportedException($"Not supported constant tag: 0x{tag}.")
            };
        }

        private static ClassConstant BuildClassConstant(Stream stream) =>
            new(stream.ReadU2());

        private static FieldrefConstant BuildFieldrefConstant(Stream stream) =>
            new(stream.ReadU2(), stream.ReadU2());

        private static MethodrefConstant BuildMethodrefConstant(Stream stream) =>
            new(stream.ReadU2(), stream.ReadU2());

        private static InterfaceMethodrefConstant BuildInterfaceMethodrefConstant(Stream stream) =>
            new(stream.ReadU2(), stream.ReadU2());

        private static StringConstant BuildStringConstant(Stream stream) =>
            new(stream.ReadU2());

        private static IntegerConstant BuildIntegerConstant(Stream stream) =>
            new(stream.ReadI4());

        private static FloatConstant BuildFloatConstant(Stream stream) =>
            new(stream.ReadR4());

        private static LongConstant BuildLongConstant(Stream stream) =>
            new(stream.ReadI8());

        private static DoubleConstant BuildDoubleConstant(Stream stream) =>
            new(stream.ReadR8());

        private static NameAndTypeConstant BuildNameAndTypeConstant(Stream stream) =>
            new(stream.ReadU2(), stream.ReadU2());

        private static Utf8Constant BuildUtf8Constant(Stream stream) =>
            new(JavaUtf8.Decode(stream, stream.ReadU2()));

        private static MethodHandleConstant BuildMethodHandleConstant(Stream stream) =>
            new((MethodReferenceKind) stream.ReadU1(), stream.ReadU2());

        private static MethodTypeConstant BuildMethodTypeConstant(Stream stream) =>
            new(stream.ReadU2());

        private static InvokeDynamicConstant BuildInvokeDynamicConstant(Stream stream) =>
            new(stream.ReadU2(), stream.ReadU2());
    }
}