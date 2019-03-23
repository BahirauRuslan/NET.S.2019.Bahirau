using System;
using NUnit.Framework;

namespace NumberExtensions.Tests
{
    public class InsertAlgoTests
    {
        private InsertAlgo insertAlgo = new InsertAlgo();

        [TestCase(0b00000000000000000000000000001111, 
                  0b00000000000000000000000000001111,
                  0b00000000000000000000000000001111, 0, 0)]
        [TestCase(0b00000000000000000000000000001000,
                  0b00000000000000000000000000001111,
                  0b00000000000000000000000000001001, 0, 0)]
        [TestCase(0b00000000000000000000000000001000,
                  0b00000000000000000000000000001111,
                  0b00000000000000000000000001111000, 3, 8)]
        public void InsertNumber_ValidParameters_Integer(int firstNumber, int secondNumber, 
            int expected, int i, int j)
        {
            int actual = insertAlgo.InsertNumber(firstNumber, secondNumber, i, j);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(21, 15)]
        [TestCase(-2, 15)]
        [TestCase(32, 15)]
        [TestCase(13, -1)]
        [TestCase(13, 33)]
        public void InsertNumber_InvalidPositions_ArgumentException(int i, int j)
        {
            Assert.Throws<ArgumentException>(() => insertAlgo.InsertNumber(2, 3, i, j));
        }
    }
}
