using System;

namespace CustomMatrix
{
    /// <summary>
    /// SymmetricMatrix class.
    /// </summary>
    /// <typeparam name="T">Type of items.</typeparam>
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Creates symmetric matrix.
        /// </summary>
        public SymmetricMatrix() : base()
        {
        }

        /// <summary>
        /// Creates symmetric matrix from itemsTable rectangle array.
        /// </summary>
        /// <param name="itemsTable">Rectangle array.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when itemsTable is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when itemsTable dimension (0 or 1) length less than one.
        /// -or- Dimensions of itemsTable not equal. 
        /// -or ItemsTable not symmetrical.
        /// </exception>
        public SymmetricMatrix(T[,] itemsTable) : base(itemsTable)
        {
            for (var i = 0; i < itemsTable.GetLength(0); i++)
            {
                for (var j = i; j < itemsTable.GetLength(1); j++)
                {
                    if (!this.IsSame(itemsTable[i, j], itemsTable[j, i]))
                    {
                        throw new ArgumentException("Non-symmetrical itemsTable");
                    }
                }
            }
        }

        /// <summary>
        /// Creates symmetric matrix from another symmetric matrix.
        /// </summary>
        /// <param name="matrix">Symmetric matrix.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when matrix is null.
        /// </exception>
        public SymmetricMatrix(SymmetricMatrix<T> matrix) : base(matrix)
        {
        }

        /// <summary>
        /// Matrix item.
        /// </summary>
        /// <param name="i">Row index.</param>
        /// <param name="j">Column index</param>
        /// <returns>Matrix item of type T.</returns>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when indexes out of range.
        /// </exception>
        public new T this[int i, int j]
        {
            get
            {
                return base[i, j];
            }

            set
            {
                base[i, j] = value;
                base[j, i] = value;
            }
        }

        /// <summary>
        /// Compares two items.
        /// </summary>
        /// <param name="item1">First item.</param>
        /// <param name="item2">Second item.</param>
        /// <returns>True - item1 equal item2. False - not equal.</returns>
        private bool IsSame(T item1, T item2)
        {
            return (item1 != null && item1.Equals(item2))
                || (item2 != null && item2.Equals(item1))
                || (item1 == null && item2 == null);
        }
    }
}
