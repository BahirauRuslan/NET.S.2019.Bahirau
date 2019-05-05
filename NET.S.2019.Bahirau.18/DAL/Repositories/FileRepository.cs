using System;
using System.IO;

namespace DAL.Repositories
{
    /// <summary>
    /// File repository abstract class.
    /// </summary>
    public abstract class FileRepository
    {
        /// <summary>
        /// Creates FileRepository.
        /// </summary>
        /// <param name="filePath">File path.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when filePath is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when filePath is empty. -or- file doesn't exist.
        /// </exception>
        public FileRepository(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException("File path must not be null");
            }

            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path must not be empty");
            }

            if (!File.Exists(filePath))
            {
                throw new ArgumentException("File does not exist");
            }

            FilePath = filePath;
        }

        /// <summary>
        /// File path.
        /// </summary>
        public string FilePath { get; }
    }
}
