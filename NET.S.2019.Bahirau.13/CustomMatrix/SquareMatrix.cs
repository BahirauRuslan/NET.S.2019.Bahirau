using System;

namespace CustomMatrix
{
    /// <summary>
    /// SquareMatrix class.
    /// </summary>
    /// <typeparam name="T">Type of items.</typeparam>
    public class SquareMatrix<T> : RectangleMatrix<T>
    {
        /// <summary>
        /// Creates square matrix.
        /// </summary>
        public SquareMatrix() : base()
        {
        }

        /// <summary>
        /// Creates square matrix from itemsTable rectangle array.
        /// </summary>
        /// <param name="itemsTable">Rectangle array.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when itemsTable is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when itemsTable dimension (0 or 1) length less than one.
        /// -or- Dimensions of itemsTable not equal.
        /// </exception>
        public SquareMatrix(T[,] itemsTable) : base(itemsTable)
        {
            if (itemsTable.GetLength(0) != itemsTable.GetLength(1))
            {
                throw new ArgumentException("ItemsTable dimensions lengths must be equal");
            }
        }

        /// <summary>
        /// Creates square matrix from another square matrix.
        /// </summary>
        /// <param name="matrix">Square matrix.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when matrix is null.
        /// </exception>
        public SquareMatrix(SquareMatrix<T> matrix) : base(matrix)
        {
        }
    }
}
