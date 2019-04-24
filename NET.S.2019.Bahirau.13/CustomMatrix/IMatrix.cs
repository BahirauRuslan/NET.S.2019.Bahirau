namespace CustomMatrix
{
    /// <summary>
    /// Interface that represent a matrix.
    /// </summary>
    /// <typeparam name="T">Type of elements.</typeparam>
    public interface IMatrix<T>
    {
        /// <summary>
        /// Matrix item.
        /// </summary>
        /// <param name="i">Row index.</param>
        /// <param name="j">Column index</param>
        /// <returns>Matrix item of type T.</returns>
        T this[int i, int j] { get; set; }

        /// <summary>
        /// Count of rows.
        /// </summary>
        int RowsCount { get; }

        /// <summary>
        /// Count of columns.
        /// </summary>
        int ColumnsCount { get; }
    }
}
