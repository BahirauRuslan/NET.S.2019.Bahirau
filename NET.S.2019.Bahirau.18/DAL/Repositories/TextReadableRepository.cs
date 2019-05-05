using System;
using System.Collections.Generic;
using System.IO;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    /// <summary>
    /// Repository that can read text file.
    /// </summary>
    public class TextReadableRepository : IReadableRepository<string>
    {
        /// <summary>
        /// File path.
        /// </summary>
        private readonly string _filePath;

        /// <summary>
        /// Creates TextReadableRepository.
        /// </summary>
        /// <param name="filePath">File path.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when filePath is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when filePath is empty. -or- file doesn't exist.
        /// </exception>
        public TextReadableRepository(string filePath)
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

            _filePath = filePath;
        }

        /// <summary>
        /// Gets all strings from file.
        /// </summary>
        /// <returns>All strings.</returns>
        public IEnumerable<string> GetAll()
        {
            using (var reader = new StreamReader(File.OpenRead(this._filePath)))
            {
                string uri;
                while ((uri = reader.ReadLine()) != null)
                {
                    yield return uri;
                }
            }
        }
    }
}
