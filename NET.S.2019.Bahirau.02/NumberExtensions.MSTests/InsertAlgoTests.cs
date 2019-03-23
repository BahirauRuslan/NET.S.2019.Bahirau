using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberExtensions.MSTests
{
    [TestClass]
    public class InsertAlgoTests
    {
        private InsertAlgo insertAlgo = new InsertAlgo();

        [DataTestMethod]
        [DataRow(0b00000000000000000000000000001111,
                  0b00000000000000000000000000001111,
                  0b00000000000000000000000000001111, 0, 0)]
        [DataRow(0b00000000000000000000000000001000,
                  0b00000000000000000000000000001111,
                  0b00000000000000000000000000001001, 0, 0)]
        [DataRow(0b00000000000000000000000000001000,
                  0b00000000000000000000000000001111,
                  0b00000000000000000000000001111000, 3, 8)]
        public void InsertNumber_ValidParameters_Integer(int firstNumber, int secondNumber,
            int expected, int i, int j)
        {
            int actual = insertAlgo.InsertNumber(firstNumber, secondNumber, i, j);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(21, 15)]
        [DataRow(-2, 15)]
        [DataRow(32, 15)]
        [DataRow(13, -1)]
        [DataRow(13, 33)]
        public void InsertNumber_InvalidPositions_ArgumentException(int i, int j)
        {
            Assert.ThrowsException<ArgumentException>(() => insertAlgo.InsertNumber(2, 3, i, j));
        }
    }
}
