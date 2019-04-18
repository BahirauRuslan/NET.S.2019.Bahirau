namespace BooksManager.Loggers
{
    /// <summary>
    /// Logger with only one log method.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Writes the diagnostic message at the specified level.
        /// </summary>
        /// <param name="ordinal">Ordinal of the log level.</param>
        /// <param name="message">Log message.</param>
        void Log(int ordinal, string message);
    }
}
