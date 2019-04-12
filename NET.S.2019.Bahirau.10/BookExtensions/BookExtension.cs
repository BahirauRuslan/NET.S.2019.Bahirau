using System;

namespace BookExtensions
{
    /// <summary>
    /// The BookExtension static class that 
    /// provides additional formatting for the objects of Book class
    /// </summary>
    public static class BookExtension
    {
        /// <summary>
        /// The ToString extension method that provides additional formatting for the objects of Book class
        /// </summary>
        /// <param name="book">Book object</param>
        /// <param name="format">Format</param>
        /// <param name="formatProvider">Format provider</param>
        /// <param name="separator">Custom separator</param>
        /// <returns>String representation of book object</returns>
        public static string ToString(this Book book, string format, IFormatProvider formatProvider, string separator)
        {
            if (separator == null)
            {
                throw new ArgumentNullException("Separator cannot be null");
            }

            if (separator == ", ")
            {
                return book.ToString(format, formatProvider);
            }

            var parameters = book.ToString(format, formatProvider).Split(new string[] { ", " }, StringSplitOptions.None);
            return string.Join(separator, parameters);
        }
    }
}
