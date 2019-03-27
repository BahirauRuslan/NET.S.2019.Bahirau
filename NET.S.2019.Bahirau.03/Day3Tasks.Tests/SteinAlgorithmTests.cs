using System;
using NUnit.Framework;

namespace Day3Tasks.Tests
{
    public class SteinAlgorithmTests
    {
        private EuclidAlgorithm algo = new EuclidAlgorithm();

        #region GetGCDSteinTests

        [TestCase(2, 6, 4)]
        [TestCase(3, 6, 9, 3)]
        [TestCase(3, 6, -9, 3)]
        [TestCase(83, 83, 0, 83)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)]
        public void GetGCDStein_ValidNumbers_GCD(int expected, params int[] nums)
        {
            int actual = algo.GetGCDStein(nums);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetGCDStein_Zeroes_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => algo.GetGCDStein(0, 0, 0, 0, 0, 0));
        }

        [Test]
        public void GetGCDStein_OneParameter_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => algo.GetGCDStein(28));
        }

        [Test]
        public void GetGCDStein_Nothing_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => algo.GetGCDStein());
        }

        [Test]
        public void GetGCDStein_Null_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => algo.GetGCDStein(null));
        }

        #endregion

        #region GetGCDSteinAndTimeTests

        [TestCase(2, 6, 4)]
        [TestCase(3, 6, 9, 3)]
        [TestCase(3, 6, -9, 3)]
        [TestCase(83, 83, 0, 83)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)]
        public void GetGCDSteinAndTime_ValidNumbers_PositiveTime(int expected, params int[] nums)
        {
            algo.GetGCDSteinAndTime(out double time, nums);

            Assert.Positive(time);
        }

        [Test]
        public void GetGCDSteinAndTime_Zeroes_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => algo.GetGCDSteinAndTime(out double time, 0, 0, 0, 0, 0, 0));
        }

        [Test]
        public void GetGCDSteinAndTime_OneParameter_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => algo.GetGCDSteinAndTime(out double time, 28));
        }

        [Test]
        public void GetGCDSteinAndTime_Nothing_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => algo.GetGCDSteinAndTime(out double time));
        }

        [Test]
        public void GetGCDSteinAndTime_Null_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => algo.GetGCDSteinAndTime(out double time, null));
        }

        #endregion
    }
}
