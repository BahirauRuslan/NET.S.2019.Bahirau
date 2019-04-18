using System;
using System.Threading;

namespace TimerEvents
{
    /// <summary>
    /// My timer custom class.
    /// </summary>
    public class MyTimer
    {
        /// <summary>
        /// Time delay.
        /// </summary>
        private readonly int _time;

        /// <summary>
        /// Create MyTimer object.
        /// </summary>
        /// <param name="time">Time delay.</param>
        public MyTimer(int time)
        {
            if (time < 0)
            {
                throw new ArgumentOutOfRangeException("Time delay must be more than zero");
            }

            _time = time;
        }

        /// <summary>
        /// TimerState delegate.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Timer arguments.</param>
        public delegate void TimerState(object sender, TimerEventArgs e);

        /// <summary>
        /// Beep event.
        /// </summary>
        public event TimerState Beep;

        /// <summary>
        /// Start my timer.
        /// </summary>
        public void Start()
        {
            Thread.Sleep(_time);
            Beep?.Invoke(this, new TimerEventArgs($"{_time} ms have passed", _time));
        }
    }
}
