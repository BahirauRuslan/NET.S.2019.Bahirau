using System;
using System.Linq;

namespace Day4Tasks
{
    /// <summary>
    /// The BubbleAlgorithm static class.
    /// Has bubble sorting methods for jagged arrays
    /// </summary>
    public static class BubbleAlgorithm
    {
        /// <summary>
        /// Sort jagged array by sum of values
        /// </summary>
        /// <param name="jaggedArr">Array of arrays of integers</param>
        /// <param name="desc">Descending order</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when jagged array or item of jagged array or parameter is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when jagged array or item of jagged array is empty
        /// </exception>
        public static void BubbleSortBySum(int[][] jaggedArr, bool desc = false)
        {
            int parameter(int[] arr) => (from num in arr select num).Sum();
            BubbleSort(jaggedArr, parameter, desc);
        }

        /// <summary>
        /// Sort jagged array by maximum value
        /// </summary>
        /// <param name="jaggedArr">Array of arrays of integers</param>
        /// <param name="desc">Descending order</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when jagged array or item of jagged array or parameter is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when jagged array or item of jagged array is empty
        /// </exception>
        public static void BubbleSortByMax(int[][] jaggedArr, bool desc = false)
        {
            int parameter(int[] arr) => (from num in arr orderby num select num).Last();
            BubbleSort(jaggedArr, parameter, desc);
        }

        /// <summary>
        /// Sort jagged array by minimum value
        /// </summary>
        /// <param name="jaggedArr">Array of arrays of integers</param>
        /// <param name="desc">Descending order</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when jagged array or item of jagged array or parameter is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when jagged array or item of jagged array is empty
        /// </exception>
        public static void BubbleSortByMin(int[][] jaggedArr, bool desc = false)
        {
            int parameter(int[] arr) => (from num in arr orderby num select num).First();
            BubbleSort(jaggedArr, parameter, desc);
        }

        /// <summary>
        /// Sort jagged array by property
        /// </summary>
        /// <param name="jaggedArr">Array of arrays of integers</param>
        /// <param name="parameter">Delegate to get an array property</param>
        /// <param name="desc">Descending order</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when jagged array or item of jagged array or parameter is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when jagged array or item of jagged array is empty
        /// </exception>
        public static void BubbleSort(int[][] jaggedArr, IntArrayExtension.Parameter parameter, bool desc = false)
        {
            CheckJaggerArray(jaggedArr, parameter);

            var descCoefficient = desc ? -1 : 1;

            for (var i = 0; i < jaggedArr.Length - 1; i++)
            {
                for (var j = 0; j < jaggedArr.Length - i - 1; j++)
                {
                    if (descCoefficient * jaggedArr[j].ExtensionCompareTo(jaggedArr[j + 1], parameter) > 0)
                    {
                        Swap(ref jaggedArr[j], ref jaggedArr[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Swap two arrays of integers
        /// </summary>
        /// <param name="arr1">First array of integers</param>
        /// <param name="arr2">Second array of integers</param>
        private static void Swap(ref int[] arr1, ref int[] arr2)
        {
            var temp = arr1;
            arr1 = arr2;
            arr2 = temp;
        }

        /// <summary>
        /// Check parameters for bubble sorting
        /// </summary>
        /// <param name="jaggerArr">Array of arrays of integers</param>
        /// <param name="parameter">Delegate to get an array property</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when jagged array or item of jagged array or parameter is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when jagged array or item of jagged array is empty
        /// </exception>
        private static void CheckJaggerArray(int[][] jaggerArr, IntArrayExtension.Parameter parameter)
        {
            if (jaggerArr == null || parameter == null)
            {
                throw new ArgumentNullException("Expected not null but was null");
            }

            if (jaggerArr.Length < 1)
            {
                throw new ArgumentException("Jagger arr must be non-empty");
            }

            for (var i = 0; i < jaggerArr.Length; i++)
            {
                if (jaggerArr[i] == null)
                {
                    throw new ArgumentNullException("Expected array of integers but was null");
                }

                if (jaggerArr[i].Length < 1)
                {
                    throw new ArgumentException("Array must be non-empty");
                }
            }
        }
    }
}
