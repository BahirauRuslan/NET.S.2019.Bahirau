using System;
using System.Collections.Generic;

namespace BooksManager
{
    public abstract class BookListService
    {
        private static IDictionary<BookTag, IComparer<Book>> comparators 
            = new Dictionary<BookTag, IComparer<Book>>
            {
                { BookTag.ISBN, new ISBNComparer() },
                { BookTag.Author, new AuthorComparer() },
                { BookTag.Title, new TitleComparer() },
                { BookTag.Publisher, new PublisherComparer() },
                { BookTag.PublishingYear, new PublishingYearComparer() },
                { BookTag.PagesCount, new PagesCountComparer() }
            };

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

        public IEnumerable<Book> FindBooksByTag(BookTag tag, object value)
        {
            IComparer<Book> comparer = comparators[tag]; 
            Book key = GetKeyBook(tag, value);
            
            foreach (Book book in _booksBuffer)
            {
                if (comparer.Compare(book, key) == 0)
                {
                    yield return book;
                }
            }
        }

        public void SortBooksByTag(BookTag tag)
        {
            _booksBuffer.Sort(comparators[tag]);
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

        private Book GetKeyBook(BookTag tag, object value)
        {
            switch (tag)
            {
                case BookTag.ISBN:
                    return new Book { ISBN = (string)value };
                case BookTag.Author:
                    return new Book { Author = (string)value };
                case BookTag.Title:
                    return new Book { Title = (string)value };
                case BookTag.Publisher:
                    return new Book { Publisher = (string)value };
                case BookTag.PublishingYear:
                    return new Book { PublishingYear = (int)value };
                case BookTag.PagesCount:
                    return new Book { PagesCount = (int)value };
                default:
                    return new Book();
            }
        }
    }
}
