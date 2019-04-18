using System;
using System.Collections.Generic;
using BooksManager.Services;
using NLog;

namespace BooksManager
{
    public class Program
    {
        private static readonly BookListService Service = new BookListFileService();

        public static void Main()
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Log(LogLevel.Trace, LogLevel.FromOrdinal(6).ToString());
            while (MainMenu())
            {
            }
        }

        private static bool MainMenu()
        {
            var enabled = true;
            var menu = "1. Load books\n2. Add book\n" +
                "3. Remove book\n4. Find book by\n" +
                "5. Sort book by\n6. Save books\nCase: ";
            var menuCase = GetInt(menu);
            try
            {
                switch (menuCase)
                {
                    case 1:
                        LoadBooks();
                        break;
                    case 2:
                        AddBook();
                        break;
                    case 3:
                        RemoveBook();
                        break;
                    case 4:
                        FindBooks();
                        break;
                    case 5:
                        SortBooks();
                        break;
                    case 6:
                        SaveBooks();
                        break;
                    default:
                        enabled = false;
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return enabled;
        }

        private static void LoadBooks()
        {
            Service.LoadFromStorage();
            PrintBooks(Service.ToBookArray());
        }

        private static void AddBook()
        {
            var book = new Book
            {
                ISBN = GetString("ISBN: "),
                Author = GetString("Author: "),
                Title = GetString("Title: "),
                Publisher = GetString("Publisher: "),
                PublishingYear = GetInt("Publishing year: "),
                PagesCount = GetInt("Count of pages: ")
            };
            Service.AddBook(book);
            PrintBooks(Service.ToBookArray());
        }

        private static void RemoveBook()
        {
            var books = Service.ToBookArray();
            PrintBooks(books);
            var index = GetInt("Remove by index: ") - 1;
            if (index > -1 && index < books.Length)
            {
                Service.RemoveBook(books[index]);
            }

            PrintBooks(Service.ToBookArray());
        }

        private static void FindBooks()
        {
            var menu = "1. ESBN\n2. Author\n3. Title\n" +
                "4. Publisher\n5. Publishing year\n6. Count of pages\nCase: ";
            var menuCase = GetInt(menu);
            switch (menuCase)
            {
                case 1:
                    PrintBooks(Service.FindBooksByTag(BookTag.ISBN, GetString("ISBN: ")));
                    break;
                case 2:
                    PrintBooks(Service.FindBooksByTag(BookTag.Author, GetString("Author: ")));
                    break;
                case 3:
                    PrintBooks(Service.FindBooksByTag(BookTag.Title, GetString("Title: ")));
                    break;
                case 4:
                    PrintBooks(Service.FindBooksByTag(BookTag.Publisher, GetString("Publisher: ")));
                    break;
                case 5:
                    PrintBooks(Service.FindBooksByTag(BookTag.PublishingYear, GetInt("Publishing year: ")));
                    break;
                case 6:
                    PrintBooks(Service.FindBooksByTag(BookTag.PagesCount, GetInt("Count of pages: ")));
                    break;
                default:
                    break;
            }
        }

        private static void SortBooks()
        {
            var menu = "1. ESBN\n2. Author\n3. Title\n" +
                "4. Publisher\n5. Publishing year\n6. Count of pages\nCase: ";
            var menuCase = GetInt(menu);
            switch (menuCase)
            {
                case 1:
                    Service.SortBooksByTag(BookTag.ISBN);
                    break;
                case 2:
                    Service.SortBooksByTag(BookTag.Author);
                    break;
                case 3:
                    Service.SortBooksByTag(BookTag.Title);
                    break;
                case 4:
                    Service.SortBooksByTag(BookTag.Publisher);
                    break;
                case 5:
                    Service.SortBooksByTag(BookTag.PublishingYear);
                    break;
                case 6:
                    Service.SortBooksByTag(BookTag.PagesCount);
                    break;
                default:
                    break;
            }

            PrintBooks(Service.ToBookArray());
        }

        private static void SaveBooks()
        {
            Service.SaveToStorage();
            Console.WriteLine("Books saved successfully");
        }

        private static void PrintBooks(IEnumerable<Book> books)
        {
            var index = 1;

            foreach (var book in books)
            {
                Console.Write(index++);
                Console.Write(". ");
                Console.WriteLine(book.ToString());
            }
        }

        private static int GetInt(string msg)
        {
            int num;
            Console.Write(msg);
            var strNum = Console.ReadLine();
            while (!int.TryParse(strNum, out num))
            {
                Console.Write("Try again: ");
                strNum = Console.ReadLine();
            }

            return num;
        }

        private static string GetString(string msg)
        {
            Console.Write(msg);
            return Console.ReadLine();
        }
    }
}
