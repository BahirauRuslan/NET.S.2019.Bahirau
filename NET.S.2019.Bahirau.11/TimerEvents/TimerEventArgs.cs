namespace TimerEvents
{
    /// <summary>
    /// TimerEventArgs class.
    /// </summary>
    public class TimerEventArgs
    {
        /// <summary>
        /// Construct TimerEventArgs object
        /// </summary>
        /// <param name="message">Timer message.</param>
        /// <param name="time">Time delay.</param>
        public TimerEventArgs(string message, int time)
        {
            Message = message;
            Time = time;
        }

        /// <summary>
        /// Timer message.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Time delay.
        /// </summary>
        public int Time { get; }
    }
}