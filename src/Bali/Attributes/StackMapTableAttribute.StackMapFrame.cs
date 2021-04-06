using System;
using System.Collections.Generic;

namespace Bali.Attributes
{
    public abstract class StackMapFrameBase
    {
        private protected StackMapFrameBase(byte tag)
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
    
    public sealed class SameFrame : StackMapFrameBase
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
    
    public sealed class SameLocals1StackItemFrame : StackMapFrameBase
    {
        public SameLocals1StackItemFrame(byte tag, VerificationInfoBase stackTop)
            : base(tag)
        {
            if (tag < 64 || tag > 127)
                throw new ArgumentOutOfRangeException(nameof(tag));
            
            StackTop = stackTop;
        }

        /// <inheritdoc />
        public override ushort OffsetDelta => (ushort) (Tag - 64);
        
        public VerificationInfoBase StackTop
        {
            get;
        }
    }
    
    public sealed class SameLocals1StackItemFrameExtended : StackMapFrameBase
    {
        internal SameLocals1StackItemFrameExtended(byte tag, ushort offsetDelta, VerificationInfoBase stackTop)
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
        
        public VerificationInfoBase StackTop
        {
            get;
        }
    }
    
    public sealed class ChopFrame : StackMapFrameBase
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
    
    public sealed class SameFrameExtended : StackMapFrameBase
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
    
    public sealed class AppendFrame : StackMapFrameBase
    {
        public AppendFrame(byte tag, ushort offsetDelta, IList<VerificationInfoBase> newLocals)
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
        
        public IList<VerificationInfoBase> NewLocals
        {
            get;
        }
    }
    
    public sealed class FullFrame : StackMapFrameBase
    {
        public FullFrame(
            byte tag,
            ushort offsetDelta,
            IList<VerificationInfoBase> locals,
            IList<VerificationInfoBase> stack)
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
        
        public IList<VerificationInfoBase> Locals
        {
            get;
        }
        
        public IList<VerificationInfoBase> Stack
        {
            get;
        }
    }
}