using System;
using System.Collections.Generic;

namespace NumberExtensions
{
    public class DigitFilter
    {
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
