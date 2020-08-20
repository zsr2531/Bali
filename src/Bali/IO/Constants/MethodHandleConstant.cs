using System.IO;

namespace Bali.IO.Constants
{
    public class MethodHandleConstant : Constant
    {
        public MethodHandleConstant(MethodReferenceKind referenceKind, ushort referenceIndex)
            : base(ConstantKind.MethodHandle)
        {
            ReferenceKind = referenceKind;
            ReferenceIndex = referenceIndex;
        }

        public MethodReferenceKind ReferenceKind
        {
            get;
        }

        public ushort ReferenceIndex
        {
            get;
        }

        public static MethodHandleConstant Create(Stream stream) =>
            new MethodHandleConstant((MethodReferenceKind) stream.ReadU1(), stream.ReadU2());
    }
}