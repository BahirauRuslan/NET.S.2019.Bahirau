using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace NumberExtensions.Tests
{
    public class DigitFilterTests
    {
        private DigitFilter filter = new DigitFilter();

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 7, new int[] { 7, 70, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 68, 69, -70, 15, -17 }, 7, new int[] { 7, -70, -17 })]
        [TestCase(new int[] { 12, 32, 84 }, 2, new int[] { 12, 32 })]
        [TestCase(new int[] { 10, 0, 54 }, 0, new int[] { 10, 0 })]
        [TestCase(new int[] { 94, 81 }, 3, new int[0])]
        [TestCase(new int[0], 3, new int[0])]
        public void FilterDigit_ArrayOfIntegers_IntegersOrEmpty(int[] numbers, 
            int digit, int[] expected)
        {
            IEnumerable<int> actual = filter.FilterDigit(numbers, digit);

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestCase(-1)]
        [TestCase(10)]
        public void FilterDigit_NotDigitParameter_ArgumentException(int notDigit)
        {
            Assert.Throws<ArgumentException>(() => filter.FilterDigit(new int[] { 22, 10 }, notDigit));
        }

        [Test]
        public void FilterDigit_NullParameter_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => filter.FilterDigit(null, 5));
        }
    }
}
