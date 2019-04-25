using System;

namespace CustomMatrix
{
    /// <summary>
    /// Static matrix class.
    /// </summary>
    /// <typeparam name="T">Type of items.</typeparam>
    public class StaticMatrix<T> : IMatrixEventable<T>
    {
        /// <summary>
        /// Items.
        /// </summary>
        private readonly T[,] _items;

        /// <summary>
        /// Creates StaticMatrix.
        /// </summary>
        public StaticMatrix()
        {
            _items = new T[0, 0];
        }

        /// <summary>
        /// Creates static matrix from itemsTable rectangle array.
        /// </summary>
        /// <param name="itemsTable">Rectangle array.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when itemsTable is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when itemsTable dimension (0 or 1) length less than one.
        /// </exception>
        public StaticMatrix(T[,] itemsTable)
        {
            ValidateItemsTable(itemsTable);
            _items = (T[,])itemsTable.Clone();
        }

        /// <summary>
        /// Creates static matrix from another static matrix.
        /// </summary>
        /// <param name="matrix">Static matrix.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when matrix is null.
        /// </exception>
        public StaticMatrix(StaticMatrix<T> matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("Matrix must be not null");
            }

            _items = new T[matrix.RowsCount, matrix.ColumnsCount];

            for (var i = 0; i < _items.GetLength(0); i++)
            {
                for (var j = 0; j < _items.GetLength(1); j++)
                {
                    _items[i, j] = matrix[i, j];
                }
            }
        }

        /// <summary>
        /// Change item state event.
        /// </summary>
        public event ChangeItemState<T> ChangeState;

        /// <summary>
        /// Count of rows.
        /// </summary>
        public int RowsCount => _items.GetLength(0);

        /// <summary>
        /// Count of columns.
        /// </summary>
        public int ColumnsCount => _items.GetLength(1);

        /// <summary>
        /// Matrix item.
        /// </summary>
        /// <param name="i">Row index.</param>
        /// <param name="j">Column index</param>
        /// <returns>Matrix item of type T.</returns>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when indexes out of range.
        /// </exception>
        public T this[int i, int j]
        {
            get
            {
                if (!IsValidIndexes(i, j))
                {
                    throw new IndexOutOfRangeException();
                }
                
                return _items[i, j];
            }

            protected set
            {
                if (!IsValidIndexes(i, j))
                {
                    throw new IndexOutOfRangeException();
                }

                var item = _items[i, j];
                _items[i, j] = value;
                InvokeChange(i, j, item, _items[i, j]);
            }
        }

        /// <summary>
        /// Return current matrix as rectangle array.
        /// </summary>
        /// <returns>Rectangle array.</returns>
        public T[,] ToRectangleArray()
        {
            return (T[,])_items.Clone();
        }

        /// <summary>
        /// Invoke ChangeState event.
        /// </summary>
        /// <param name="i">Row index.</param>
        /// <param name="j">Column index.</param>
        /// <param name="before">State before.</param>
        /// <param name="after">State after.</param>
        protected void InvokeChange(int i, int j, T before, T after)
        {
            ChangeState?.Invoke(this, new MatrixEventArgs<T>(i, j, before, after));
        }

        /// <summary>
        /// Indicates that indexes in array bounds.
        /// </summary>
        /// <param name="i">Row index.</param>
        /// <param name="j">Column index.</param>
        /// <returns>True - valid indexes. False - another cases.</returns>
        protected bool IsValidIndexes(int i, int j)
        {
            return i > -1 && i < RowsCount && j > -1 && j < ColumnsCount;
        }

        /// <summary>
        /// Check itemsTable.
        /// </summary>
        /// <param name="itemsTable">ItemsTable rectangle array.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when itemsTable is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when itemsTable dimension (0 or 1) length less than one.
        /// </exception>
        protected void ValidateItemsTable(T[,] itemsTable)
        {
            if (itemsTable == null)
            {
                throw new ArgumentNullException("ItemsTable must be not null");
            }

            if (itemsTable.GetLength(0) == 0 || itemsTable.GetLength(1) == 0)
            {
                throw new ArgumentException("All dimensions lengths must be more than zero");
            }
        }
    }
}
