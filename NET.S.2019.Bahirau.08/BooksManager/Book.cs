using System;
using System.Collections.Generic;

namespace BooksManager
{
    /// <summary>
    /// The Book class.
    /// Describes a book
    /// </summary>
    [Serializable]
    public class Book : IEquatable<Book>
    {
        /// <summary>
        /// ISBN
        /// </summary>
        private string _isbn = string.Empty;

        /// <summary>
        /// Author name
        /// </summary>
        private string _author = string.Empty;

        /// <summary>
        /// Book title
        /// </summary>
        private string _title = string.Empty;

        /// <summary>
        /// Publisher
        /// </summary>
        private string _publisher = string.Empty;

        /// <summary>
        /// Publishing year
        /// </summary>
        private int _publishingYear;

        /// <summary>
        /// Count of pages
        /// </summary>
        private int _pagesCount;

        /// <summary>
        /// ISBN of book
        /// </summary>
        public string ISBN
        {
            get
            {
                return _isbn;
            }

            set
            {
                _isbn = value ?? throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Book author
        /// </summary>
        public string Author
        {
            get
            {
                return _author;
            }

            set
            {
                _author = value ?? throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Book title
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value ?? throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Book publisher
        /// </summary>
        public string Publisher
        {
            get
            {
                return _publisher;
            }

            set
            {
                _publisher = value ?? throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Publication year
        /// </summary>
        public int PublishingYear
        {
            get
            {
                return _publishingYear;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                _publishingYear = value;
            }
        }

        /// <summary>
        /// Count of pages
        /// </summary>
        public int PagesCount
        {
            get
            {
                return _pagesCount;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                _pagesCount = value;
            }
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Book);
        }

        public bool Equals(Book other)
        {
            return other != null &&
                   _isbn == other._isbn &&
                   _author == other._author &&
                   _title == other._title &&
                   _publisher == other._publisher &&
                   _publishingYear == other._publishingYear &&
                   _pagesCount == other._pagesCount;
        }

        public override int GetHashCode()
        {
            var hashCode = 844150712;
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(_isbn);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(_author);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(_title);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(_publisher);
            hashCode = (hashCode * -1521134295) + _publishingYear.GetHashCode();
            hashCode = (hashCode * -1521134295) + _pagesCount.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return string.Format(
                "Book:\nISBN: {0}\nAuthor: {1}\nTitle: {2}\nPublisher: {3}\nYear: {4}\nCount of pages: {5}\n",
                _isbn,
                _author,
                _title,
                _publisher,
                _publishingYear,
                _pagesCount);
        }
    }
}
