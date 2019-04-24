namespace CustomMatrix
{
    /// <summary>
    /// Event arguments.
    /// </summary>
    /// <typeparam name="T">Type of matrix items.</typeparam>
    public class MatrixEventArgs<T>
    {
        /// <summary>
        /// Construct MatrixEventArgs
        /// </summary>
        /// <param name="row">Row index of item.</param>
        /// <param name="column">Column index of item.</param>
        /// <param name="before">Item state before.</param>
        /// <param name="after">Item state after.</param>
        public MatrixEventArgs(int row, int column, T before, T after)
        {
            Row = row;
            Column = column;
            Before = before;
            After = after;
        }

        /// <summary>
        /// Row index of item.
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// Column index of item.
        /// </summary>
        public int Column { get; }

        /// <summary>
        /// Item state before.
        /// </summary>
        public T Before { get; }

        /// <summary>
        /// Item state after.
        /// </summary>
        public T After { get; }
    }
}
