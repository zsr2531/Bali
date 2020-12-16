using System.IO;

namespace Bali.IO.Constants
{
    /// <summary>
    /// Represents a method of an interface in a <see cref="ClassFile"/>.
    /// </summary>
    public class InterfaceMethodrefConstant : Constant
    {
        /// <summary>
        /// Creates a new <see cref="InterfaceMethodrefConstant"/>.
        /// </summary>
        /// <param name="classIndex">The index into the <see cref="ConstantPool"/> to a <see cref="ClassConstant"/> (must be an interface) that this method is the member of.</param>
        /// <param name="nameAndTypeIndex">The index into the <see cref="ConstantPool"/> to a <see cref="NameAndTypeConstant"/> that indicates the name and the descriptor of this method.</param>
        public InterfaceMethodrefConstant(ushort classIndex, ushort nameAndTypeIndex)
            : base(ConstantKind.InterfaceMethodref)
        {
            ClassIndex = classIndex;
            NameAndTypeIndex = nameAndTypeIndex;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> to a <see cref="ClassConstant"/> (must be an interface) that this method is the member of.
        /// </summary>
        public ushort ClassIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> to a <see cref="NameAndTypeConstant"/> that indicates the name and the descriptor of this method.
        /// </summary>
        /// <value></value>
        public ushort NameAndTypeIndex
        {
            get;
            set;
        }
        
        /// <summary>
        /// Parses a <see cref="InterfaceMethodrefConstant"/> from the given input <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The input <see cref="Stream"/> to read data from.</param>
        /// <returns>The parsed <see cref="InterfaceMethodrefConstant"/>.</returns>
        public static InterfaceMethodrefConstant Create(Stream stream) =>
            new(stream.ReadU2(), stream.ReadU2());
    }
}