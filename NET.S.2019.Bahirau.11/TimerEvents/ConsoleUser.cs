using System;

namespace TimerEvents
{
    /// <summary>
    /// Console user class.
    /// </summary>
    public class ConsoleUser
    {
        /// <summary>
        /// Create ConsoleUser object.
        /// </summary>
        /// <param name="id">User id.</param>
        public ConsoleUser(int id)
        {
            UserId = id;
        }

        /// <summary>
        /// User id.
        /// </summary>
        public int UserId { get; }

        /// <summary>
        /// Print message to console.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Timer arguments.</param>
        public void ReceiveMessage(object sender, TimerEventArgs e)
        {
            Console.Write("User received a message: ");
            Console.WriteLine(e.Message);
            Console.WriteLine(" Sender string representation: {0}", sender);
        }
    }
}
