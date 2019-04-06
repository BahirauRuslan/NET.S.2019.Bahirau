using System.Collections.Generic;

namespace BooksManager
{
    public class ISBNComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.ISBN.CompareTo(y.ISBN);
        }
    }
}
