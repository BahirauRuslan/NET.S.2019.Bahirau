using System;
using NUnit.Framework;

namespace CustomMatrix.Tests
{
    public class SymmetricMatrixTests
    {
        #region Constructor tests

        [Test]
        public void TestConstructSymmetricMatrix_EmptyConstructor_Pass()
        {
            new SymmetricMatrix<int>();

            Assert.Pass();
        }

        [Test]
        public void TestConstructSymmetricMatrix_ItemsTableConstructor_Pass()
        {
            new SymmetricMatrix<int>(new int[,]
            {
                { 1, 5, 6, 7 },
                { 5, 2, 9, 1 },
                { 6, 9, 3, 3 },
                { 7, 1, 3, 4 }
            });

            Assert.Pass();
        }

        [Test]
        public void TestConstructSymmetricMatrix_MatrixConstructor_Pass()
        {
            var matrix = new SymmetricMatrix<int?>(new int?[,]
            {
                { 1, 5, 6, null },
                { 5, 2, 9, 1 },
                { 6, 9, 3, 3 },
                { null, 1, 3, 4 }
            });

            new SymmetricMatrix<int?>(matrix);

            Assert.Pass();
        }

        [Test]
        public void TestConstructSymmetricMatrix_ItemsTableNotSymmetricConstructor_ArgumentException()
        {
            var itemsTable = new int?[,]
            {
                { 1, 5, 6, null },
                { 5, 2, 9, 1 },
                { null, 9, null, 3 },
                { null, 1, 3, 4 }
            };

            Assert.Throws<ArgumentException>(() => new SymmetricMatrix<int?>(itemsTable));
        }

        #endregion

        #region Set tests

        [Test]
        public void TestSet_SetToSymmetricMatrix_Item()
        {
            var matrix = new SymmetricMatrix<int>(new int[,]
            {
                { 1, 5, 6, 7 },
                { 5, 2, 9, 1 },
                { 6, 9, 3, 3 },
                { 7, 1, 3, 4 }
            });
            var expected = 9;
            matrix[3, 2] = expected;

            Assert.AreEqual(matrix[3, 2], matrix[2, 3]);
        }

        #endregion
    }
}
