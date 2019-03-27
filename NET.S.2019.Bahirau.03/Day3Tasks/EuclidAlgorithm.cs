using System;
using System.Diagnostics;

namespace Day3Tasks
{
    /// <summary>
    /// The EuclidAlgorithm class. 
    /// Has methods for finding GCD
    /// </summary>
    public class EuclidAlgorithm
    {
        /// <summary>
        /// Find the GCD of two or more integers
        /// </summary>
        /// <param name="numbers">Integers</param>
        /// <returns>An integer that is the GCD of all numbers</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when parameter numbers is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when count of parameters is less than two or when all parameters is zeroes
        /// </exception>
        public static int GetGCD(params int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException();
            }

            if (numbers.Length < 2)
            {
                throw new ArgumentException("Count of arguments must be two or more");
            }

            int gcd = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                gcd = GetGCD(gcd, numbers[i]);
            }

            if (gcd == 0)
            {
                throw new ArgumentException("At least one argument must be non-zero");
            }

            return gcd;
        }

        /// <summary>
        /// Find the GCD of two or more integers and method execution time
        /// </summary>
        /// <param name="time">Out parameter time of method execution</param>
        /// <param name="numbers">Integers</param>
        /// <returns>An integer that is the GCD of all numbers</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when parameter numbers is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when count of numbers parameters is less than two or when all numbers is zeroes
        /// </exception>
        public static int GetGCDAndTime(out double time, params int[] numbers)
        {
            int gcd;
            var wathc = Stopwatch.StartNew();
            gcd = GetGCD(numbers);
            wathc.Stop();
            time = wathc.Elapsed.TotalMilliseconds;
            return gcd;
        }

        /// <summary>
        /// Find the GCD of two integers
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <returns>An integer that is the GCD of parameters a and b</returns>
        private static int GetGCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return a;
        }
    }
}
