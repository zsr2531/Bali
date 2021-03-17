using System.Collections.Generic;
using System.IO;
using Bali.Attributes;
using Bali.Constants;
using Bali.IO;

namespace Bali
{
    /// <summary>
    /// Represents a single <c>class</c> or <c>interface</c>.
    /// </summary>
    public class ClassFile
    {
        /// <summary>
        /// Gets or sets the magic value.
        /// </summary>
        /// <remarks>This should always have the value <b>0xCAFEBABE</b>.</remarks>
        public uint Magic
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the minor version of this <see cref="ClassFile"/>.
        /// </summary>
        public ushort MinorVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the major version of this <see cref="ClassFile"/>.
        /// </summary>
        public ushort MajorVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the <see cref="ConstantPool"/>.
        /// </summary>
        public ConstantPool Constants
        {
            get;
            private set;
        } = new(new List<Constant>());
        
        /// <summary>
        /// Gets or sets the <see cref="AccessFlags"/>.
        /// </summary>
        public ClassAccessFlags AccessFlags
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> that describes this class.
        /// </summary>
        public ushort ThisClassIndex
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets the index into the <see cref="ConstantPool"/> that describes the superclass.
        /// </summary>
        public ushort SuperClassIndex
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets the indices into the <see cref="Constants"/> representing direct superinterfaces of this class.
        /// </summary>
        public IList<ushort> Interfaces
        {
            get;
            private set;
        } = new List<ushort>();

        /// <summary>
        /// Gets or sets the fields of this class.
        /// </summary>
        public IList<JvmFieldInfo> Fields
        {
            get;
            private set;
        } = new List<JvmFieldInfo>();

        /// <summary>
        /// Gets or sets the methods of this class.
        /// </summary>
        public IList<JvmMethodInfo> Methods
        {
            get;
            private set;
        } = new List<JvmMethodInfo>();

        /// <summary>
        /// Gets or sets the attributes of this class.
        /// </summary>
        public IList<JvmAttribute> Attributes
        {
            get;
            private set;
        } = new List<JvmAttribute>();

        /// <summary>
        /// Writes the <see cref="ClassFile"/> to the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The path to write the <see cref="ClassFile"/> to.</param>
        public void Write(string path)
        {
            using var destination = new FileDataDestination(path);
            Write(destination);
        }

        /// <summary>
        /// Writes the <see cref="ClassFile"/> to a byte array.
        /// </summary>
        /// <returns>The bytes of the <see cref="ClassFile"/>.</returns>
        public byte[] Write()
        {
            var destination = new ByteArrayDataDestination();
            Write(destination);

            return destination.Buffer;
        }

        /// <summary>
        /// Writes the <see cref="ClassFile"/> to the specified output <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The output <see cref="Stream"/>.</param>
        public void Write(Stream stream) => Write(new StreamDataDestination(stream));

        private void Write(IDataDestination destination)
        {
            var writer = new BigEndianWriter(destination);
            
            ClassFileHeader.IntoWriter(this, writer);
            ConstantPool.IntoWriter(this, writer);
            ClassFileBody.IntoWriter(this, writer);
            MetadataBody.IntoWriter(this, writer);
        }

        /// <summary>
        /// Reads and parses a <see cref="ClassFile"/> from the given <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The file's path to read.</param>
        /// <returns>The read and parsed <see cref="ClassFile"/>.</returns>
        public static ClassFile FromFile(string path) => Read(new FileDataSource(path));

        /// <summary>
        /// Reads and parses a <see cref="ClassFile"/> from an array of <paramref name="bytes"/>.
        /// </summary>
        /// <param name="bytes">The raw bytes.</param>
        /// <returns>The read and parsed <see cref="ClassFile"/>.</returns>
        public static ClassFile FromBytes(byte[] bytes) => Read(new ByteArrayDataSource(bytes));

        /// <summary>
        /// Reads and parses a <see cref="ClassFile"/> from the given input <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The input <see cref="Stream"/> to read data from.</param>
        /// <returns>The read and parsed <see cref="ClassFile"/>.</returns>
        public static ClassFile FromStream(Stream stream) => Read(new StreamDataSource(stream));

        private static ClassFile Read(IDataSource source)
        {
            var reader = new BigEndianReader(source);
            
            var header = ClassFileHeader.FromReader(reader);
            var constantPool = ConstantPool.FromReader(reader);
            var body = ClassFileBody.FromReader(reader);
            var metadata = MetadataBody.FromReader(reader, constantPool);
            
            return new ClassFile
            {
                Magic = header.Magic,
                MinorVersion = header.Minor,
                MajorVersion = header.Major,
                Constants = constantPool,
                AccessFlags = body.AccessFlags,
                ThisClassIndex = body.ThisClass,
                SuperClassIndex = body.SuperClass,
                Interfaces = metadata.Interfaces,
                Fields = metadata.Fields,
                Methods = metadata.Methods,
                Attributes = metadata.Attributes
            };
        }
    }
}