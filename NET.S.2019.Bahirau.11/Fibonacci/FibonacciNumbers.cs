using System;
using System.Collections.Generic;

namespace Fibonacci
{
    /// <summary>
    /// Fibonacci generator class.
    /// </summary>
    public class FibonacciNumbers
    {
        /// <summary>
        /// Get first fibonacci numbers.
        /// </summary>
        /// <param name="count">Count of fibonacci numbers.</param>
        /// <returns>Fibonacci numbers.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when count less than one.
        /// </exception>
        public IEnumerable<int> GenerateNumbers(int count)
        {
            if (count < 1)
            {
                throw new ArgumentException("Count must be more than zero");
            }

            return Generate(count);
        }

        /// <summary>
        /// Get first fibonacci numbers.
        /// </summary>
        /// <param name="count">Count of fibonacci numbers.</param>
        /// <returns>Fibonacci numbers.</returns>
        private IEnumerable<int> Generate(int count)
        {
            var preprevious = 0;
            var previous = 1;

            yield return preprevious;
            var number = previous;

            for (int i = 0; i < count - 1; i++)
            {
                yield return number;
                number = preprevious + previous;
                preprevious = previous;
                previous = number;
            }
        }
    }
}
