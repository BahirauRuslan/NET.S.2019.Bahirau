using System;

namespace CustomMatrix
{
    /// <summary>
    /// Static MatrixSumExtension class.
    /// </summary>
    public static class MatrixSumExtension
    {
        /// <summary>
        /// Gets sum of two static matrix
        /// </summary>
        /// <typeparam name="T">Type of items.</typeparam>
        /// <param name="firstMatrix">First static matrix.</param>
        /// <param name="secondMatrix">Second static matrix.</param>
        /// <returns>Static matrix that represent sum of two static matrix</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when first or second matrix is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when size of two matrix are incompatible
        /// </exception>
        public static RectangleMatrix<T> Sum<T>(this StaticMatrix<T> firstMatrix, StaticMatrix<T> secondMatrix)
        {
            if (firstMatrix == null || secondMatrix == null)
            {
                throw new ArgumentNullException("Matrix must be not null");
            }

            if (firstMatrix.RowsCount != secondMatrix.RowsCount 
                || firstMatrix.ColumnsCount != secondMatrix.ColumnsCount)
            {
                throw new ArgumentException("Incompatible sizes of two matrix");
            }

            var itemsTable = new T[firstMatrix.RowsCount, firstMatrix.ColumnsCount];

            for (var i = 0; i < firstMatrix.RowsCount; i++)
            {
                for (var j = 0; j < firstMatrix.ColumnsCount; j++)
                {
                    itemsTable[i, j] = (dynamic)firstMatrix[i, j] + (dynamic)secondMatrix[i, j];
                }
            }

            return new RectangleMatrix<T>(itemsTable);
        }
    }
}
