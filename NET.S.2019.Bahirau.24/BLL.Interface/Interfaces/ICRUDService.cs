using System;
using System.Collections.Generic;

namespace BLL.Interface.Interfaces
{
    public interface ICRUDService<T>
    {
        void Add(T item);

        T Get(long id);

        void Update(T item);

        void Remove(T item);

        IEnumerable<T> GetBy(Func<T, bool> predicate);

        IEnumerable<T> GetAll();
    }
}
