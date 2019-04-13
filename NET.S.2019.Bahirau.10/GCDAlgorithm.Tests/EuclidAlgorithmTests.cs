using System;
using NUnit.Framework;

namespace GCDAlgorithm.Tests
{
    public class EuclidAlgorithmTests
    {
        private EuclidAlgorithm _algorithm;

        [SetUp]
        public void Setup()
        {
            _algorithm = new EuclidAlgorithm();
        }

        #region Euclidean algorithm tests

        [TestCase(2, 6, 4)]
        [TestCase(3, 6, 9, 3)]
        [TestCase(3, 6, -9, 3)]
        [TestCase(83, 83, 0, 83)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)]
        public void GetGCD_ValidNumbers_GCD(int expected, params int[] nums)
        {
            var actual = _algorithm.GetGCD(nums);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetGCD_Zeroes_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _algorithm.GetGCD(0, 0, 0, 0, 0, 0));
        }

        [Test]
        public void GetGCD_OneParameter_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _algorithm.GetGCD(28));
        }

        [Test]
        public void GetGCD_Nothing_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _algorithm.GetGCD());
        }

        [Test]
        public void GetGCD_Null_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _algorithm.GetGCD(null));
        }

        #endregion

        #region Euclidean algorithm and time tests

        [TestCase(2, 6, 4)]
        [TestCase(3, 6, 9, 3)]
        [TestCase(3, 6, -9, 3)]
        [TestCase(83, 83, 0, 83)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)]
        public void GetGCDAndTime_ValidNumbers_PositiveTime(int expected, params int[] nums)
        {
            _algorithm.GetGCDAndTime(out double time, nums);

            Assert.Positive(time);
        }

        [Test]
        public void GetGCDAndTime_Zeroes_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _algorithm.GetGCDAndTime(out double time, 0, 0, 0, 0, 0, 0));
        }

        [Test]
        public void GetGCDAndTime_OneParameter_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _algorithm.GetGCDAndTime(out double time, 28));
        }

        [Test]
        public void GetGCDAndTime_Nothing_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _algorithm.GetGCDAndTime(out double time));
        }

        [Test]
        public void GetGCDAndTime_Null_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _algorithm.GetGCDAndTime(out double time, null));
        }

        #endregion

        #region Stein algorithm tests

        [TestCase(2, 6, 4)]
        [TestCase(3, 6, 9, 3)]
        [TestCase(3, 6, -9, 3)]
        [TestCase(83, 83, 0, 83)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)]
        public void GetGCDStein_ValidNumbers_GCD(int expected, params int[] nums)
        {
            _algorithm.UseSteinAlgorithm();

            var actual = _algorithm.GetGCD(nums);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetGCDStein_Zeroes_ArgumentException()
        {
            _algorithm.UseSteinAlgorithm();

            Assert.Throws<ArgumentException>(() => _algorithm.GetGCD(0, 0, 0, 0, 0, 0));
        }

        [Test]
        public void GetGCDStein_OneParameter_ArgumentException()
        {
            _algorithm.UseSteinAlgorithm();

            Assert.Throws<ArgumentException>(() => _algorithm.GetGCD(28));
        }

        [Test]
        public void GetGCDStein_Nothing_ArgumentException()
        {
            _algorithm.UseSteinAlgorithm();

            Assert.Throws<ArgumentException>(() => _algorithm.GetGCD());
        }

        [Test]
        public void GetGCDStein_Null_ArgumentNullException()
        {
            _algorithm.UseSteinAlgorithm();

            Assert.Throws<ArgumentNullException>(() => _algorithm.GetGCD(null));
        }

        #endregion

        #region Stein algorithm and time tests

        [TestCase(2, 6, 4)]
        [TestCase(3, 6, 9, 3)]
        [TestCase(3, 6, -9, 3)]
        [TestCase(83, 83, 0, 83)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)]
        public void GetGCDSteinAndTime_ValidNumbers_PositiveTime(int expected, params int[] nums)
        {
            _algorithm.UseSteinAlgorithm();

            _algorithm.GetGCDAndTime(out double time, nums);

            Assert.Positive(time);
        }

        [Test]
        public void GetGCDSteinAndTime_Zeroes_ArgumentException()
        {
            _algorithm.UseSteinAlgorithm();

            Assert.Throws<ArgumentException>(() => _algorithm.GetGCDAndTime(out double time, 0, 0, 0, 0, 0, 0));
        }

        [Test]
        public void GetGCDSteinAndTime_OneParameter_ArgumentException()
        {
            _algorithm.UseSteinAlgorithm();

            Assert.Throws<ArgumentException>(() => _algorithm.GetGCDAndTime(out double time, 28));
        }

        [Test]
        public void GetGCDSteinAndTime_Nothing_ArgumentException()
        {
            _algorithm.UseSteinAlgorithm();

            Assert.Throws<ArgumentException>(() => _algorithm.GetGCDAndTime(out double time));
        }

        [Test]
        public void GetGCDSteinAndTime_Null_ArgumentNullException()
        {
            _algorithm.UseSteinAlgorithm();

            Assert.Throws<ArgumentNullException>(() => _algorithm.GetGCDAndTime(out double time, null));
        }

        #endregion
    }
}