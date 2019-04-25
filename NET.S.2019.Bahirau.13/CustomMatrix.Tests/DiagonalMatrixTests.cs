using System;
using NUnit.Framework;

namespace CustomMatrix.Tests
{
    public class DiagonalMatrixTests
    {
        #region Constructor tests

        [Test]
        public void TestConstructDiagonalMatrix_EmptyConstructor_Pass()
        {
            new DiagonalMatrix<int>();

            Assert.Pass();
        }

        [Test]
        public void TestConstructDiagonalMatrix_ItemsValueTableConstructor_Pass()
        {
            new DiagonalMatrix<int>(new int[,]
            {
                { 1, 0, 0, 0 },
                { 0, 2, 0, 0 },
                { 0, 0, 3, 0 },
                { 0, 0, 0, 4 }
            });

            Assert.Pass();
        }

        [Test]
        public void TestConstructDiagonalMatrix_ItemsReferenceTableConstructor_Pass()
        {
            new DiagonalMatrix<string>(new string[,]
            {
                { "10", null, null, null },
                { null, "20", null, null },
                { null, null, "30", null },
                { null, null, null, "40" }
            });

            Assert.Pass();
        }

        [Test]
        public void TestConstructDiagonalMatrix_MatrixConstructor_Pass()
        {
            var matrix = new DiagonalMatrix<string>(new string[,]
            {
                { "10", null, null, null },
                { null, "20", null, null },
                { null, null, "30", null },
                { null, null, null, "40" }
            });

            new DiagonalMatrix<string>(matrix);

            Assert.Pass();
        }

        [Test]
        public void TestConstructDiagonalMatrix_ItemsValueTableNotDiagonalConstructor_ArgumentException()
        {
            var itemsTable = new int[,]
            {
                { 1, 0, 0, 0 },
                { 0, 2, 0, 0 },
                { 6, 0, 3, 0 },
                { 0, 0, 0, 4 }
            };

            Assert.Throws<ArgumentException>(() => new DiagonalMatrix<int>(itemsTable));
        }

        [Test]
        public void TestConstructDiagonalMatrix_ItemsReferenceTableNotDiagonalConstructor_ArgumentException()
        {
            var itemsTable = new string[,]
            {
                { "10", null, null, null },
                { null, "20", "ab", null },
                { null, null, "30", null },
                { null, null, null, "40" }
            };

            Assert.Throws<ArgumentException>(() => new DiagonalMatrix<string>(itemsTable));
        }
        
        #endregion

        #region Set tests

        [Test]
        public void TestSet_SetToDiagonalMatrix_Item()
        {
            var matrix = new DiagonalMatrix<int>(new int[,]
            {
                { 1, 0, 0, 0 },
                { 0, 2, 0, 0 },
                { 0, 0, 3, 0 },
                { 0, 0, 0, 4 }
            });
            var expected = 9;
            matrix[2] = expected;

            var actual = matrix[2];

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestSet_SetToDiagonalMatrixIndexOut_IndexOutOfRangeException()
        {
            var matrix = new DiagonalMatrix<int>(new int[,]
            {
                { 1, 0, 0, 0 },
                { 0, 2, 0, 0 },
                { 0, 0, 3, 0 },
                { 0, 0, 0, 4 }
            });

            Assert.Throws<IndexOutOfRangeException>(() => matrix[4] = 12);
        }

        #endregion
    }
}
