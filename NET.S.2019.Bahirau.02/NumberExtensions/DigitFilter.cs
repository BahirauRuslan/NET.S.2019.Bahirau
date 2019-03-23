using System;
using System.Collections.Generic;

namespace NumberExtensions
{
    /// <summary>
    /// The <code>DigitFilter</code> class.
    /// Contains a filter for numbers
    /// </summary>
    public class DigitFilter
    {
        /// <summary>
        /// Filters numbers and selects those that contain the given digit
        /// </summary>
        /// <param name="numbers">Numbers</param>
        /// <param name="digit">Filter digit</param>
        /// <returns>Filtered list of numbers</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when parameter <code>numbers</code> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when parameter <code>digit</code> is not digit
        /// </exception>
        public IEnumerable<int> FilterDigit(IEnumerable<int> numbers, int digit)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException();
            }

            if (digit < 0 || digit > 9)
            {
                throw new ArgumentException();
            }

            IList<int> sortedNumbers = new List<int>();

            foreach (int number in numbers)
            {
                if (HasDigit(number, digit))
                {
                    sortedNumbers.Add(number);
                }
            }

            return sortedNumbers;
        }

        private bool HasDigit(int number, int digit)
        {
            number = Math.Abs(number);

            if (number == digit)
            {
                return true;
            }

            while (number > 0)
            {
                if (number % 10 == digit)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }
    }
}
