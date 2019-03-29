using System;
using NUnit.Framework;

namespace Day4Tasks.Tests
{
    public class PolynomialTests
    {
        #region Test operator +

        [TestCase(
            new double[] { 2.0, 3.0, 4.0 }, 
            new double[] { 2.3, 3.4, 4.5, 5.6 }, 
            new double[] { 4.3, 6.4, 8.5, 5.6 })]
        [TestCase(
            new double[] { 2.3, 3.4, 4.5, 5.6 },
            new double[] { 2.0, 3.0, 4.0 },
            new double[] { 4.3, 6.4, 8.5, 5.6 })]
        [TestCase(new double[] { -2.3 }, new double[] { 2.3 }, new double[] { 0.0 })]
        public void TestPlus_TwoPolynomials_Polynomial(
            double[] leftArgCoefficients, double[] rightArgCoefficients, double[] expectedCoefficients)
        {
            var leftArg = new Polynomial(leftArgCoefficients);
            var rightArg = new Polynomial(rightArgCoefficients);
            var expected = new Polynomial(expectedCoefficients);

            var actual = leftArg + rightArg;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(
            new double[] { 2.0, 3.0, 4.0 },
            12.3,
            new double[] { 14.3, 3.0, 4.0 })]
        [TestCase(new double[] { 23.15 }, 6.85, new double[] { 30 })]
        public void TestPlus_PolynomialAndConstant_Polynomial(
            double[] leftArgCoefficients, double constant, double[] expectedCoefficients)
        {
            var leftArg = new Polynomial(leftArgCoefficients);
            var expected = new Polynomial(expectedCoefficients);

            var actual = leftArg + constant;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(
            12.3,
            new double[] { 2.0, 3.0, 4.0 },
            new double[] { 14.3, 3.0, 4.0 })]
        [TestCase(6.85, new double[] { 23.15 }, new double[] { 30 })]
        public void TestPlus_ConstantAndPolynomial_Polynomial(
            double constant, double[] rightArgCoefficients, double[] expectedCoefficients)
        {
            var rightArg = new Polynomial(rightArgCoefficients);
            var expected = new Polynomial(expectedCoefficients);

            var actual = constant + rightArg;

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Test binary operator -

        [TestCase(
            new double[] { 5.0, 4.0, 6.0 },
            new double[] { 2.0, 3.0, 4.0, 5.0 },
            new double[] { 3.0, 1.0, 2.0, -5.0 })]
        [TestCase(
            new double[] { 8.0, 8.5, 4.5, 5.5 },
            new double[] { 2.0, 3.0, 4.0 },
            new double[] { 6.0, 5.5, 0.5, 5.5 })]
        [TestCase(new double[] { -2.3 }, new double[] { 2.3 }, new double[] { -4.6 })]
        public void TestMinus_TwoPolynomials_Polynomial(
            double[] leftArgCoefficients, double[] rightArgCoefficients, double[] expectedCoefficients)
        {
            var leftArg = new Polynomial(leftArgCoefficients);
            var rightArg = new Polynomial(rightArgCoefficients);
            var expected = new Polynomial(expectedCoefficients);

            var actual = leftArg - rightArg;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(
            new double[] { 2.0, 3.0, 4.0 },
            12.3,
            new double[] { -10.3, 3.0, 4.0 })]
        [TestCase(new double[] { 23.15 }, -6.85, new double[] { 30 })]
        public void TestMinus_PolynomialAndConstant_Polynomial(
            double[] leftArgCoefficients, double constant, double[] expectedCoefficients)
        {
            var leftArg = new Polynomial(leftArgCoefficients);
            var expected = new Polynomial(expectedCoefficients);

            var actual = leftArg - constant;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(
            12.3,
            new double[] { -2.0, -3.0, -4.0 },
            new double[] { 14.3, 3.0, 4.0 })]
        [TestCase(6.85, new double[] { -23.15 }, new double[] { 30 })]
        public void TestMinus_ConstantAndPolynomial_Polynomial(
            double constant, double[] rightArgCoefficients, double[] expectedCoefficients)
        {
            var rightArg = new Polynomial(rightArgCoefficients);
            var expected = new Polynomial(expectedCoefficients);

            var actual = constant - rightArg;

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Test unary operator -

        [TestCase(
            new double[] { 2.3, 4.5, 2.1, 0.0, 12 }, 
            new double[] { -2.3, -4.5, -2.1, 0.0, -12 })]
        [TestCase(new double[] { -23.15 }, new double[] { 23.15 })]
        public void TestUnaryMinus_Polynimial_MinusPolynomial(
            double[] polynomialCoefficients, double[] expectedCoefficients)
        {
            var polynomial = new Polynomial(polynomialCoefficients);
            var expected = new Polynomial(expectedCoefficients);

            var actual = -polynomial;

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Test operator *

        [TestCase(new double[] { 2.0, 1.0 }, new double[] { 2.0, 1.0 }, new double[] { 4.0, 4.0, 1.0 })]
        [TestCase(new double[] { 4.0 }, new double[] { -5.0 }, new double[] { -20 })]
        [TestCase(new double[] { 0.0 }, new double[] { -5.0 }, new double[] { 0.0 })]
        public void TestMul_TwoPolynomial_Polynomial(
            double[] leftArgCoefficients, double[] rightArgCoefficients, double[] expectedCoefficients)
        {
            var leftArg = new Polynomial(leftArgCoefficients);
            var rightArg = new Polynomial(rightArgCoefficients);
            var expected = new Polynomial(expectedCoefficients);

            var actual = leftArg * rightArg;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new double[] { 2.5, 0.0, 12.3, 0.5 }, 2.0, new double[] { 5.0, 0.0, 24.6, 1.0 })]
        [TestCase(new double[] { 2.5 }, 2.0, new double[] { 5.0 })]
        [TestCase(new double[] { 2.5 }, 0.0, new double[] { 0.0 })]
        [TestCase(new double[] { 0.0 }, 2.5, new double[] { 0.0 })]
        public void TestMul_PolynomialAndConstant_Polynomial(
            double[] polynomialCoefficients, double constant, double[] expectedCoefficients)
        {
            var polynomial = new Polynomial(polynomialCoefficients);
            var expected = new Polynomial(expectedCoefficients);

            var actual = polynomial * constant;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2.0, new double[] { 2.5, 0.0, 12.3, 0.5 }, new double[] { 5.0, 0.0, 24.6, 1.0 })]
        [TestCase(2.0, new double[] { 2.5 }, new double[] { 5.0 })]
        [TestCase(0.0, new double[] { 2.5 }, new double[] { 0.0 })]
        [TestCase(2.5, new double[] { 0.0 }, new double[] { 0.0 })]
        public void TestMul_ConstantAndPolynomial_Polynomial(
            double constant, double[] polynomialCoefficients, double[] expectedCoefficients)
        {
            var polynomial = new Polynomial(polynomialCoefficients);
            var expected = new Polynomial(expectedCoefficients);

            var actual = constant * polynomial;

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Constructor negative tests

        [Test]
        public void TestCreate_Null_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Polynomial(null));
        }

        [Test]
        public void TestCreate_EmptyArray_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Polynomial(new double[0]));
        }

        [Test]
        public void TestCreate_NoParameters_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Polynomial());
        }

        #endregion
    }
}