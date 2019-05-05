using System;
using System.Collections.Generic;
using System.IO;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    /// <summary>
    /// Repository that can read text file.
    /// </summary>
    public class TextReadableRepository : FileRepository, IReadableRepository<string>
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
        public TextReadableRepository(string filePath) : base(filePath)
        {
        }

        /// <summary>
        /// Gets all strings from file.
        /// </summary>
        /// <returns>All strings.</returns>
        public IEnumerable<string> GetAll()
        {
            using (var reader = new StreamReader(File.OpenRead(this.FilePath)))
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
