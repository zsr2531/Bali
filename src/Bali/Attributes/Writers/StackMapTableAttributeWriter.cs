using System.Diagnostics;
using Bali.IO;

namespace Bali.Attributes.Writers
{
    /// <summary>
    /// Provides an implementation of the <see cref="JvmAttributeWriterBase{T}"/> contract which can write <see cref="StackMapTableAttribute"/>s.
    /// </summary>
    public class StackMapTableAttributeWriter : JvmAttributeWriterBase<StackMapTableAttribute>
    {
        /// <summary>
        /// Creates a new <see cref="StackMapTableAttributeWriter"/>.
        /// </summary>
        /// <param name="director">The underlying <see cref="IJvmAttributeDirector"/>.</param>
        public StackMapTableAttributeWriter(IJvmAttributeDirector director)
            : base(director)
        {
        }

        /// <inheritdoc />
        public override string Name => "StackMapTable";

        /// <inheritdoc />
        protected override void WriteBody(StackMapTableAttribute attribute, IBigEndianWriter writer)
        {
            var stackMapFrameWriter = new StackMapFrameWriter(writer);
            
            foreach (var frame in attribute.Entries)
                stackMapFrameWriter.WriteFrame(frame);
        }

        private readonly ref struct StackMapFrameWriter
        {
            private readonly IBigEndianWriter _writer;
            private readonly VerificationInfoWriter _verificationInfoWriter;

            internal StackMapFrameWriter(IBigEndianWriter writer)
            {
                _writer = writer;
                _verificationInfoWriter = new(writer);
            }

            internal void WriteFrame(StackMapFrame frame)
            {
                _writer.WriteU1(frame.Tag);
                
                switch (frame)
                {
                    case SameLocals1StackItemFrame sameLocals1StackItemFrame:
                        WriteFrame(sameLocals1StackItemFrame);
                        break;
                    case SameLocals1StackItemFrameExtended sameLocals1StackItemFrameExtended:
                        WriteFrame(sameLocals1StackItemFrameExtended);
                        break;
                    case ChopFrame chopFrame:
                        WriteFrame(chopFrame);
                        break;
                    case SameFrameExtended sameFrameExtended:
                        WriteFrame(sameFrameExtended);
                        break;
                    case AppendFrame appendFrame:
                        WriteFrame(appendFrame);
                        break;
                }
            }

            internal void WriteFrame(SameLocals1StackItemFrame frame)
            {
                _verificationInfoWriter.WriteVerificationInfo(frame.StackTop);
            }
            
            internal void WriteFrame(SameLocals1StackItemFrameExtended frame)
            {
                _writer.WriteU2(frame.OffsetDelta);
                _verificationInfoWriter.WriteVerificationInfo(frame.StackTop);
            }

            internal void WriteFrame(ChopFrame frame)
            {
                _writer.WriteU2(frame.OffsetDelta);
            }

            internal void WriteFrame(SameFrameExtended frame)
            {
                _writer.WriteU2(frame.OffsetDelta);
            }

            internal void WriteFrame(AppendFrame frame)
            {
                // The tag provides the length of the list.
                Debug.Assert(frame.Tag - 251 == frame.NewLocals.Count);
                
                _writer.WriteU2(frame.OffsetDelta);
                
                foreach (var info in frame.NewLocals)
                    _verificationInfoWriter.WriteVerificationInfo(info);
            }

            internal void WriteFrame(FullFrame frame)
            {
                _writer.WriteU2(frame.OffsetDelta);
                
                _writer.WriteU2((ushort) frame.Locals.Count);
                foreach (var info in frame.Locals)
                    _verificationInfoWriter.WriteVerificationInfo(info);
                
                _writer.WriteU2((ushort) frame.Stack.Count);
                foreach (var info in frame.Stack)
                    _verificationInfoWriter.WriteVerificationInfo(info);
            }
        }

        private readonly ref struct VerificationInfoWriter
        {
            private readonly IBigEndianWriter _writer;

            internal VerificationInfoWriter(IBigEndianWriter writer)
            {
                _writer = writer;
            }

            internal void WriteVerificationInfo(VerificationInfo info)
            {
                _writer.WriteU1((byte) info.Tag);
                
                switch (info)
                {
                    case ObjectVariableInfo objectVariableInfo:
                        WriteVerificationInfo(objectVariableInfo);
                        break;
                    case UninitializedVariableInfo uninitializedVariableInfo:
                        WriteVerificationInfo(uninitializedVariableInfo);
                        break;
                }
            }

            internal void WriteVerificationInfo(ObjectVariableInfo info)
            {
                _writer.WriteU2(info.ConstantPoolIndex);
            }

            internal void WriteVerificationInfo(UninitializedVariableInfo info)
            {
                _writer.WriteU2(info.Offset);
            }
        }
    }
}