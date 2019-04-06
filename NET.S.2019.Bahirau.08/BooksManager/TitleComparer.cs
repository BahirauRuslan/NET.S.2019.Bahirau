using System.Collections.Generic;

namespace BooksManager
{
    public class TitleComparer : IComparer<Book>
    {
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
                return string.Compare(x.Title, y.Title);
            }
        }
    }
}
