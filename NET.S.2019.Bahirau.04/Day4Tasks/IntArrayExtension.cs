using System;

namespace Day4Tasks
{
    /// <summary>
    /// Has extension method for comparing two arrays
    /// </summary>
    public static class IntArrayExtension
    {
        /// <summary>
        /// Delegate to get an array property
        /// </summary>
        /// <param name="arr">Array of integers</param>
        /// <returns>Integer array property</returns>
        public delegate int Parameter(int[] arr);

        /// <summary>
        /// Compares two arrays by property
        /// </summary>
        /// <param name="arr">Array of integers</param>
        /// <param name="secondArr">Second array of integers</param>
        /// <param name="parameter"> Delegate to get an array property</param>
        /// <returns>
        /// 1 - if property of first array more than property of second array
        /// 0 - if property of first array equal property of second array
        /// -1 - if property of first array less than property of second array
        /// </returns>
        public static int ExtensionCompareTo(this int[] arr, int[] secondArr, Parameter parameter)
        {
            if (secondArr == null || parameter == null)
            {
                throw new ArgumentNullException("Expected not null but was null");
            }

            if (arr.Length < 1 || secondArr.Length < 1)
            {
                throw new ArgumentException("Array must be non-empty");
            }

            return parameter(arr).CompareTo(parameter(secondArr));
        }
    }
}
