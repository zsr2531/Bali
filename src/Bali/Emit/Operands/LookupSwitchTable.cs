using System.Collections.Generic;

namespace Bali.Emit.Operands
{
    public class LookupSwitchTable
    {
        public LookupSwitchTable(int @default, IDictionary<int, int> matches)
        {
            Default = @default;
            Matches = matches;
        }

        public int Default
        {
            get;
            set;
        }

        public IDictionary<int, int> Matches
        {
            get;
            set;
        }
    }
}