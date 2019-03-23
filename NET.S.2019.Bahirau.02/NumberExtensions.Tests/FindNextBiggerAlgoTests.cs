using System;
using NUnit.Framework;

namespace NumberExtensions.Tests
{
    public class FindNextBiggerAlgoTests
    {
        private FindNextBiggerAlgo algo = new FindNextBiggerAlgo();

        [TestCase(12, 21)]
        [TestCase(513, 531)]
        [TestCase(2017, 2071)]
        [TestCase(414, 441)]
        [TestCase(144, 414)]
        [TestCase(1234321, 1241233)]
        [TestCase(1234126, 1234162)]
        [TestCase(3456432, 3462345)]
        [TestCase(10, -1)]
        [TestCase(20, -1)]
        public void FindNextBiggerNumber_ValidNumber_IntResult(int number, int expected)
        {
            int actual = algo.FindNextBiggerNumber(number);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindNextBiggerNumber_Zero_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => algo.FindNextBiggerNumber(0));
        }

        [Test]
        public void FindNextBiggerNumber_NegativeNumber_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => algo.FindNextBiggerNumber(-12));
        }

        [TestCase(12, 21)]
        [TestCase(513, 531)]
        [TestCase(2017, 2071)]
        [TestCase(414, 441)]
        [TestCase(144, 414)]
        [TestCase(1234321, 1241233)]
        [TestCase(1234126, 1234162)]
        [TestCase(3456432, 3462345)]
        [TestCase(10, -1)]
        [TestCase(20, -1)]
        public void FindNextBiggerNumberAndTime_ValidNumber_TimeMoreThanZero(int number, int expected)
        {
            var actual = algo.FindNextBiggerNumberAndTime(number).Item2;

            Assert.Positive(actual);
        }

        [Test]
        public void FindNextBiggerNumberAndTime_Zero_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => algo.FindNextBiggerNumberAndTime(0));
        }

        [Test]
        public void FindNextBiggerNumberAndTime_NegativeNumber_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => algo.FindNextBiggerNumberAndTime(-12));
        }
    }
}