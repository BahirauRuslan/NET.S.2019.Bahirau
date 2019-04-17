using System;
using System.Collections.Generic;
using BooksManager.Comparers;

namespace BooksManager.Services
{
    /// <summary>
    /// The BookListService abstract class.
    /// Book service that contains method to store and load books from storage
    /// </summary>
    public abstract class BookListService
    {
        /// <summary>
        /// Dictionary of comparators. Key - book tag, value - comparer
        /// </summary>
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

        /// <summary>
        /// Buffer with books
        /// </summary>
        private List<Book> _booksBuffer = new List<Book>();

        /// <summary>
        /// Add book to the book buffer
        /// </summary>
        /// <param name="book">Book</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the book is already in the buffer
        /// </exception>
        public void AddBook(Book book)
        {
            if (Contains(book))
            {
                throw new ArgumentException("This book is already in list");
            }

            _booksBuffer.Add(book);
        }

        /// <summary>
        /// Remove book from the book buffer
        /// </summary>
        /// <param name="book">Book</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the book is not in the buffer
        /// </exception>
        public void RemoveBook(Book book)
        {
            if (!Contains(book))
            {
                throw new ArgumentException("This book is not in list");
            }

            _booksBuffer.Remove(book);
        }

        /// <summary>
        /// Find books by tag
        /// </summary>
        /// <param name="tag">Book tag</param>
        /// <param name="value">Value of tag</param>
        /// <returns>Books</returns>
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

        /// <summary>
        /// Sort books by tag
        /// </summary>
        /// <param name="tag">Book tag</param>
        public void SortBooksByTag(BookTag tag)
        {
            _booksBuffer.Sort(comparators[tag]);
        }

        /// <summary>
        /// Indicates that book buffer contains the book
        /// </summary>
        /// <param name="book">Book</param>
        /// <returns>true when buffer contains the book, else - false</returns>
        public bool Contains(Book book)
        {
            return _booksBuffer.Contains(book);
        }

        /// <summary>
        /// Get the array of books than in the book buffer
        /// </summary>
        /// <returns>Array of books</returns>
        public Book[] ToBookArray()
        {
            return _booksBuffer.ToArray();
        }

        /// <summary>
        /// Load books from storage to book buffer
        /// </summary>
        public abstract void LoadFromStorage();

        /// <summary>
        /// Save books from book buffer to storage
        /// </summary>
        public abstract void SaveToStorage();

        /// <summary>
        /// Get key book
        /// </summary>
        /// <param name="tag">Book tag</param>
        /// <param name="value">Book tag value</param>
        /// <returns>Book key</returns>
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
