using System.Collections.Generic;

namespace Bali.Emit.Operands
{
    /// <summary>
    /// Represents the operand of the <see cref="JvmOpCodes.Lookupswitch"/> opcode.
    /// </summary>
    public class KeyJumpTable
    {
        /// <summary>
        /// Creates a new <see cref="KeyJumpTable"/>.
        /// </summary>
        /// <param name="default">The default offset to jump by.</param>
        /// <param name="matches">The key->offset pairs to jump by.</param>
        public KeyJumpTable(int @default, IDictionary<int, int> matches)
        {
            Default = @default;
            Matches = matches;
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
        /// Gets or sets the key->offset pairs to jump by.
        /// </summary>
        public IDictionary<int, int> Matches
        {
            get;
            set;
        }
    }
}