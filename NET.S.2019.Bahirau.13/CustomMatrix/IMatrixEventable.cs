namespace CustomMatrix
{
    /// <summary>
    /// Change item state delegate.
    /// </summary>
    /// <typeparam name="T">Type of matrix items.</typeparam>
    /// <param name="sender">Object sender.</param>
    /// <param name="e">Matrix event arguments.</param>
    public delegate void ChangeItemState<T>(object sender, MatrixEventArgs<T> e);

    /// <summary>
    /// Interface that represent changeState event.
    /// </summary>
    /// <typeparam name="T">Type of matrix items.</typeparam>
    public interface IMatrixEventable<T>
    {
        /// <summary>
        /// Change item state event.
        /// </summary>
        event ChangeItemState<T> ChangeState;
    }
}
