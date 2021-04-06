using System;
using System.Collections.Generic;
using Bali.IO;

namespace Bali.Attributes.Readers
{
    /// <summary>
    /// Provides an implementation of the <see cref="JvmAttributeReaderBase"/> contract that can read <see cref="StackMapTableAttribute"/>s.
    /// </summary>
    public class StackMapTableAttributeReader : JvmAttributeReaderBase
    {
        /// <summary>
        /// Creates a new <see cref="StackMapTableAttributeReader"/>.
        /// </summary>
        /// <param name="attributeReaderFacade">The attribute factory that can be used to create other types of attributes.</param>
        public StackMapTableAttributeReader(IJvmAttributeReaderFacade attributeReaderFacade)
            : base(attributeReaderFacade)
        {
        }

        /// <inheritdoc />
        public override string Name => "StackMapTable";

        /// <inheritdoc />
        public override JvmAttribute Read(IBigEndianReader reader, ushort nameIndex, uint length)
        {
            ushort items = reader.ReadU2();
            var frames = new List<StackMapFrameBase>(items);

            for (int i = 0; i < items; i++)
            {
                byte tag = reader.ReadU1();
                frames.Add(tag switch
                {
                    >= 0 and <= 63 => new SameFrame(tag),
                    >= 64 and <= 127 => new SameLocals1StackItemFrame(tag, ReadVerificationInfo(reader)),
                    247 => new SameLocals1StackItemFrameExtended(tag, reader.ReadU2(), ReadVerificationInfo(reader)),
                    >= 248 and <= 250 => new ChopFrame(tag, reader.ReadU2()),
                    251 => new SameFrameExtended(tag, reader.ReadU2()),
                    >= 252 and <= 254 => ReadAppendFrame(reader, tag),
                    255 => ReadFullFrame(reader, tag),
                    _ => null! // Unreachable, but the compiler would complain otherwise...
                });
            }

            return new StackMapTableAttribute(nameIndex, frames);
        }

        private static AppendFrame ReadAppendFrame(IBigEndianReader reader, byte tag)
        {
            ushort offsetDelta = reader.ReadU2();
            int items = tag - 251;
            var locals = new List<VerificationInfoBase>(items);
            for (int i = 0; i < items; i++)
                locals.Add(ReadVerificationInfo(reader));

            return new AppendFrame(tag, offsetDelta, locals);
        }

        private static FullFrame ReadFullFrame(IBigEndianReader reader, byte tag)
        {
            ushort offsetDelta = reader.ReadU2();
            
            ushort numOfLocals = reader.ReadU2();
            var locals = new List<VerificationInfoBase>(numOfLocals);
            
            for (int i = 0; i < numOfLocals; i++)
                locals.Add(ReadVerificationInfo(reader));
            
            ushort numOfStackItems = reader.ReadU2();
            var stack = new List<VerificationInfoBase>(numOfStackItems);
            
            for (int i = 0; i < numOfStackItems; i++)
                stack.Add(ReadVerificationInfo(reader));

            return new FullFrame(tag, offsetDelta, locals, stack);
        }

        private static VerificationInfoBase ReadVerificationInfo(IBigEndianReader reader)
        {
            var tag = (VerificationInfoTag) reader.ReadU1();
            return tag switch
            {
                VerificationInfoTag.Top => new TopVariableInfo(),
                VerificationInfoTag.Integer => new IntegerVariableInfo(),
                VerificationInfoTag.Float => new FloatVariableInfo(),
                VerificationInfoTag.Long => new LongVariableInfo(),
                VerificationInfoTag.Double => new DoubleVariableInfo(),
                VerificationInfoTag.Null => new NullVariableInfo(),
                VerificationInfoTag.UninitializedThis => new UninitializedThisVariableInfo(),
                VerificationInfoTag.Object => new ObjectVariableInfo(reader.ReadU2()),
                VerificationInfoTag.Uninitialized => new UninitializedVariableInfo(reader.ReadU2()),
                _ => throw new ArgumentOutOfRangeException(nameof(tag))
            };
        }
    }
}