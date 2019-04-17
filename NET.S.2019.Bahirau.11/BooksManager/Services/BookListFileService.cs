using System.IO;

namespace BooksManager.Services
{
    /// <summary>
    /// The BookListFileService class.
    /// Book service that uses a binary file as storage
    /// </summary>
    public class BookListFileService : BookListService
    {
        /// <summary>
        /// The path to the file
        /// </summary>
        public string FilePath { get; set; } = "BookStorage.bklib";

        /// <summary>
        /// Load books from binary file
        /// </summary>
        public override void LoadFromStorage()
        {
            using (BinaryReader reader = new BinaryReader(File.Open(this.FilePath, FileMode.OpenOrCreate)))
            {
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
            }
        }

        /// <summary>
        /// Saves books to a binary file
        /// </summary>
        public override void SaveToStorage()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(this.FilePath, FileMode.OpenOrCreate)))
            {
                foreach (Book book in this.ToBookArray())
                {
                    writer.Write(book.ISBN);
                    writer.Write(book.Author);
                    writer.Write(book.Title);
                    writer.Write(book.Publisher);
                    writer.Write(book.PublishingYear);
                    writer.Write(book.PagesCount);
                }
            }
        }
    }
}
