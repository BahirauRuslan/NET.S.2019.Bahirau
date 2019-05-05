using NLog;

namespace DAL.Loggers
{
    /// <summary>
    /// A logger that uses NLog for logging.
    /// </summary>
    public class NInfoLogger : Interface.Interfaces.ILogger
    {
        /// <summary>
        /// NLog framework logger.
        /// </summary>
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Writes the diagnostic message at the INFO level.
        /// </summary>
        /// <param name="message">Log message.</param>
        public void Log(string message)
        {
            this.logger.Info(message);
        }
    }
}
