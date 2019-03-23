using System;

namespace NumberExtensions
{
    /// <summary>
    /// The <code>InsertAlgo</code> class.
    /// Contains the newton method to calculate the root
    /// </summary>
    public class RootFinder
    {
        /// <summary>
        /// Calculate the root
        /// </summary>
        /// <param name="a">Real number</param>
        /// <param name="n">Degree</param>
        /// <param name="accuracy">Accuracy</param>
        /// <returns>A root</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when <code>n</code> less than 1 or accuracy is negative
        /// </exception>
        /// <exception cref="ArithmeticException">
        /// Thrown when <code>a</code> is negative and <code>n</code> is even
        /// </exception>
        public double FindNthRoot(double a, int n, double accuracy)
        {
            CheckParameters(a, n, accuracy);

            if (a == 0 || n == 1)
            {
                return a;
            }

            double x = a / n;

            while (Math.Abs(Math.Pow(x, n) - a) > accuracy)
            {
                x = 1.0 / n * ((n - 1.0) * x + a / Math.Pow(x, n - 1.0));
            }

            int digits = (accuracy < 1.0) ? (int)-Math.Floor(Math.Log10(accuracy)) - 1 : 0;

            if (digits > 15)
            {
                digits = 15;
            }

            return Math.Round(x, digits);
        }

        private void CheckParameters(double a, int n, double accuracy)
        {
            if (n < 1 || accuracy <= 0)
            {
                throw new ArgumentException();
            }

            if (a < 0 && IsEven(n))
            {
                throw new ArithmeticException();
            }
        }

        private bool IsEven(int num)
        {
            return (num & 1) == 0;
        }
    }
}
