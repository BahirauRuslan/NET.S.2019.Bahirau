namespace BinaryTree
{
    /// <summary>
    /// Node class.
    /// </summary>
    /// <typeparam name="T">Type of value.</typeparam>
    internal class Node<T>
    {
        /// <summary>
        /// Creates node.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="left">Left child node.</param>
        /// <param name="right">Right child node.</param>
        internal Node(T value = default, Node<T> left = null, Node<T> right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        /// <summary>
        /// Left child node.
        /// </summary>
        internal Node<T> Left { get; set; }

        /// <summary>
        /// Right child node.
        /// </summary>
        internal Node<T> Right { get; set; }

        /// <summary>
        /// Value.
        /// </summary>
        internal T Value { get; set; }
    }
}
