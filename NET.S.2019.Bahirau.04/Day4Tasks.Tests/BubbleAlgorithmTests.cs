using System;
using NUnit.Framework;

namespace Day4Tasks.Tests
{
    [TestFixture]
    public class BubbleAlgorithmTests
    {
        #region BubbleSortBySum tests

        [Test]
        public void TestBubbleSortBySum_JaggedArray_SortedArray()
        {
            var jaggedArray = new int[][]
            {
                new int[] { 1, 2, 3, 4, 5, 6, 7 },
                new int[] { 1, 2, 3, 4 },
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 1, 2 }
            };
            var expected = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 1, 2, 3, 4 },
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 1, 2, 3, 4, 5, 6, 7 }
            };

            BubbleAlgorithm.BubbleSortBySum(jaggedArray);

            Assert.AreEqual(expected, jaggedArray);
        }

        [Test]
        public void TestBubbleSortBySum_JaggedArrayDesc_SortedArray()
        {
            var jaggedArray = new int[][]
            {
                new int[] { 1, 2, 3, 4, 5, 6, 7 },
                new int[] { 1, 2, 3, 4 },
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 1, 2 }
            };
            var expected = new int[][]
            {
                new int[] { 1, 2, 3, 4, 5, 6, 7 },
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 1, 2, 3, 4 },
                new int[] { 1, 2 },
            };

            BubbleAlgorithm.BubbleSortBySum(jaggedArray, true);

            Assert.AreEqual(expected, jaggedArray);
        }

        [Test]
        public void TestBubbleSortBySum_SortedJaggedArray_SortedArray()
        {
            var jaggedArray = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 1, 2, 3, 4 },
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 1, 2, 3, 4, 5, 6, 7 }
            };
            var expected = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 1, 2, 3, 4 },
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 1, 2, 3, 4, 5, 6, 7 }
            };

            BubbleAlgorithm.BubbleSortBySum(jaggedArray);

            Assert.AreEqual(expected, jaggedArray);
        }

        #endregion

        #region BubbleSortByMax tests

        [Test]
        public void TestBubbleSortByMax_JaggedArray_SortedArray()
        {
            var jaggedArray = new int[][]
            {
                new int[] { 1, 2, 3, 4, 5, 6, 7 },
                new int[] { 1, 2, 3, 4 },
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 1, 2 }
            };
            var expected = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 1, 2, 3, 4 },
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 1, 2, 3, 4, 5, 6, 7 }
            };

            BubbleAlgorithm.BubbleSortByMax(jaggedArray);

            Assert.AreEqual(expected, jaggedArray);
        }

        [Test]
        public void TestBubbleSortByMax_JaggedArrayDesc_SortedArray()
        {
            var jaggedArray = new int[][]
            {
                new int[] { 1, 2, 3, 4, 5, 6, 7 },
                new int[] { 1, 2, 3, 4 },
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 1, 2 }
            };
            var expected = new int[][]
            {
                new int[] { 1, 2, 3, 4, 5, 6, 7 },
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 1, 2, 3, 4 },
                new int[] { 1, 2 },
            };

            BubbleAlgorithm.BubbleSortByMax(jaggedArray, true);

            Assert.AreEqual(expected, jaggedArray);
        }

        [Test]
        public void TestBubbleSortByMax_SortedJaggedArray_SortedArray()
        {
            var jaggedArray = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 1, 2, 3, 4 },
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 1, 2, 3, 4, 5, 6, 7 }
            };
            var expected = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 1, 2, 3, 4 },
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 1, 2, 3, 4, 5, 6, 7 }
            };

            BubbleAlgorithm.BubbleSortByMax(jaggedArray);

            Assert.AreEqual(expected, jaggedArray);
        }

        #endregion

        #region BubbleSortByMin tests

        [Test]
        public void TestBubbleSortByMin_JaggedArray_SortedArray()
        {
            var jaggedArray = new int[][]
            {
                new int[] { 4, 5, 6, 7 },
                new int[] { 2, 3, 4 },
                new int[] { 3, 4, 5 },
                new int[] { 1, 2 }
            };
            var expected = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 2, 3, 4 },
                new int[] { 3, 4, 5 },
                new int[] { 4, 5, 6, 7 }
            };

            BubbleAlgorithm.BubbleSortByMin(jaggedArray);

            Assert.AreEqual(expected, jaggedArray);
        }

        [Test]
        public void TestBubbleSortByMin_JaggedArrayDesc_SortedArray()
        {
            var jaggedArray = new int[][]
            {
                new int[] { 4, 5, 6, 7 },
                new int[] { 2, 3, 4 },
                new int[] { 3, 4, 5 },
                new int[] { 1, 2 }
            };
            var expected = new int[][]
            {
                new int[] { 4, 5, 6, 7 },
                new int[] { 3, 4, 5 },
                new int[] { 2, 3, 4 },
                new int[] { 1, 2 }
            };

            BubbleAlgorithm.BubbleSortByMin(jaggedArray, true);

            Assert.AreEqual(expected, jaggedArray);
        }

        [Test]
        public void TestBubbleSortByMin_SortedJaggedArray_SortedArray()
        {
            var jaggedArray = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 2, 3, 4 },
                new int[] { 3, 4, 5 },
                new int[] { 4, 5, 6, 7 }
            };
            var expected = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 2, 3, 4 },
                new int[] { 3, 4, 5 },
                new int[] { 4, 5, 6, 7 }
            };

            BubbleAlgorithm.BubbleSortByMin(jaggedArray);

            Assert.AreEqual(expected, jaggedArray);
        }

        #endregion

        #region BubbleSort tests

        [Test]
        public void TestBubbleSort_JaggedArrayByFirstItem_SortedArray()
        {
            var jaggedArray = new int[][]
            {
                new int[] { 4, 1, 4, 3 },
                new int[] { 1 },
                new int[] { 3, 1, 2 },
                new int[] { 2, 5, 2, 2, 1 }
            };
            var expected = new int[][]
            {
                new int[] { 1 },
                new int[] { 2, 5, 2, 2, 1 },
                new int[] { 3, 1, 2 },
                new int[] { 4, 1, 4, 3 }
            };
            int parameter(int[] arr) => arr[0];

            BubbleAlgorithm.BubbleSort(jaggedArray, parameter);

            Assert.AreEqual(expected, jaggedArray);
        }

        [Test]
        public void TestBubbleSort_JaggedArrayByFirstItemDesc_SortedArray()
        {
            var jaggedArray = new int[][]
            {
                new int[] { 1 },
                new int[] { 2, 5, 2, 2, 1 },
                new int[] { 3, 1, 2 },
                new int[] { 4, 1, 4, 3 }
            };
            var expected = new int[][]
            {
                new int[] { 4, 1, 4, 3 },
                new int[] { 3, 1, 2 },
                new int[] { 2, 5, 2, 2, 1 },
                new int[] { 1 },
            };
            int parameter(int[] arr) => arr[0];

            BubbleAlgorithm.BubbleSort(jaggedArray, parameter, true);

            Assert.AreEqual(expected, jaggedArray);
        }

        [Test]
        public void TestBubbleSort_JaggedArrayWithEmptyItemByFirstItemDesc_ArgumentException()
        {
            var jaggedArray = new int[][]
            {
                new int[] { 1 },
                new int[] { 2, 5, 2, 2, 1 },
                new int[0],
                new int[] { 4, 1, 4, 3 }
            };
            int parameter(int[] arr) => arr[0];

            Assert.Throws<ArgumentException>(() => BubbleAlgorithm.BubbleSort(jaggedArray, parameter));
        }

        [Test]
        public void TestBubbleSort_EmptyJaggedArrayFirstItemDesc_ArgumentException()
        {
            var jaggedArray = new int[0][];
            int parameter(int[] arr) => arr[0];

            Assert.Throws<ArgumentException>(() => BubbleAlgorithm.BubbleSort(jaggedArray, parameter));
        }

        [Test]
        public void TestBubbleSort_JaggedArrayWithNullByFirstItemDesc_ArgumentNullException()
        {
            var jaggedArray = new int[][]
            {
                new int[] { 1 },
                new int[] { 2, 5, 2, 2, 1 },
                null,
                new int[] { 4, 1, 4, 3 }
            };
            int parameter(int[] arr) => arr[0];

            Assert.Throws<ArgumentNullException>(() => BubbleAlgorithm.BubbleSort(jaggedArray, parameter));
        }

        [Test]
        public void TestBubbleSort_NullByFirstItemDesc_ArgumentNullException()
        {
            int parameter(int[] arr) => arr[0];

            Assert.Throws<ArgumentNullException>(() => BubbleAlgorithm.BubbleSort(null, parameter));
        }

        [Test]
        public void TestBubbleSort_JaggedArrayByNull_ArgumentNullException()
        {
            var jaggedArray = new int[][]
            {
                new int[] { 1 },
                new int[] { 2, 5, 2, 2, 1 },
                new int[] { 3, 1, 2 },
                new int[] { 4, 1, 4, 3 }
            };

            Assert.Throws<ArgumentNullException>(() => BubbleAlgorithm.BubbleSort(jaggedArray, null));
        }

        [Test]
        public void TestBubbleSort_NullByNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => BubbleAlgorithm.BubbleSort(null, null));
        }

        #endregion
    }
}
