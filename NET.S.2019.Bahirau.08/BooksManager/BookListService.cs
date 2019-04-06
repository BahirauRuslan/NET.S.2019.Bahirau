using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager
{
    public abstract class BookListService
    {
        private List<Book> _booksBuffer = new List<Book>();

        public void AddBook(Book book)
        {
            if (Contains(book))
            {
                throw new ArgumentException();
            }

            _booksBuffer.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if (!Contains(book))
            {
                throw new ArgumentException();
            }

            _booksBuffer.Remove(book);
        }

        public IEnumerable<Book> FindBooksByTag()
        {
            throw new NotImplementedException();
        }

        public void SortBooksByTag()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Book book)
        {
            return _booksBuffer.Contains(book);
        }

        public Book[] ToBookArray()
        {
            return _booksBuffer.ToArray();
        }

        public abstract void LoadFromStorage();

        public abstract void SaveToStorage();
    }
}
