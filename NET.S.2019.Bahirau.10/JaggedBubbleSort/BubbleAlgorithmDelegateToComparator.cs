﻿using System;
using System.Collections.Generic;
using System.Linq;
using JaggedBubbleSort.IntArrayComparers;

namespace JaggedBubbleSort
{
    /// <summary>
    /// The BubbleAlgorithm class.
    /// Has bubble sorting methods for jagged arrays
    /// </summary>
    public class BubbleAlgorithmDelegateToComparator
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
            Func<int[], int[], int> compare = new SumComparer().Compare;
            BubbleSort(jaggedArr, (IComparer<int[]>)compare.Target, desc);
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
            Func<int[], int[], int> compare = new MaxItemComparer().Compare;
            BubbleSort(jaggedArr, (IComparer<int[]>)compare.Target, desc);
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
            Func<int[], int[], int> compare = new MinItemComparer().Compare;
            BubbleSort(jaggedArr, (IComparer<int[]>)compare.Target, desc);
        }

        /// <summary>
        /// Sort jagged array by property
        /// </summary>
        /// <param name="jaggedArr">Array of arrays of integers</param>
        /// <param name="comparer">Comparer</param>
        /// <param name="desc">Descending order</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when jagged array or item of jagged array or parameter is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when jagged array or item of jagged array is empty
        /// </exception>
        public static void BubbleSort(int[][] jaggedArr, IComparer<int[]> comparer, bool desc = false)
        {
            CheckJaggerArray(jaggedArr, comparer);

            var descCoefficient = desc ? -1 : 1;

            for (var i = 0; i < jaggedArr.Length - 1; i++)
            {
                for (var j = 0; j < jaggedArr.Length - i - 1; j++)
                {
                    if (descCoefficient * comparer.Compare(jaggedArr[j], jaggedArr[j + 1]) > 0)
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
        /// <param name="comparer">Comparer</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when jagged array or item of jagged array or parameter is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when jagged array or item of jagged array is empty
        /// </exception>
        private static void CheckJaggerArray(int[][] jaggerArr, IComparer<int[]> comparer)
        {
            if (jaggerArr == null || comparer == null)
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
