using System;

namespace NumberExtensions
{
    /// <summary>
    /// The <code>InsertAlgo</code> class.
    /// Contains a method for inserting a part of one number into another number
    /// </summary>
    public class InsertAlgo
    {
        /// <summary>
        /// Insert a part of one number into another number
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number</param>
        /// <param name="i">First position</param>
        /// <param name="j">Second position</param>
        /// <returns>First number with part of second number</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when <code>i</code> > <code>j</code> or positions less than 0 or more than 31
        /// </exception>
        public int InsertNumber(int firstNumber, int secondNumber, int i, int j)
        {
            CheckPositions(i, j);

            int length = j - i + 1;
            secondNumber &= ~(-1 << length);
            secondNumber <<= i;
            firstNumber &= ~((~(-1 << length)) << i);
            firstNumber |= secondNumber;

            return firstNumber;
        }

        private void CheckPositions(int i, int j)
        {
            if (i > j || i < 0 || i > 31 || j < 0 || j > 31)
            {
                throw new ArgumentException();
            }
        }
    }
}
