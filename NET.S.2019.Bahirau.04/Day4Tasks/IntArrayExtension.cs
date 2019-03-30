using System;

namespace Day4Tasks
{
    public static class IntArrayExtension
    {
        public delegate int Parameter(int[] arr);

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
