using System;
using NUnit.Framework;

namespace CustomMatrix.Tests
{
    public class StaticMatrixTests
    {
        #region Constructor tests

        [Test]
        public void TestConstructStaticMatrix_EmptyConstructor_Pass()
        {
            new StaticMatrix<int>();

            Assert.Pass();
        }

        [Test]
        public void TestConstructStaticMatrix_ItemsTableConstructor_Pass()
        {
            new StaticMatrix<int>(new int[,] 
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 }
            });

            Assert.Pass();
        }

        [Test]
        public void TestConstructStaticMatrix_MatrixConstructor_Pass()
        {
            var matrix = new StaticMatrix<int>(new int[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 }
            });

            new StaticMatrix<int>(matrix);

            Assert.Pass();
        }

        [Test]
        public void TestConstructStaticMatrix_ItemsTableNullConstructor_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new StaticMatrix<int>((int[,])null));
        }

        [Test]
        public void TestConstructStaticMatrix_ItemsTableEmptyConstructor_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new StaticMatrix<int>(new int[0, 0]));
        }

        [Test]
        public void TestConstructStaticMatrix_MatrixNullConstructor_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new StaticMatrix<int>((StaticMatrix<int>)null));
        }

        #endregion

        #region Get tests

        [Test]
        public void TestGet_Item_Item()
        {
            var matrix = new StaticMatrix<int>(new int[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 }
            });
            var expected = 6;

            var actual = matrix[1, 1];

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestGet_IndexOut_IndexOutOfRangeException()
        {
            var matrix = new StaticMatrix<int>(new int[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 }
            });

            Assert.Throws<IndexOutOfRangeException>(() => matrix[1, 4].ToString());
        }

        #endregion
    }
}