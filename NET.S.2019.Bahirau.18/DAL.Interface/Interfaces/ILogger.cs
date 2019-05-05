namespace DAL.Interface.Interfaces
{
    /// <summary>
    /// Interface that represents a simple logger.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs the message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Log(string message);
    }
}
