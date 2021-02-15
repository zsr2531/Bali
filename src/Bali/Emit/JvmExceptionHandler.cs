using System;

// GetHashCode not overridden
#pragma warning disable 659

namespace Bali.Emit
{
    /// <summary>
    /// Represents a JVM exception handler.
    /// </summary>
    public sealed class JvmExceptionHandler : IEquatable<JvmExceptionHandler>
    {
        /// <summary>
        /// Creates a new <see cref="JvmExceptionHandler"/>.
        /// </summary>
        /// <param name="tryStart">The inclusive index of the first instruction to protect.</param>
        /// <param name="tryEnd">The exclusive index of the last instruction to protect.</param>
        /// <param name="handlerStart">The inclusive index of the first instruction of the handler.</param>
        /// <param name="catchType">
        /// The index into the <see cref="ConstantPool" /> describing the type of the exception to catch
        /// or 0 if the exception handler is a <c>finally</c> block.
        /// </param>
        public JvmExceptionHandler(ushort tryStart, ushort tryEnd, ushort handlerStart, ushort catchType)
        {
            TryStart = tryStart;
            TryEnd = tryEnd;
            HandlerStart = handlerStart;
            CatchType = catchType;
        }

        /// <summary>
        /// Gets a logical value whether this <see cref="JvmExceptionHandler"/> is a
        /// <c>finally</c> exception handler or not.
        /// </summary>
        public bool IsFinally => CatchType == 0;
        
        /// <summary>
        /// Gets the index of the first instruction to protect.
        /// </summary>
        public ushort TryStart
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the index of the last instruction to protect.
        /// </summary>
        /// <remarks>Note that this is an exclusive index.</remarks>
        public ushort TryEnd
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the index of the handler block's first instruction.
        /// </summary>
        public ushort HandlerStart
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the index into the <see cref="ConstantPool" /> describing the type of the exception to catch
        /// or 0 if the exception handler is a <c>finally</c> block.
        /// </summary>
        public ushort CatchType
        {
            get;
            set;
        }

        /// <inheritdoc />
        public bool Equals(JvmExceptionHandler other) =>
            TryStart == other.TryStart
            && TryEnd == other.TryEnd
            && HandlerStart == other.HandlerStart
            && CatchType == other.CatchType;

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is JvmExceptionHandler other && Equals(other);

        /// <inheritdoc />
        public override string ToString() =>
            $"[0x{TryStart:X4},0x{TryEnd:X4}) HandlerStart: 0x{HandlerStart:X4} CatchType: {CatchType}";
    }
}