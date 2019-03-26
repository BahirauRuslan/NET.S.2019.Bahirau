using System;
using System.Diagnostics;

namespace Day3Tasks
{
    /// <summary>
    /// The SteinAlgorithm static class.
    /// Implement Stein's alorithm for finding GCD
    /// </summary>
    public static class SteinAlgorithm
    {
        /// <summary>
        /// Find the GCD of two or more integers
        /// </summary>
        /// <param name="nums">Integers</param>
        /// <returns>An integer that is the GCD of all nums</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when parameter nums is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when count of parameters is less than two or when all parameters is zeroes
        /// </exception>
        public static int GetGCDStein(this EuclidAlgo algo, params int[] nums)
        {
            if (nums == null)
            {
                throw new ArgumentNullException();
            }

            if (nums.Length < 2)
            {
                throw new ArgumentException("Count of arguments must be two or more");
            }

            int gcd = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                gcd = GetGCDStein(gcd, nums[i]);
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
        /// <param name="nums">Integers</param>
        /// <returns>An integer that is the GCD of all nums</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when parameter nums is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when count of nums parameters is less than two or when all nums is zeroes
        /// </exception>
        public static int GetGCDSteinAndTime(this EuclidAlgo algo, out double time, params int[] nums)
        {
            int gcd;
            var wathc = Stopwatch.StartNew();
            gcd = algo.GetGCDStein(nums);
            wathc.Stop();
            time = wathc.Elapsed.TotalMilliseconds;
            return gcd;
        }

        /// <summary>
        /// Find the GCD of two integers
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <returns>An integer that is the GCD of params a and b</returns>
        private static int GetGCDStein(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            int shift = 0;

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            while (((a | b) & 1) == 0)
            {
                shift++;
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
            {
                a >>= 1;
            }

            do
            {
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }

                if (a > b)
                {
                    int t = b;
                    b = a;
                    a = t;
                }

                b -= a;
            }
            while (b != 0);

            return a << shift;
        }
    }
}
