using System;
using System.Linq;

namespace Day4Tasks
{
    public static class BubbleAlgorithm
    {
        public static void BubbleSortBySum(int[][] jaggedArr, bool desc = false)
        {
            int parameter(int[] arr) => (from num in arr select num).Sum();
            BubbleSort(jaggedArr, parameter, desc);
        }

        public static void BubbleSortByMax(int[][] jaggedArr, bool desc = false)
        {
            int parameter(int[] arr) => (from num in arr orderby num select num).Last();
            BubbleSort(jaggedArr, parameter, desc);
        }

        public static void BubbleSortByMin(int[][] jaggedArr, bool desc = false)
        {
            int parameter(int[] arr) => (from num in arr orderby num select num).First();
            BubbleSort(jaggedArr, parameter, desc);
        }

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

        private static void Swap(ref int[] arr1, ref int[] arr2)
        {
            var temp = arr1;
            arr1 = arr2;
            arr2 = temp;
        }

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
