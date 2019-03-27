using System;
using NUnit.Framework;

namespace Day3Tasks.Tests
{
    public class EuclidAlgoTests
    {
        #region GetGCDTests

        [TestCase(2, 6, 4)]
        [TestCase(3, 6, 9, 3)]
        [TestCase(3, 6, -9, 3)]
        [TestCase(83, 83, 0, 83)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)]
        public void GetGCD_ValidNumbers_GCD(int expected, params int[] nums)
        {
            int actual = EuclidAlgorithm.GetGCD(nums);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetGCD_Zeroes_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => EuclidAlgorithm.GetGCD(0, 0, 0, 0, 0, 0));
        }

        [Test]
        public void GetGCD_OneParameter_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => EuclidAlgorithm.GetGCD(28));
        }

        [Test]
        public void GetGCD_Nothing_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => EuclidAlgorithm.GetGCD());
        }

        [Test]
        public void GetGCD_Null_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => EuclidAlgorithm.GetGCD(null));
        }

        #endregion

        #region GetGCDAndTimeTests

        [TestCase(2, 6, 4)]
        [TestCase(3, 6, 9, 3)]
        [TestCase(3, 6, -9, 3)]
        [TestCase(83, 83, 0, 83)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)]
        public void GetGCDAndTime_ValidNumbers_PositiveTime(int expected, params int[] nums)
        {
            EuclidAlgorithm.GetGCDAndTime(out double time, nums);

            Assert.Positive(time);
        }

        [Test]
        public void GetGCDAndTime_Zeroes_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => EuclidAlgorithm.GetGCDAndTime(out double time, 0, 0, 0, 0, 0, 0));
        }

        [Test]
        public void GetGCDAndTime_OneParameter_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => EuclidAlgorithm.GetGCDAndTime(out double time, 28));
        }

        [Test]
        public void GetGCDAndTime_Nothing_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => EuclidAlgorithm.GetGCDAndTime(out double time));
        }

        [Test]
        public void GetGCDAndTime_Null_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => EuclidAlgorithm.GetGCDAndTime(out double time, null));
        }

        #endregion
    }
}