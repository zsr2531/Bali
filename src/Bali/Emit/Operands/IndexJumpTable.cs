using System.Collections.Generic;

namespace Bali.Emit.Operands
{
    /// <summary>
    /// Represents the operand of the <see cref="JvmOpCodes.Tableswitch"/> opcode.
    /// </summary>
    public class IndexJumpTable
    {
        /// <summary>
        /// Creates a new <see cref="IndexJumpTable"/>.
        /// </summary>
        /// <param name="default">The default offset to jump by.</param>
        /// <param name="low">The lowest index available.</param>
        /// <param name="high">The highest index available.</param>
        /// <param name="offsets">The offsets to jump by based on the index.</param>
        public IndexJumpTable(int @default, int low, int high, IList<int> offsets)
        {
            Default = @default;
            Low = low;
            High = high;
            Offsets = offsets;
        }

        /// <summary>
        /// Gets or sets the default offset to jump by.
        /// </summary>
        public int Default
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the lowest index available.
        /// </summary>
        public int Low
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the highest index available.
        /// </summary>
        public int High
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the offsets to jump by based on the index.
        /// </summary>
        public IList<int> Offsets
        {
            get;
            set;
        }
    }
}