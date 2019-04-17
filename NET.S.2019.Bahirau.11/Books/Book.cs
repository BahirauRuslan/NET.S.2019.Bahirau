using System;
using System.Collections.Generic;
using System.Globalization;

namespace Books
{
    /// <summary>
    /// The Book class.
    /// Describes a book
    /// </summary>
    [Serializable]
    public class Book : IEquatable<Book>, IFormattable
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
        /// Count of pages
        /// </summary>
        private int _pagesCount;

        /// <summary>
        /// Book price
        /// </summary>
        private decimal _price;

        /// <summary>
        /// Publication year
        /// </summary>
        public int PublishingYear { get; set; }

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
                _isbn = value ?? throw new ArgumentNullException("ISBN cannot be null");
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
                _author = value ?? throw new ArgumentNullException("Author name cannot be null");
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
                _title = value ?? throw new ArgumentNullException("Book title cannot be null");
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
                _publisher = value ?? throw new ArgumentNullException("Publisher cannot be null");
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
                    throw new ArgumentException("Count of pages must be more than zero or equal");
                }

                _pagesCount = value;
            }
        }

        /// <summary>
        /// Book price
        /// </summary>
        public decimal Price
        {
            get
            {
                return _price;
            }

            set
            {
                if (value < 0.0m)
                {
                    throw new ArgumentException("Book price must be more than zero or equal");
                }

                _price = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Book:\nISBN: {0}\nAuthor: {1}\nTitle: {2}\nPublisher: {3}\nYear: {4}\nCount of pages: {5}\nPrice: {6}$\n",
                _isbn,
                _author,
                _title,
                _publisher,
                PublishingYear,
                _pagesCount,
                _price);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            formatProvider = formatProvider ?? CultureInfo.CurrentCulture;

            if (string.IsNullOrEmpty(format))
            {
                format = "G";
            }

            var parameters = new string[format.Length];

            for (var i = 0; i < parameters.Length; i++)
            {
                parameters[i] = ToStringByFormat(format[i], formatProvider);
            }

            return string.Join(", ", parameters);
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
                   _pagesCount == other._pagesCount &&
                   _price == other._price &&
                   PublishingYear == other.PublishingYear;
        }

        public override int GetHashCode()
        {
            var hashCode = 785420666;
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(_isbn);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(_author);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(_title);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(_publisher);
            hashCode = (hashCode * -1521134295) + _pagesCount.GetHashCode();
            hashCode = (hashCode * -1521134295) + _price.GetHashCode();
            hashCode = (hashCode * -1521134295) + PublishingYear.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Gets a string representation of book parameter
        /// </summary>
        /// <param name="formatLetter">The letter that indicates which parameter needs to be returned</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>String representation of parameter</returns>
        private string ToStringByFormat(char formatLetter, IFormatProvider formatProvider)
        {
            switch (formatLetter)
            {
                case 'G':
                case 'T':
                    return string.Format(formatProvider, "{0}", _title);
                case 'I':
                    return string.Format(formatProvider, "ISBN 13: {0}", _isbn);
                case 'A':
                    return string.Format(formatProvider, "{0}", _author);
                case 'P':
                    return string.Format(formatProvider, "\"{0}\"", _publisher);
                case 'Y':
                    return string.Format(
                        formatProvider, 
                        "{0}{1}", 
                        PublishingYear, 
                        PublishingYear < 0 ? " BC" : string.Empty);
                case 'C':
                    return string.Format(formatProvider, "P. {0}", _pagesCount);
                case 'S':
                    return _price.ToString("C", formatProvider);
                default:
                    throw new FormatException(string.Format("The {0} format is not supported.", formatLetter));
            }
        }
    }
}