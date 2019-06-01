using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Interfaces
{
    public interface ICRUDService<T>
    {
        void Add(T item);

        T Get(long id);

        void Update(T item);

        void Remove(T item);

        IEnumerable<T> GetAll();
    }
}
