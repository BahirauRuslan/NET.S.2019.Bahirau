using System.Collections.Generic;

namespace DAL.Interface.Interfaces
{
    /// <summary>
    /// Repository that can read entities.
    /// </summary>
    /// <typeparam name="T">Type of entities.</typeparam>
    public interface IWriteableRepository<T>
    {
        /// <summary>
        /// Write all entities.
        /// </summary>
        /// <param name="items">Entities.</param>
        void WriteAll(IEnumerable<T> items);
    }
}
