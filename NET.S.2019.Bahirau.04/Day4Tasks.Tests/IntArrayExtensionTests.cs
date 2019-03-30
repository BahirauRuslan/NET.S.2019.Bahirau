using System;
using System.Linq;
using NUnit.Framework;

namespace Day4Tasks.Tests
{
    [TestFixture]
    public class IntArrayExtensionTests
    {
        [TestCase(new int[] { 5, 4, 6, 7, 3, 2, 1 }, new int[] { 5, 4, 6, 7, 3, 2, 1 }, 0)]
        [TestCase(new int[] { 5, 4, 6, 7, 3, 2, 1 }, new int[] { 55, 44, 66, 77, 33, 22, 11 }, -1)]
        [TestCase(new int[] { 555, 423, 6336, 7645, 3, 23425, 1, -1 }, new int[] { 552, 4234, 5266, 771 }, 1)]
        public void TestExtensionCompareTo_TwoArraysAndSumOfItems_Result(int[] arr1, int[] arr2, int expected)
        {
            int parameter(int[] arr) => (from num in arr select num).Sum();

            var actual = arr1.ExtensionCompareTo(arr2, parameter);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 2, 5, 4 }, new int[0])]
        [TestCase(new int[0], new int[] { 6, 4, 5, 2, 4 })]
        public void TestExtensionCompareTo_ArrayAndEmptyArrayAndSumOfItems_ArgumentException(int[] arr1, int[] arr2)
        {
            int parameter(int[] arr) => (from num in arr select num).Sum();

            Assert.Throws<ArgumentException>(() => arr1.ExtensionCompareTo(arr2, parameter));
        }

        [Test]
        public void TestExtensionCompareTo_ArrayAndNullAndSumOfItems_ArgumentNullException()
        {
            int parameter(int[] arr) => (from num in arr select num).Sum();

            Assert.Throws<ArgumentNullException>(() => new int[] { 1, 2 }.ExtensionCompareTo(null, parameter));
        }

        [Test]
        public void TestExtensionCompareTo_TwoArraysAndNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => new int[] { 1, 2 }.ExtensionCompareTo(new int[] { 3, 2, 5 }, null));
        }

        [Test]
        public void TestExtensionCompareTo_ArrayAndNullAndNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new int[] { 1, 2 }.ExtensionCompareTo(null, null));
        }
    }
}
