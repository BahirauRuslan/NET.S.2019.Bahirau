using System;
using NUnit.Framework;

namespace CustomQueue.Tests
{
    public class MyQueueTests
    {
        #region Enqueue tests

        [Test]
        public void TestEnqueue_ToEmptyQueue_Queue()
        {
            var queue = new MyQueue<int>();
            var expected = new int[] { 12 };

            queue.Enqueue(expected[0]);

            CollectionAssert.AreEqual(expected, queue);
        }

        [Test]
        public void TestEnqueue_ToFullShiftedQueue_Queue()
        {
            var queue = new MyQueue<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            queue.Dequeue();
            var expected = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            queue.Enqueue(expected[expected.Length - 1]);

            CollectionAssert.AreEqual(expected, queue);
        }

        [Test]
        public void TestEnqueue_ToFullQueue_Queue()
        {
            var queue = new MyQueue<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            queue.Enqueue(expected[expected.Length - 1]);

            CollectionAssert.AreEqual(expected, queue);
        }

        #endregion

        #region Peek tests

        [Test]
        public void TestPeek_NotEmptyQueue_FirstItem()
        {
            var queue = new MyQueue<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            var expected = 1;

            var actual = queue.Peek();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPeek_EmptyQueue_InvvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new MyQueue<int>().Peek());
        }

        #endregion

        #region Dequeue tests

        [Test]
        public void TestDequeue_Queue_QueueWithoutFirstItem()
        {
            var queue = new MyQueue<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            var expected = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            queue.Dequeue();

            CollectionAssert.AreEqual(expected, queue);
        }

        [Test]
        public void TestDequeue_QueueOneItem_EmptyQueue()
        {
            var queue = new MyQueue<int>(new int[] { 1 });
            var expected = new int[0];

            queue.Dequeue();

            CollectionAssert.AreEqual(expected, queue);
        }

        [Test]
        public void TestDequeue_EmptyQueue_InvalidOperationExcepton()
        {
            Assert.Throws<InvalidOperationException>(() => new MyQueue<int>().Dequeue());
        }

        #endregion

        #region Constructor negative tests

        [TestCase(-12)]
        [TestCase(0)]
        public void TestCreateQueue_NonPositiveCapacity_ArgumentException(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new MyQueue<string>(capacity));
        }

        [Test]
        public void TestCreateQueue_NullItems_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new MyQueue<string>(null));
        }

        [Test]
        public void TestCreateQueue_EmptyArray_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new MyQueue<string>(new string[0]));
        }

        #endregion
    }
}