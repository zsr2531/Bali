using System;
using System.Collections.Generic;

namespace Bali.Attributes
{
    /// <summary>
    /// Provides a contract for stack map frames.
    /// </summary>
    public abstract class StackMapFrame
    {
        private protected StackMapFrame(byte tag)
        {
            Tag = tag;
        }
        
        /// <summary>
        /// Gets the tag.
        /// </summary>
        public byte Tag
        {
            get;
        }
        
        /// <summary>
        /// Gets the offset to the next frame in the bytecode.
        /// </summary>
        public abstract ushort OffsetDelta
        {
            get;
        }
    }
    
    /// <summary>
    /// Indicates that the frame is the same as the previous one.
    /// </summary>
    public sealed class SameFrame : StackMapFrame
    {
        /// <summary>
        /// Creates a new <see cref="SameFrame"/>.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="tag"/> is greater than 63.</exception>
        public SameFrame(byte tag)
            : base(tag)
        {
            if (tag > 63)
                throw new ArgumentOutOfRangeException(nameof(tag));
        }

        /// <inheritdoc />
        public override ushort OffsetDelta => Tag;
    }
    
    /// <summary>
    /// Indicates that the frame is the same as the previous one, except the top stack item.
    /// </summary>
    public sealed class SameLocals1StackItemFrame : StackMapFrame
    {
        /// <summary>
        /// Creates a new <see cref="SameLocals1StackItemFrame"/>.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="stackTop">The type of the top item on the stack.</param>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="tag"/> is less than 64 or greater than 127.</exception>
        public SameLocals1StackItemFrame(byte tag, VerificationInfo stackTop)
            : base(tag)
        {
            if (tag < 64 || tag > 127)
                throw new ArgumentOutOfRangeException(nameof(tag));
            
            StackTop = stackTop;
        }

        /// <inheritdoc />
        public override ushort OffsetDelta => (ushort) (Tag - 64);
        
        /// <summary>
        /// Gets the type of the top item on the stack.
        /// </summary>
        public VerificationInfo StackTop
        {
            get;
        }
    }
    
    /// <summary>
    /// Indicates that the frame is the same as the previous one, except the top stack item but it has an explicit
    /// offset for a bigger "range".
    /// </summary>
    public sealed class SameLocals1StackItemFrameExtended : StackMapFrame
    {
        /// <summary>
        /// Creates a new <see cref="SameLocals1StackItemFrameExtended"/>.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="offsetDelta">The offset to the next frame in the bytecode.</param>
        /// <param name="stackTop">The type of the top item on the stack.</param>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="tag"/> is not 247.</exception>
        public SameLocals1StackItemFrameExtended(byte tag, ushort offsetDelta, VerificationInfo stackTop)
            : base(tag)
        {
            if (tag != 247)
                throw new ArgumentOutOfRangeException(nameof(tag));
            
            OffsetDelta = offsetDelta;
            StackTop = stackTop;
        }

        /// <inheritdoc />
        public override ushort OffsetDelta
        {
            get;
        }
        
        /// <summary>
        /// Gets the type of the top item on the stack.
        /// </summary>
        public VerificationInfo StackTop
        {
            get;
        }
    }
    
    /// <summary>
    /// Indicates that the frame is the same as the previous one with the last <i>k</i> locals dropped.
    /// </summary>
    public sealed class ChopFrame : StackMapFrame
    {
        /// <summary>
        /// Creates a new <see cref="ChopFrame"/>.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="offsetDelta">The offset to the next frame in the bytecode.</param>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="tag"/> is less than 248 or greater than 250.</exception>
        public ChopFrame(byte tag, ushort offsetDelta)
            : base(tag)
        {
            if (tag < 248 || tag > 250)
                throw new ArgumentOutOfRangeException(nameof(tag));
            
            OffsetDelta = offsetDelta;
        }

        /// <summary>
        /// Gets the number of locals to drop from the previous frame, starting from the end.
        /// </summary>
        public int LastLocalsToDrop => 251 - Tag;

        /// <inheritdoc />
        public override ushort OffsetDelta
        {
            get;
        }
    }
    
    /// <summary>
    /// Indicates that the frame is the same as the previous one, but it has an explicit offset for a bigger "range".
    /// </summary>
    public sealed class SameFrameExtended : StackMapFrame
    {
        /// <summary>
        /// Creates a new <see cref="ChopFrame"/>.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="offsetDelta">The offset to the next frame in the bytecode.</param>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="tag"/> is not 251.</exception>
        public SameFrameExtended(byte tag, ushort offsetDelta)
            : base(tag)
        {
            if (tag != 251)
                throw new ArgumentOutOfRangeException(nameof(tag));
            
            OffsetDelta = offsetDelta;
        }

        /// <inheritdoc />
        public override ushort OffsetDelta
        {
            get;
        }
    }
    
    /// <summary>
    /// Indicates that the frame is the same as the previous one, except new locals are added to the stack frame.
    /// </summary>
    public sealed class AppendFrame : StackMapFrame
    {
        /// <summary>
        /// Creates a new <see cref="AppendFrame"/>.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="offsetDelta">The offset to the next frame in the bytecode.</param>
        /// <param name="newLocals">The new locals to append to the previous frame.</param>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="tag"/> is less than 252 or greater than 254.</exception>
        public AppendFrame(byte tag, ushort offsetDelta, IList<VerificationInfo> newLocals)
            : base(tag)
        {
            if (tag < 252 || tag > 254)
                throw new ArgumentOutOfRangeException(nameof(tag));
            
            OffsetDelta = offsetDelta;
            NewLocals = newLocals;
        }

        /// <inheritdoc />
        public override ushort OffsetDelta
        {
            get;
        }
        
        /// <summary>
        /// Gets the new locals to append to the previous frame.
        /// </summary>
        public IList<VerificationInfo> NewLocals
        {
            get;
        }
    }
    
    /// <summary>
    /// Indicates that the stack frame is completely redefined compared to the previous one.
    /// </summary>
    public sealed class FullFrame : StackMapFrame
    {
        /// <summary>
        /// Creates a new <see cref="FullFrame"/>.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="offsetDelta">The offset to the next frame in the bytecode.</param>
        /// <param name="locals">The locals in the stack frame.</param>
        /// <param name="stack">The stack items of the stack frame.</param>
        /// <exception cref="ArgumentOutOfRangeException">When <paramref name="tag"/> is less than 252 or greater than 254.</exception>
        public FullFrame(
            byte tag,
            ushort offsetDelta,
            IList<VerificationInfo> locals,
            IList<VerificationInfo> stack)
            : base(tag)
        {
            if (tag != 255)
                throw new ArgumentOutOfRangeException(nameof(tag));
            
            OffsetDelta = offsetDelta;
            Locals = locals;
            Stack = stack;
        }

        /// <inheritdoc />
        public override ushort OffsetDelta
        {
            get;
        }
        
        /// <summary>
        /// Gets the locals in the stack frame.
        /// </summary>
        public IList<VerificationInfo> Locals
        {
            get;
        }
        
        /// <summary>
        /// Gets the stack items of the stack frame.
        /// </summary>
        public IList<VerificationInfo> Stack
        {
            get;
        }
    }
}