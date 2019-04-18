using System;
using NUnit.Framework;

namespace BinaryAlgorithms.Tests
{
    [TestFixture]
    public class BinaryAlgorithmsTests
    {
        private readonly BinaryAlgorithm algorithm = new BinaryAlgorithm();

        [TestCase(new string[] { "1", "2", "3", "4", "5", "6" }, "2", 1)]
        [TestCase(new string[] { "1", "2", "3", "4", "5", "6" }, "6", 5)]
        [TestCase(new string[] { "1", "2", "3", "4", "5", "6" }, "1", 0)]
        [TestCase(new string[] { "1", "2", "3", "4", "5", "6" }, "9", -1)]
        [TestCase(new string[] { "1", "2", "3", "4", "5", "6" }, "0", -1)]
        [TestCase(new string[] { "8", "2", "6", "7", "8", "5" }, "5", -1)]
        [TestCase(new string[] { "1", "1", "6", "7", "9", "9" }, "0", -1)]
        public void TestSearch_SortedArrayKeyComparer_Index(string[] array, string key, int expected)
        {
            var actual = algorithm.Search(array, key, StringComparer.Ordinal);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestSearch_NullArrayKeyComparer_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => algorithm.Search(null, "5", StringComparer.Ordinal));
        }

        [Test]
        public void TestSearch_NormalArrayKeyComparerNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => algorithm.Search(new string[] { "5" }, "5", null));
        }
    }
}