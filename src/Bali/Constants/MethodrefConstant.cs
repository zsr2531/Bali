using System.IO;
using Bali.IO;

namespace Bali.Constants
{
    /// <summary>
    /// Represents a method in the <see cref="ClassFile"/>.
    /// </summary>
    public class MethodrefConstant : Constant
    {
        /// <summary>
        /// Creates a new <see cref="MethodrefConstant"/>.
        /// </summary>
        /// <param name="classIndex"></param>
        /// <param name="nameAndTypeIndex"></param>
        public MethodrefConstant(ushort classIndex, ushort nameAndTypeIndex)
            : base(ConstantKind.Methodref)
        {
            ClassIndex = classIndex;
            NameAndTypeIndex = nameAndTypeIndex;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> to a <see cref="ClassConstant"/> that this method is a member of.
        /// </summary>
        public ushort ClassIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> to a <see cref="NameAndTypeConstant"/> that indicates the name and the descriptor of this method.
        /// </summary>
        public ushort NameAndTypeIndex
        {
            get;
            set;
        }
        
        /// <summary>
        /// Parses a <see cref="MethodrefConstant"/> from the given input <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The input <see cref="Stream"/> to read data from.</param>
        /// <returns>The parsed <see cref="MethodrefConstant"/>.</returns>
        public static MethodrefConstant Create(Stream stream) => new(stream.ReadU2(), stream.ReadU2());
    }
}
