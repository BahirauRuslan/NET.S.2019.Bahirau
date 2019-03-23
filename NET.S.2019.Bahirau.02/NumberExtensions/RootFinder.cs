using System;
using System.Collections.Generic;
using System.Text;

namespace NumberExtensions
{
    public class RootFinder
    {
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
