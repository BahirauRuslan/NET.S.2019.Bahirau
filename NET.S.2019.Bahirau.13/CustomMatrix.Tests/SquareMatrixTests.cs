using System;
using NUnit.Framework;

namespace CustomMatrix.Tests
{
    public class SquareMatrixTests
    {
        #region Constructor tests

        [Test]
        public void TestConstructSquareMatrix_EmptyConstructor_Pass()
        {
            new SquareMatrix<int>();

            Assert.Pass();
        }

        [Test]
        public void TestConstructSquareMatrix_ItemsTableConstructor_Pass()
        {
            new SquareMatrix<int>(new int[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 3, 4, 5, 7 },
                { 8, 4, 2, 3 }
            });

            Assert.Pass();
        }

        [Test]
        public void TestConstructSquareMatrix_MatrixConstructor_Pass()
        {
            var matrix = new SquareMatrix<int>(new int[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 3, 4, 5, 7 },
                { 8, 4, 2, 3 }
            });

            new StaticMatrix<int>(matrix);

            Assert.Pass();
        }

        [Test]
        public void TestConstructSquareMatrix_ItemsTableRectangleNotSquareConstructor_ArgumentException()
        {
            var itemsTable = new int[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 }
            };

            Assert.Throws<ArgumentException>(() => new SquareMatrix<int>(itemsTable));
        }

        #endregion

        #region Set tests

        [Test]
        public void TestSet_SetToSquareMatrix_Item()
        {
            var matrix = new SquareMatrix<int>(new int[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 3, 4, 5, 7 },
                { 8, 4, 2, 3 }
            });
            var expected = 9;
            matrix[3, 2] = expected;

            var actual = matrix[3, 2];

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestSet_SetToIndexOut_IndexOutOfRangeException()
        {
            var matrix = new SquareMatrix<int>(new int[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 3, 4, 5, 7 },
                { 8, 4, 2, 3 }
            });

            Assert.Throws<IndexOutOfRangeException>(() => matrix[4, 4] = 5);
        }

        #endregion
    }
}
