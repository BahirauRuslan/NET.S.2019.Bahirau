using System.Collections.Generic;

namespace BooksManager
{
    public class AuthorComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Author.CompareTo(y.Author);
        }
    }
}
