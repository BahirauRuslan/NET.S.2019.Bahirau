﻿using System.Collections.Generic;

namespace BooksManager
{
    /// <summary>
    /// Book author comparer
    /// </summary>
    public class AuthorComparer : IComparer<Book>
    {
        /// <summary>
        /// Compare two books by author name
        /// </summary>
        /// <param name="x">First book</param>
        /// <param name="y">Second book</param>
        /// <returns>-1 if x less than y, 0 if x equal y, 1 if x more than y</returns>
        public int Compare(Book x, Book y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            else if (x == null)
            {
                return -1;
            }
            else if (y == null)
            {
                return 1;
            }
            else
            {
                return string.Compare(x.Author, y.Author);
            }
        }
    }
}
