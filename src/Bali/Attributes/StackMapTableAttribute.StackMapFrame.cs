using System;
using System.Collections.Generic;

namespace Bali.Attributes
{
    public abstract class StackMapFrame
    {
        private protected StackMapFrame(byte tag)
        {
            Tag = tag;
        }
        
        public byte Tag
        {
            get;
        }
        
        public abstract ushort OffsetDelta
        {
            get;
        }
    }
    
    public sealed class SameFrame : StackMapFrame
    {
        public SameFrame(byte tag)
            : base(tag)
        {
            if (tag > 63)
                throw new ArgumentOutOfRangeException(nameof(tag));
        }

        /// <inheritdoc />
        public override ushort OffsetDelta => Tag;
    }
    
    public sealed class SameLocals1StackItemFrame : StackMapFrame
    {
        public SameLocals1StackItemFrame(byte tag, VerificationInfo stackTop)
            : base(tag)
        {
            if (tag < 64 || tag > 127)
                throw new ArgumentOutOfRangeException(nameof(tag));
            
            StackTop = stackTop;
        }

        /// <inheritdoc />
        public override ushort OffsetDelta => (ushort) (Tag - 64);
        
        public VerificationInfo StackTop
        {
            get;
        }
    }
    
    public sealed class SameLocals1StackItemFrameExtended : StackMapFrame
    {
        internal SameLocals1StackItemFrameExtended(byte tag, ushort offsetDelta, VerificationInfo stackTop)
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
        
        public VerificationInfo StackTop
        {
            get;
        }
    }
    
    public sealed class ChopFrame : StackMapFrame
    {
        public ChopFrame(byte tag, ushort offsetDelta)
            : base(tag)
        {
            if (tag < 248 || tag > 250)
                throw new ArgumentOutOfRangeException(nameof(tag));
            
            OffsetDelta = offsetDelta;
        }

        public int LastLocalsToDrop => 251 - Tag;

        /// <inheritdoc />
        public override ushort OffsetDelta
        {
            get;
        }
    }
    
    public sealed class SameFrameExtended : StackMapFrame
    {
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
    
    public sealed class AppendFrame : StackMapFrame
    {
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
        
        public IList<VerificationInfo> NewLocals
        {
            get;
        }
    }
    
    public sealed class FullFrame : StackMapFrame
    {
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
        
        public IList<VerificationInfo> Locals
        {
            get;
        }
        
        public IList<VerificationInfo> Stack
        {
            get;
        }
    }
}