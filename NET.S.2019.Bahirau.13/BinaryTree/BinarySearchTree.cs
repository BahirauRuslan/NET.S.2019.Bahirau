using System;
using System.Collections.Generic;

namespace BinaryTree
{
    /// <summary>
    /// Binary search tree.
    /// </summary>
    /// <typeparam name="T">Type of items.</typeparam>
    public class BinarySearchTree<T>
    {
        /// <summary>
        /// Root node.
        /// </summary>
        private readonly Node<T> _root;

        /// <summary>
        /// Items comparer.
        /// </summary>
        private readonly IComparer<T> _comparer;

        /// <summary>
        /// Creates binary search tree that contains root value and default comparer.
        /// </summary>
        /// <param name="value">Root value.</param>
        public BinarySearchTree(T value) : this(value, Comparer<T>.Default)
        {
        }

        /// <summary>
        /// Creates binary search tree that contains root value and custom comparer.
        /// </summary>
        /// <param name="value">Root value.</param>
        /// <param name="comparer">Custom comparer.</param>
        public BinarySearchTree(T value, IComparer<T> comparer)
        {
            _root = new Node<T>(value);
            _comparer = comparer;
        }

        /// <summary>
        /// Add values to tree
        /// </summary>
        /// <param name="values"></param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when values parameter is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when value is already in tree.
        /// </exception>
        public void Add(IEnumerable<T> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("Values must be not null");
            }

            foreach (var value in values)
            {
                Add(value);
            }
        }

        /// <summary>
        /// Add value to tree.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <returns>Node.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when value is already in tree.
        /// </exception>
        public void Add(T value)
        {
            Add(_root, value);
        }

        /// <summary>
        /// Pre-order view.
        /// </summary>
        /// <returns>Pre-order view of tree.</returns>
        public IEnumerable<T> Preorder()
        {
            return PreorderAlgorithm(_root);
        }

        /// <summary>
        /// In-order view.
        /// </summary>
        /// <returns>In-order view of tree.</returns>
        public IEnumerable<T> Inorder()
        {
            return InorderAlgorithm(_root);
        }

        /// <summary>
        /// Post-order view.
        /// </summary>
        /// <returns>Post-order view of tree.</returns>
        public IEnumerable<T> Postorder()
        {
            return PostorderAlgorithm(_root);
        }

        /// <summary>
        /// Add value to tree.
        /// </summary>
        /// <param name="node">Node.</param>
        /// <param name="value">Value.</param>
        /// <returns>Node.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when value is already in tree.
        /// </exception>
        private Node<T> Add(Node<T> node, T value)
        {
            if (node == null)
            {
                return new Node<T>(value);
            }

            if (_comparer.Compare(value, node.Value) < 0)
            {
                node.Left = Add(node.Left, value);
            }
            else if (_comparer.Compare(value, node.Value) > 0)
            {
                node.Right = Add(node.Right, value);
            }
            else
            {
                throw new InvalidOperationException("Сan not add an item that is already in the tree");
            } 

            return node;
        }

        /// <summary>
        /// Pre-order view.
        /// </summary>
        /// <param name="node">Root node.</param>
        /// <returns>Pre-order view of tree.</returns>
        private IEnumerable<T> PreorderAlgorithm(Node<T> node)
        {
            yield return node.Value;
            if (node.Left != null)
            {
                foreach (var value in PreorderAlgorithm(node.Left))
                {
                    yield return value;
                }
            }

            if (node.Right != null)
            {
                foreach (var value in PreorderAlgorithm(node.Right))
                {
                    yield return value;
                }
            }
        }

        /// <summary>
        /// In-order view.
        /// </summary>
        /// <param name="node">Root node.</param>
        /// <returns>In-order view of tree.</returns>
        private IEnumerable<T> InorderAlgorithm(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var value in InorderAlgorithm(node.Left))
                {
                    yield return value;
                }
            }

            yield return node.Value;

            if (node.Right != null)
            {
                foreach (var value in InorderAlgorithm(node.Right))
                {
                    yield return value;
                }
            }
        }

        /// <summary>
        /// Post-order view.
        /// </summary>
        /// <param name="node">Root node.</param>
        /// <returns>Post-order view of tree.</returns>
        private IEnumerable<T> PostorderAlgorithm(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var value in PostorderAlgorithm(node.Left))
                {
                    yield return value;
                }
            }

            if (node.Right != null)
            {
                foreach (var value in PostorderAlgorithm(node.Right))
                {
                    yield return value;
                }
            }

            yield return node.Value;
        }
    }
}
