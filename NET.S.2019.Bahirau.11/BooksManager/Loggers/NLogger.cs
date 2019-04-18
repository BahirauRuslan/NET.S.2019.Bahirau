using NLog;

namespace BooksManager.Loggers
{
    /// <summary>
    /// Logger that uses NLog framework.
    /// </summary>
    public class NLogger : ILogger
    {
        /// <summary>
        /// NLog framework logger.
        /// </summary>
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Writes the diagnostic message at the specified level.
        /// </summary>
        /// <param name="ordinal">Ordinal of the log level.</param>
        /// <param name="message">Log message.</param>
        public void Log(int ordinal, string message)
        {
            if (ordinal < LogLevel.Trace.Ordinal || ordinal > LogLevel.Off.Ordinal)
            {
                logger.Warn("Invalid ordinal level. Logger level is Off");
                ordinal = LogLevel.Off.Ordinal;
            }

            logger.Log(LogLevel.FromOrdinal(ordinal), message);
        }
    }
}
