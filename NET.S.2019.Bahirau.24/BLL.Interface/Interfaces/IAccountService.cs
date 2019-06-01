using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService : ICRUDService<Account>, IUptatable
    {
        void SetEnabled(Account account, bool enabled);

        void Deposit(Account account, decimal money);

        void Withdraw(Account account, decimal money);

        void Transfer(Account sender, Account receiver, decimal money);
    }
}
