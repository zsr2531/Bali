using System.IO;

namespace Bali.IO.Constants
{
    /// <summary>
    /// A simple data structure used to represent a method handle.
    /// </summary>
    public class MethodHandleConstant : Constant
    {
        /// <summary>
        /// Creates a new <see cref="MethodHandleConstant"/>.
        /// </summary>
        /// <param name="referenceKind">The <see cref="MethodReferenceKind"/> which denotes the kind of this method handle, which characterizes its bytecode behavior.</param>
        /// <param name="referenceIndex">
        /// The index into the <see cref="ConstantPool"/> where the index represents:
        /// <list type="bullet">
        /// <item>
        ///     <term>
        ///         <see cref="MethodReferenceKind.GetField"/>, <see cref="MethodReferenceKind.GetStatic"/>,
        ///         <see cref="MethodReferenceKind.PutField"/> or <see cref="MethodReferenceKind.PutStatic"/>
        ///     </term>
        ///     <description>
        ///         -> <see cref="FieldrefConstant"/>.
        ///     </description>
        /// </item>
        /// <item>
        ///     <term>
        ///         <see cref="MethodReferenceKind.InvokeVirtual"/>, <see cref="MethodReferenceKind.InvokeStatic"/>,
        ///         <see cref="MethodReferenceKind.InvokeSpecial"/> or <see cref="MethodReferenceKind.NewInvokeSpecial"/>
        ///     </term>
        ///     <description>
        ///         -> <see cref="MethodrefConstant"/>.
        ///     </description>
        /// </item>
        /// <item>
        ///     <term>
        ///         <see cref="MethodReferenceKind.InvokeInterface"/>
        ///     </term>
        ///     <description>
        ///         -> <see cref="InterfaceMethodrefConstant"/>.
        ///     </description>
        /// </item>
        /// </list>
        /// </param>
        public MethodHandleConstant(MethodReferenceKind referenceKind, ushort referenceIndex)
            : base(ConstantKind.MethodHandle)
        {
            ReferenceKind = referenceKind;
            ReferenceIndex = referenceIndex;
        }

        /// <summary>
        /// Gets or sets the <see cref="MethodReferenceKind"/> which denotes the kind of this method handle, which characterizes its bytecode behavior.
        /// </summary>
        public MethodReferenceKind ReferenceKind
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> where the index represents:
        /// <list type="bullet">
        /// <item>
        ///     <term>
        ///         <see cref="MethodReferenceKind.GetField"/>, <see cref="MethodReferenceKind.GetStatic"/>,
        ///         <see cref="MethodReferenceKind.PutField"/> or <see cref="MethodReferenceKind.PutStatic"/>
        ///     </term>
        ///     <description>
        ///         -> <see cref="FieldrefConstant"/>.
        ///     </description>
        /// </item>
        /// <item>
        ///     <term>
        ///         <see cref="MethodReferenceKind.InvokeVirtual"/>, <see cref="MethodReferenceKind.InvokeStatic"/>,
        ///         <see cref="MethodReferenceKind.InvokeSpecial"/> or <see cref="MethodReferenceKind.NewInvokeSpecial"/>
        ///     </term>
        ///     <description>
        ///         -> <see cref="MethodrefConstant"/>.
        ///     </description>
        /// </item>
        /// <item>
        ///     <term>
        ///         <see cref="MethodReferenceKind.InvokeInterface"/>
        ///     </term>
        ///     <description>
        ///         -> <see cref="InterfaceMethodrefConstant"/>.
        ///     </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <remarks>
        /// If the reference kind is <see cref="MethodReferenceKind.InvokeVirtual"/>,
        /// <see cref="MethodReferenceKind.InvokeStatic"/>, <see cref="MethodReferenceKind.InvokeSpecial"/> or
        /// <see cref="MethodReferenceKind.InvokeInterface"/> the method name must not be <c>&lt;init></c> or
        /// <c>&lt;clinit></c>.
        /// However, if the <see cref="ReferenceKind"/> is <see cref="MethodReferenceKind.NewInvokeSpecial"/>
        /// the method name must be <c>&lt;init></c>
        /// </remarks>
        public ushort ReferenceIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Parses a <see cref="MethodHandleConstant"/> from the given input <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The input <see cref="Stream"/> to read data from.</param>
        /// <returns>The parsed <see cref="MethodHandleConstant"/>.</returns>
        public static MethodHandleConstant Create(Stream stream) =>
            new((MethodReferenceKind) stream.ReadU1(), stream.ReadU2());
    }
}