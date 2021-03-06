﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomQueue
{
    /// <summary>
    /// Custom enumerator MyEnumerator class.
    /// </summary>
    /// <typeparam name="T">Type of items.</typeparam>
    public class MyEnumerator<T> : IEnumerator<T>
    {
        /// <summary>
        /// Array of items.
        /// </summary>
        private readonly T[] _arr;

        /// <summary>
        /// Head.
        /// </summary>
        private readonly int _head;

        /// <summary>
        /// Tail.
        /// </summary>
        private readonly int _tail;

        /// <summary>
        /// Current index position.
        /// </summary>
        private int _position;

        /// <summary>
        /// Create new MyEnumerator object.
        /// </summary>
        /// <param name="arr">Array of items.</param>
        public MyEnumerator(T[] arr, int head, int tail)
        {
            _arr = arr;
            _head = head;
            _tail = tail;
            _position = _head - 1;
        }

        /// <summary>
        /// Gets current item if current position more than -1 
        /// and less than length of array of items.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when current position is out of bounds.
        /// </exception>
        public T Current
        {
            get
            {
                if (_position == _head - 1 || _position > _tail)
                {
                    throw new InvalidOperationException();
                }

                return _arr[_position];
            }
        }

        /// <summary>
        /// Gets current item if current position more than -1 
        /// and less than length of array of items.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when current position is out of bounds.
        /// </exception>
        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        /// <summary>
        /// Increment position if position less than length of array of items.
        /// </summary>
        /// <returns>True if position moved, in other case - false.</returns>
        public bool MoveNext()
        {
            if (_position < _tail && _position >= -1)
            {
                _position++;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Reset the current position.
        /// </summary>
        public void Reset()
        {
            _position = _head - 1;
        }
    }
}
