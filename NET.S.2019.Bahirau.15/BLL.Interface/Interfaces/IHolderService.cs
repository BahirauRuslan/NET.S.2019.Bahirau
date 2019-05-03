using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IHolderService
    {
        void AddHolder(string name, string surname);

        void RemoveHolder(long id);

        Holder GetHolder(long id);

        IEnumerable<Holder> GetAllHolders();

        void UpdateAll();
    }
}
