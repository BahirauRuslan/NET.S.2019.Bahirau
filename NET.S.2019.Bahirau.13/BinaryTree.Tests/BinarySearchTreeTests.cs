using System.Linq;
using BooksManager;
using NUnit.Framework;

namespace BinaryTree.Tests
{
    public class BinarySearchTreeTests
    {
        #region Integer tests

        [Test]
        public void TestPreorder_IntDefault_Tree()
        {
            var tree = new BinarySearchTree<int>(7);
            tree.Add(new int[] { 4, 2, 3, 1, 5, 8 });
            var expected = new int[] { 7, 4, 2, 1, 3, 5, 8 };

            var actual = tree.Preorder().ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TestInorder_IntDefault_Tree()
        {
            var tree = new BinarySearchTree<int>(7);
            tree.Add(new int[] { 4, 2, 3, 1, 5, 8 });
            var expected = new int[] { 1, 2, 3, 4, 5, 7, 8 };

            var actual = tree.Inorder().ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPostorder_IntDefault_Tree()
        {
            var tree = new BinarySearchTree<int>(7);
            tree.Add(new int[] { 4, 2, 3, 1, 5, 8 });
            var expected = new int[] { 1, 3, 2, 5, 4, 8, 7 };

            var actual = tree.Postorder().ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        #endregion

        #region String tests

        [Test]
        public void TestPreorder_StringDefault_Tree()
        {
            var tree = new BinarySearchTree<string>("7");
            tree.Add(new string[] { "4", "2", "3", "1", "5", "8" });
            var expected = new string[] { "7", "4", "2", "1", "3", "5", "8" };

            var actual = tree.Preorder().ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TestInorder_StringDefault_Tree()
        {
            var tree = new BinarySearchTree<string>("7");
            tree.Add(new string[] { "4", "2", "3", "1", "5", "8" });
            var expected = new string[] { "1", "2", "3", "4", "5", "7", "8" };

            var actual = tree.Inorder().ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPostorder_StringDefault_Tree()
        {
            var tree = new BinarySearchTree<string>("7");
            tree.Add(new string[] { "4", "2", "3", "1", "5", "8" });
            var expected = new string[] { "1", "3", "2", "5", "4", "8", "7" };

            var actual = tree.Postorder().ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        #endregion

        #region Book tests

        [Test]
        public void TestPreorder_BookPagesCount_Tree()
        {
            var tree = new BinarySearchTree<Book>(new Book { PagesCount = 7 }, new PagesCountComparer());
            tree.Add(new Book[]
            {
                new Book { PagesCount = 4 },
                new Book { PagesCount = 2 },
                new Book { PagesCount = 3 },
                new Book { PagesCount = 1 },
                new Book { PagesCount = 5 },
                new Book { PagesCount = 8 }
            });
            var expected = new Book[]
            {
                new Book { PagesCount = 7 },
                new Book { PagesCount = 4 },
                new Book { PagesCount = 2 },
                new Book { PagesCount = 1 },
                new Book { PagesCount = 3 },
                new Book { PagesCount = 5 },
                new Book { PagesCount = 8 }
            };

            var actual = tree.Preorder().ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TestInorder_BookPagesCount_Tree()
        {
            var tree = new BinarySearchTree<Book>(new Book { PagesCount = 7 }, new PagesCountComparer());
            tree.Add(new Book[]
            {
                new Book { PagesCount = 4 },
                new Book { PagesCount = 2 },
                new Book { PagesCount = 3 },
                new Book { PagesCount = 1 },
                new Book { PagesCount = 5 },
                new Book { PagesCount = 8 }
            });
            var expected = new Book[]
            {
                new Book { PagesCount = 1 },
                new Book { PagesCount = 2 },
                new Book { PagesCount = 3 },
                new Book { PagesCount = 4 },
                new Book { PagesCount = 5 },
                new Book { PagesCount = 7 },
                new Book { PagesCount = 8 }
            };

            var actual = tree.Inorder().ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPostorder_BookPagesCount_Tree()
        {
            var tree = new BinarySearchTree<Book>(new Book { PagesCount = 7 }, new PagesCountComparer());
            tree.Add(new Book[]
            {
                new Book { PagesCount = 4 },
                new Book { PagesCount = 2 },
                new Book { PagesCount = 3 },
                new Book { PagesCount = 1 },
                new Book { PagesCount = 5 },
                new Book { PagesCount = 8 }
            });
            var expected = new Book[]
            {
                new Book { PagesCount = 1 },
                new Book { PagesCount = 3 },
                new Book { PagesCount = 2 },
                new Book { PagesCount = 5 },
                new Book { PagesCount = 4 },
                new Book { PagesCount = 8 },
                new Book { PagesCount = 7 }
            };

            var actual = tree.Postorder().ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        #endregion

        #region Point tests

        [Test]
        public void TestPreorder_PointLength_Tree()
        {
            var tree = new BinarySearchTree<Point>(new Point(7, 7, 7), new PointComparer());
            tree.Add(new Point[]
            {
                new Point(4, 4, 4),
                new Point(2, 2, 2),
                new Point(3, 3, 3),
                new Point(1, 1, 1),
                new Point(5, 5, 5),
                new Point(8, 8, 8)
            });
            var expected = new Point[]
            {
                new Point(7, 7, 7),
                new Point(4, 4, 4),
                new Point(2, 2, 2),
                new Point(1, 1, 1),
                new Point(3, 3, 3),
                new Point(5, 5, 5),
                new Point(8, 8, 8)
            };

            var actual = tree.Preorder().ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TestInorder_PointLength_Tree()
        {
            var tree = new BinarySearchTree<Point>(new Point(7, 7, 7), new PointComparer());
            tree.Add(new Point[]
            {
                new Point(4, 4, 4),
                new Point(2, 2, 2),
                new Point(3, 3, 3),
                new Point(1, 1, 1),
                new Point(5, 5, 5),
                new Point(8, 8, 8)
            });
            var expected = new Point[]
            {
                new Point(1, 1, 1),
                new Point(2, 2, 2),
                new Point(3, 3, 3),
                new Point(4, 4, 4),
                new Point(5, 5, 5),
                new Point(7, 7, 7),
                new Point(8, 8, 8)
            };

            var actual = tree.Inorder().ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPostorder_PointLength_Tree()
        {
            var tree = new BinarySearchTree<Point>(new Point(7, 7, 7), new PointComparer());
            tree.Add(new Point[]
            {
                new Point(4, 4, 4),
                new Point(2, 2, 2),
                new Point(3, 3, 3),
                new Point(1, 1, 1),
                new Point(5, 5, 5),
                new Point(8, 8, 8)
            });
            var expected = new Point[]
            {
                new Point(1, 1, 1),
                new Point(3, 3, 3),
                new Point(2, 2, 2),
                new Point(5, 5, 5),
                new Point(4, 4, 4),
                new Point(8, 8, 8),
                new Point(7, 7, 7)
            };

            var actual = tree.Postorder().ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        #endregion
    }
}