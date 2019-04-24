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
        /// Indicates that matrix and this matrix have the same size.
        /// </summary>
        /// <param name="matrix">Another matrix.</param>
        /// <returns>True - matrix and this matrix have the same size. False - another case.</returns>
        bool IsSameSize(IMatrix<T> matrix);
    }
}
