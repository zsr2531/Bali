using System;

namespace Bali.Emit
{
    public class DisassemblyException : Exception
    {
        public DisassemblyException(string message)
            : base(message) { }
    }
}