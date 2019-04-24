using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomQueue
{
    /// <summary>
    /// Custom queue class.
    /// </summary>
    /// <typeparam name="T">Type of items.</typeparam>
    public class MyQueue<T> : IEnumerable<T>, ICollection
    {
        /// <summary>
        /// Storage.
        /// </summary>
        private T[] _items;

        /// <summary>
        /// Count of items.
        /// </summary>
        private int _count = 0;

        /// <summary>
        /// Head position.
        /// </summary>
        private int _head = -1;

        /// <summary>
        /// Tail position.
        /// </summary>
        private int _tail = -1;

        /// <summary>
        /// Default constructor. Creates queue with capacity = 10.
        /// </summary>
        public MyQueue() : this(10)
        {
        }

        /// <summary>
        /// Constructor that creates queue with custom capacity.
        /// </summary>
        /// <param name="capacity">Capacity of storage.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when capacity less than zero.
        /// </exception>
        public MyQueue(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentException("Capacity can not be less than one");
            }

            _items = new T[capacity];
        }

        /// <summary>
        /// Creates a queue of the given items.
        /// </summary>
        /// <param name="items">Items.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when items is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when count of items less than one.
        /// </exception>
        public MyQueue(IEnumerable<T> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("Items set can not be null");
            }

            if (items.Count() < 1)
            {
                throw new ArgumentException();
            }

            _items = items.ToArray();
            _count = _items.Length;
            _head = 0;
            _tail = _items.Length - 1;
        }

        /// <summary>
        /// Gets the number of elements.
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// Gets an object that can be used to synchronize access 
        /// to the System.Collections.ICollection.
        /// </summary>
        public object SyncRoot => new object();

        /// <summary>
        /// Gets a value indicating whether access to the 
        /// System.Collections.ICollection is synchronized (thread safe).
        /// </summary>
        public bool IsSynchronized => false;

        /// <summary>
        /// Enqueues item.
        /// </summary>
        /// <param name="item">Item.</param>
        public void Enqueue(T item)
        {
            if (_tail == _items.Length - 1 && _items.Length > _count)
            {
                MoveToBegin();
            }
            else if (_tail == _items.Length - 1)
            {
                IncreaseCapacity();
            }

            _items[++_tail] = item;

            if (_count == 0)
            {
                _head = _tail;
            }

            _count++;
        }

        /// <summary>
        /// Peeks first item.
        /// </summary>
        /// <returns>Head item.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when queue is empty.
        /// </exception>
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return _items[_head];
        }

        /// <summary>
        /// Removes and get head item.
        /// </summary>
        /// <returns>Head item.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when queue is empty.
        /// </exception>
        public T Dequeue()
        {
            var item = Peek();
            _items[_head] = default;

            if (_head < _tail)
            {
                _head++;
            }
            else
            {
                _head = -1;
                _tail = -1;
            }

            _count--;
            return item;
        }

        /// <summary>
        /// Copies the elements of the System.Collections.ICollection to an System.Array
        /// starting at a particular System.Array index.
        /// </summary>
        /// <param name="array">
        /// The one-dimensional System.Array that is the destination of the elements copied 
        /// from System.Collections.ICollection. The System.Array must have zero-based indexing.
        /// </param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when array items type and storage items type are incompatible 
        /// or array is multidimensional or the number of elements in the source
        /// is greater than the available space from index to the end of the destination array.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Index out of bounds.
        /// </exception>
        public void CopyTo(Array array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array must be not null");
            }

            if (array.GetType().GetElementType() != typeof(T))
            {
                throw new ArgumentException("array items and storage items are of incompatible types");
            }

            if (array.Rank != 1)
            {
                throw new ArgumentException("Rank must be 1");
            }

            if (array.Length < _count - index)
            {
                throw new ArgumentException("Too small array");
            }

            if (index < 0 || index > _count - 1)
            {
                throw new ArgumentOutOfRangeException("Index out of bounds");
            }

            Array.Copy(_items, _head + index, array, 0, _count - index);
        }

        /// <summary>
        /// Trims unused size of storage.
        /// </summary>
        public void TrimToSize()
        {
            T[] newItemsArr = new T[_count];
            Array.Copy(_items, _head, newItemsArr, 0, _count);
            _items = newItemsArr;
            _head = 0;
            _tail = _count - 1;
        }

        /// <summary>
        /// Indicates that queue is empty.
        /// </summary>
        /// <returns>True - queue is empty. False - queue isn't empty.</returns>
        public bool IsEmpty()
        {
            return _count == 0;
        }

        /// <summary>
        /// Gets generic enumerator.
        /// </summary>
        /// <returns>Generic enumerator.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(_items, _head, _tail);
        }

        /// <summary>
        /// Gets enumerator.
        /// </summary>
        /// <returns>Enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        /// <summary>
        /// Increases storage capacity.
        /// </summary>
        private void IncreaseCapacity()
        {
            T[] newItemsArr;

            if (_items.Length > 0)
            {
                newItemsArr = new T[_items.Length * 2];
                Array.Copy(_items, 0, newItemsArr, 0, _items.Length);
            }
            else
            {
                newItemsArr = new T[10];
            }

            _items = newItemsArr;
        }

        /// <summary>
        /// Moves items to the beginning of the storage.
        /// </summary>
        private void MoveToBegin()
        {
            Array.Copy(_items, _head, _items, 0, _count);
            _head = 0;
            _tail = _count - 1;
        }
    }
}
