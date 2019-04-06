using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
