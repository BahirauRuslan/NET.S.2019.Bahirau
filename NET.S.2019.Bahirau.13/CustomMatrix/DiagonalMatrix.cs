using System;

namespace CustomMatrix
{
    /// <summary>
    /// DiagonalMatrix class.
    /// </summary>
    /// <typeparam name="T">Type of items.</typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Creates diagonal matrix.
        /// </summary>
        public DiagonalMatrix() : base()
        {
        }

        /// <summary>
        /// Creates diagonal matrix from itemsTable rectangle array.
        /// </summary>
        /// <param name="itemsTable">Rectangle array.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when itemsTable is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when itemsTable dimension (0 or 1) length less than one.
        /// -or- Dimensions of itemsTable not equal. 
        /// -or- itemsTable isn't diagonal table.
        /// </exception>
        public DiagonalMatrix(T[,] itemsTable) : base(itemsTable)
        {
            for (var i = 0; i < itemsTable.GetLength(0); i++)
            {
                for (var j = 0; j < itemsTable.GetLength(1); j++)
                {
                    if (i != j && !(itemsTable[i, j] == null || itemsTable[i, j].Equals(default(T))))
                    {
                        throw new ArgumentException("Non-diagonal itemsTable");
                    }
                }
            }
        }

        /// <summary>
        /// Creates diagonal matrix from another diagonal matrix.
        /// </summary>
        /// <param name="matrix">Diagonal matrix.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when matrix is null.
        /// </exception>
        public DiagonalMatrix(DiagonalMatrix<T> matrix) : base(matrix)
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
        }

        /// <summary>
        /// Matrix diagonal item
        /// </summary>
        /// <param name="i">Row and column index.</param>
        /// <returns>Matrix item of type T.</returns>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when indexes out of range.
        /// </exception>
        public T this[int i]
        {
            get
            {
                return this[i, i];
            }

            set
            {
                base[i, i] = value;
            }
        }
    }
}
