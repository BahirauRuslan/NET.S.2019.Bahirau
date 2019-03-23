using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace NumberExtensions.Tests
{
    public class RootFinderTests
    {
        private RootFinder rootFinder = new RootFinder();

        [TestCase(0.0, 54, 0.00001, 0.0000)]
        [TestCase(848.0, 1, 0.00001, 848.0000)]
        [TestCase(4.0, 2, 0.001, 2.00)]
        [TestCase(8.0, 3, 0.001, 2.00)]
        [TestCase(-8.0, 3, 0.001, -2.00)]
        [TestCase(0.008, 3, 0.0001, 0.200)]
        public void FindNthRoot_ValidParameters_Result(double a, int n, double accuracy, double expected)
        {
            double actual = rootFinder.FindNthRoot(a, n, accuracy);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 0.0001)]
        [TestCase(3, -0.0001)]
        [TestCase(-3, -0.0001)]
        public void FindNthRoot_InvalidNandAccuracy_ArgumentException(int n, double accuracy)
        {
            Assert.Throws<ArgumentException>(() => rootFinder.FindNthRoot(2, n, accuracy));
        }

        [Test]
        public void FindNthRoot_EvenNwithNugativeA_ArgumentException()
        {
            Assert.Throws<ArithmeticException>(() => rootFinder.FindNthRoot(-64, 6, 0.0001));
        }
    }
}
