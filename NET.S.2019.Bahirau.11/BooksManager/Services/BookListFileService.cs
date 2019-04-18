using System.IO;

namespace BooksManager.Services
{
    /// <summary>
    /// The BookListFileService class.
    /// Book service that uses a binary file as storage.
    /// </summary>
    public class BookListFileService : BookListService
    {
        /// <summary>
        /// The path to the file.
        /// </summary>
        public string FilePath { get; set; } = "BookStorage.bklib";

        /// <summary>
        /// Load books from binary file.
        /// </summary>
        public override void LoadFromStorage()
        {
            Logger.Log(1, "Try to open or create the file " + this.FilePath);
            using (BinaryReader reader = new BinaryReader(File.Open(this.FilePath, FileMode.OpenOrCreate)))
            {
                Logger.Log(1, "Begin reading books from file " + this.FilePath);
                while (reader.PeekChar() > -1)
                {
                    Book book = new Book
                    {
                        ISBN = reader.ReadString(),
                        Author = reader.ReadString(),
                        Title = reader.ReadString(),
                        Publisher = reader.ReadString(),
                        PublishingYear = reader.ReadInt32(),
                        PagesCount = reader.ReadInt32()
                    };
                    this.AddBook(book);
                }

                Logger.Log(1, "End reading books from file " + this.FilePath);
            }
        }

        /// <summary>
        /// Saves books to a binary file.
        /// </summary>
        public override void SaveToStorage()
        {
            Logger.Log(1, "Try to open or create the file " + this.FilePath);
            using (BinaryWriter writer = new BinaryWriter(File.Open(this.FilePath, FileMode.OpenOrCreate)))
            {
                Logger.Log(1, "Begin writing books to file " + this.FilePath);
                foreach (Book book in this.ToBookArray())
                {
                    Logger.Log(1, string.Format("Begin writing book {0} to file {1}", book, this.FilePath));
                    writer.Write(book.ISBN);
                    writer.Write(book.Author);
                    writer.Write(book.Title);
                    writer.Write(book.Publisher);
                    writer.Write(book.PublishingYear);
                    writer.Write(book.PagesCount);
                    Logger.Log(1, string.Format("End writing book {0} to file {1}", book, this.FilePath));
                }

                Logger.Log(1, "End writing books to file " + this.FilePath);
            }
        }
    }
}
