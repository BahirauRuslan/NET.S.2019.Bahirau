using System.Collections.Generic;

namespace DAL.Interface.Interfaces
{
    /// <summary>
    /// Repository that can read entities.
    /// </summary>
    /// <typeparam name="T">Type of entities.</typeparam>
    public interface IReadableRepository<T>
    {
        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>All entities.</returns>
        IEnumerable<T> GetAll();
    }
}
