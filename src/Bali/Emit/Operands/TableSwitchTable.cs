using System.Collections.Generic;

namespace Bali.Emit.Operands
{
    public class TableSwitchTable
    {
        public TableSwitchTable(int @default, int low, int high, IList<int> offsets)
        {
            Default = @default;
            Low = low;
            High = high;
            Offsets = offsets;
        }

        public int Default
        {
            get;
            set;
        }

        public int Low
        {
            get;
            set;
        }

        public int High
        {
            get;
            set;
        }

        public IList<int> Offsets
        {
            get;
            set;
        }
    }
}