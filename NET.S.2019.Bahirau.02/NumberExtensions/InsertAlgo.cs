using System;

namespace NumberExtensions
{
    public class InsertAlgo
    {
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
