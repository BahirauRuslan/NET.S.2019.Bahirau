using System;
using NUnit.Framework;

namespace SortAlgo.Tests
{
    public class ArrayExtensionTests
    {
        [TestCase(new int[] { 5, 7, 2, -12, 5, 6, 2, 5, 8 },
            new int[] { -12, 2, 2, 5, 5, 5, 6, 7, 8 })]
        [TestCase(new int[] { 2, 1 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 21 }, new int[] { 21 })]
        public void MergeSortNormalTest(int[] arr, int[] expected)
        {
            int[] actual = ArrayExtension.MergeSort(arr);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MergeSortEmptyArrayExpectedArgumentExceptionTest()
        {
            int[] emptyArray = new int[0];

            Assert.Throws<ArgumentException>(() => ArrayExtension.MergeSort(emptyArray));
        }

        [Test]
        public void MergeSortNullExpectedArgumentNullExceptionTest()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.MergeSort(null));
        }

        [TestCase(new int[] { 1, 7, 8, -3, -5, 6, 45, 19, 2, 0 },
            new int[] { -5, -3, 0, 1, 2, 6, 7, 8, 19, 45 })]
        [TestCase(new int[] { 15, -12 }, new int[] { -12, 15 })]
        [TestCase(new int[] { 3 }, new int[] { 3 })]
        public void QuickSortNormalTest(int[] arr, int[] expected)
        {
            ArrayExtension.QuickSort(arr);
            int[] actual = arr;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void QuickSortEmptyArrayExpectedArgumentExceptionTest()
        {
            int[] emptyArray = new int[0];

            Assert.Throws<ArgumentException>(() => ArrayExtension.QuickSort(emptyArray));
        }

        [Test]
        public void QuickSortNullExpectedArgumentNullExceptionTest()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.QuickSort(null));
        }
    }
}
