using System;
using System.Collections.Generic;
using System.IO;
using Bali.IO;

namespace Bali.Metadata.Attributes
{
    public sealed class ExceptionsAttribute : JvmAttribute
    {
        public ExceptionsAttribute(ushort nameIndex, IList<ushort> exceptions) : base(nameIndex) =>
            Exceptions = exceptions;
        
        public IList<ushort> Exceptions
        {
            get;
            set;
        }

        /// <inheritdoc />
        public override byte[] GetData()
        {
            var buffer = new byte[Exceptions.Count * 2];

            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte)((Exceptions[i] >> 8) & 0xFF);
                buffer[++i] = (byte)(Exceptions[i] & 0xFF);
            }

            return buffer;
        }

        public static ExceptionsAttribute Create(Stream stream, ushort nameIndex)
        {
            ushort count = stream.ReadU2();
            var buffer = count == 0
                ? Array.Empty<ushort>()
                : new ushort[count];

            for (int i = 0; i < count; i++)
                buffer[i] = stream.ReadU2();
            
            return new ExceptionsAttribute(nameIndex, buffer);
        }
    }
}