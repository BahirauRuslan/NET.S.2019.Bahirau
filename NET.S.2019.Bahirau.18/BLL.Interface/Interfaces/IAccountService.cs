using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        void AddAccount(Holder holder, string type);

        void RemoveAccount(long id);

        void OpenAccount(long id);

        void CloseAccount(long id);

        Account GetAccount(long id);

        void Deposit(long id, decimal money);

        void Withdraw(long id, decimal money);

        IEnumerable<Account> GetAllAccounts();

        void UpdateAll();
    }
}
