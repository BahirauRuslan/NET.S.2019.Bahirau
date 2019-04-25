using System;

namespace CustomMatrix
{
    /// <summary>
    /// RectangleMatrix class.
    /// </summary>
    /// <typeparam name="T">Type of items.</typeparam>
    public class RectangleMatrix<T> : StaticMatrix<T>
    {
        /// <summary>
        /// Creates rectangle matrix.
        /// </summary>
        public RectangleMatrix() : base()
        {
        }

        /// <summary>
        /// Creates rectangle matrix from itemsTable rectangle array.
        /// </summary>
        /// <param name="itemsTable">Rectangle array.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when itemsTable is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when itemsTable dimension (0 or 1) length less than one.
        /// </exception>
        public RectangleMatrix(T[,] itemsTable) : base(itemsTable)
        {
        }

        /// <summary>
        /// Creates rectangle matrix from another static matrix.
        /// </summary>
        /// <param name="matrix">Static matrix.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when matrix is null.
        /// </exception>
        public RectangleMatrix(StaticMatrix<T> matrix) : base(matrix)
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
            }
        }
    }
}
