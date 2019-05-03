using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        void AddAccount(Holder holder, AccountType type);

        void RemoveAccount(long id);

        void OpenAccount(long id);

        void CloseAccount(long id);

        Account GetAccount(long id);

        IEnumerable<Account> GetAllAccounts();

        void UpdateAll();
    }
}
