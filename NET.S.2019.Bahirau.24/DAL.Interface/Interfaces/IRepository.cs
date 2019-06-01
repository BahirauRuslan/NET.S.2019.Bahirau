using System.Collections.Generic;

namespace DAL.Interface.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> Items { get; }

        T Get(long id);

        void Add(T item);

        void Remove(T item);

        void Update(T item);

        void Save();
    }
}
