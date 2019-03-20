using System;

namespace SortAlgo
{
    /// <summary>
    /// The <code>ArrayExtension</code> class.
    /// Contains static methods for sorting integer arrays
    /// </summary>
    public class ArrayExtension
    {
        /// <summary>
        /// Sorts an array of integers using merge sort
        /// </summary>
        /// <param name="arr">Array of integers</param>
        /// <returns>Sorted array of integers</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when parameter "arr" is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the length of array "arr" is 0
        /// </exception>
        public static int[] MergeSort(int[] arr)
        {
            CheckArrParameter(arr);

            if (arr.Length == 1)
            {
                return arr;
            }

            int sizeOfLeftSide = arr.Length / 2;
            int sizeOfRightSide = arr.Length - sizeOfLeftSide;
            int[] leftSide = new int[sizeOfLeftSide];
            int[] rightSide = new int[sizeOfRightSide];
            Array.Copy(arr, 0, leftSide, 0, sizeOfLeftSide);
            Array.Copy(arr, sizeOfLeftSide, rightSide, 0, sizeOfRightSide);
            return Merge(MergeSort(leftSide), MergeSort(rightSide));
        }

        /// <summary>
        /// Sorts an array of integers using quick sort
        /// </summary>
        /// <param name="arr">Array of integers</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when parameter "arr" is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the length of array "arr" is 0
        /// </exception>
        public static void QuickSort(int[] arr)
        {
            CheckArrParameter(arr);
            QuickSort(arr, 0, arr.Length - 1);
        }

        private static int[] Merge(int[] arr1, int[] arr2)
        {
            int[] arr = new int[arr1.Length + arr2.Length];
            int pointer1 = 0;
            int pointer2 = 0;

            while (pointer1 + pointer2 < arr.Length)
            {
                if (pointer1 < arr1.Length && (pointer2 == arr2.Length || arr1[pointer1] <= arr2[pointer2]))
                {
                    arr[pointer1 + pointer2] = arr1[pointer1++];
                }
                else if (pointer2 < arr2.Length && (pointer1 == arr1.Length || arr2[pointer2] <= arr1[pointer1]))
                {
                    arr[pointer1 + pointer2] = arr2[pointer2++];
                }
            }

            return arr;
        }

        private static void QuickSort(int[] arr, int left, int right)
        {
            int pivot = arr[(left + right) / 2];
            int leftPointer = left;
            int rightPointer = right;
            int temp;

            while (leftPointer <= rightPointer)
            {
                while (arr[leftPointer] < pivot && leftPointer <= right)
                {
                    leftPointer++;
                }

                while (arr[rightPointer] > pivot && rightPointer >= left)
                {
                    rightPointer--;
                }

                if (leftPointer <= rightPointer)
                {
                    temp = arr[leftPointer];
                    arr[leftPointer] = arr[rightPointer];
                    arr[rightPointer] = temp;
                    leftPointer++;
                    rightPointer--;
                }
            }

            if (rightPointer > left)
            {
                QuickSort(arr, left, rightPointer);
            }

            if (leftPointer < right)
            {
                QuickSort(arr, leftPointer, right);
            }
        }

        private static void CheckArrParameter(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException();
            }

            if (arr.Length == 0)
            {
                throw new ArgumentException();
            }
        }
    }
}
