namespace Bali.Emit
{
    public sealed class ExceptionHandler
    {
        public ushort TryStart
        {
            get;
            set;
        }

        public ushort TryEnd
        {
            get;
            set;
        }

        public ushort HandlerStart
        {
            get;
            set;
        }

        public ushort CatchType
        {
            get;
            set;
        }
    }
}