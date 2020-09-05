using System;
using System.Collections;
using System.Collections.Generic;
using Bali.IO.Constants;

namespace Bali
{
    /// <summary>
    /// Provides a <b><i>one</i></b>-base indexed list of <see cref="Constant"/>s.
    /// </summary>
    public readonly struct ConstantPool : IList<Constant>
    {
        private readonly IList<Constant> _constants;
        
        /// <summary>
        /// Creates a new <see cref="ConstantPool"/> with the specified <paramref name="constants"/>.
        /// </summary>
        /// <param name="constants">The <see cref="Constant"/>s to initialize the pool with.</param>
        public ConstantPool(IList<Constant> constants) =>
            _constants = constants;

        /// <summary>
        /// Gets or sets the <see cref="Constant"/> at the given <paramref name="index"/>.
        /// </summary>
        /// <param name="index">The <b>one</b>-based index of the <see cref="Constant"/> to get or set.</param>
        /// <remarks>The constants pool is <b>NOT</b> zero-indexed.</remarks>
        public Constant this[int index]
        {
            get => _constants[index - 1];
            set => _constants[index - 1] = value;
        }

        /// <summary>
        /// Gets the number of constants in the pool <b><i>+ 1</i></b>.
        /// </summary>
        public int Count => _constants.Count + 1;

        /// <inheritdoc />
        public bool IsReadOnly => false;

        /// <inheritdoc />
        public void Clear() => _constants.Clear();

        /// <inheritdoc />
        public int IndexOf(Constant item)
        {
            int index = _constants.IndexOf(item);
            if (index == -1)
                return -1;
            
            return index + 1;
        }

        /// <inheritdoc />
        public bool Contains(Constant item) => _constants.Contains(item);

        /// <inheritdoc />
        public void Add(Constant item) => _constants.Add(item);

        /// <summary>
        /// Inserts the specified <paramref name="item"/> into the constant pool at the specified <paramref name="index"/>.
        /// </summary>
        /// <param name="index">The <b><i>one</i></b>-based index to insert the <paramref name="item"/> into.</param>
        /// <param name="item">The <see cref="Constant"/> to insert at the specified <paramref name="index"/>.</param>
        public void Insert(int index, Constant item) => _constants.Insert(index + 1, item);

        /// <inheritdoc />
        public bool Remove(Constant item) => _constants.Remove(item);

        /// <summary>
        /// Removes the constant at the specified <paramref name="index"/>.
        /// </summary>
        /// <param name="index">The <b><i>one</i></b>-based index to remove the constant from.</param>
        public void RemoveAt(int index) => _constants.RemoveAt(index + 1);

        /// <summary>
        /// Copies the constants into the specified <paramref name="array"/>.
        /// </summary>
        /// <param name="array">The <see cref="Array"/> to copy the constants to.</param>
        /// <param name="arrayIndex">The <b><i>zero</i></b>-based index into the <paramref name="array"/> to copy elements to.</param>
        public void CopyTo(Constant[] array, int arrayIndex)
        {
            for (int i = 1; i < Count; i++)
            {
                array[arrayIndex + i - 1] = this[i];
            }
        }

        /// <inheritdoc />
        public IEnumerator<Constant> GetEnumerator() => _constants.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}