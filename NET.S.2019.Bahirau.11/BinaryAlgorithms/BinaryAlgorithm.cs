using System;
using System.Collections.Generic;

namespace BinaryAlgorithms
{
    /// <summary>
    /// Binary search class
    /// </summary>
    public class BinaryAlgorithm
    {
        /// <summary>
        /// Find index of key item in array.
        /// </summary>
        /// <typeparam name="T">Type of array and key.</typeparam>
        /// <param name="array">Array of type T.</param>
        /// <param name="key">Key.</param>
        /// <param name="comparer">Comparer.</param>
        /// <returns>Index of item if key is find or -1 when key is not found.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when array or comparer is null.
        /// </exception>
        public int Search<T>(T[] array, T key, IComparer<T> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Expected array but was null");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException("Expected comparer but was null");
            }

            if (array.Length == 0)
            {
                return -1;
            }

            return Search(array, key, 0, array.Length - 1, comparer);
        }

        /// <summary>
        /// Find index of key item in array.
        /// </summary>
        /// <typeparam name="T">Type of array and key.</typeparam>
        /// <param name="array">Array of type T.</param>
        /// <param name="key">Key.</param>
        /// <param name="left">Left border.</param>
        /// <param name="right">Right border.</param>
        /// <param name="comparer">Comparer.</param>
        /// <returns>Index of item if key is find or -1 when key is not found.</returns>
        private int Search<T>(T[] array, T key, int left, int right, IComparer<T> comparer)
        {
            while (right - left > 1)
            {
                var index = ((right - left) / 2) + left;
                var compareResult = comparer.Compare(key, array[index]);

                if (compareResult == 0)
                {
                    return index;
                }
                else if (compareResult < 0)
                {
                    right = index;
                }
                else if (compareResult > 0)
                {
                    left = index;
                }
            }

            if (comparer.Compare(key, array[left]) == 0)
            {
                return left;
            }
            else if (comparer.Compare(key, array[right]) == 0)
            {
                return right;
            }
            else
            {
                return -1;
            }
        }
    }
}
