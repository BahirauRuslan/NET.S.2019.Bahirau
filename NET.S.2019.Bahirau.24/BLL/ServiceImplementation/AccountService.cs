using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class AccountService : RepositoryService<Account, DTOAccount>, IAccountService
    {
        public AccountService(IRepository<DTOAccount> repository) : base(repository)
        {
        }

        public void Deposit(Account account, decimal money)
        {
            this.CheckItem(account);
            if (account.IsEnabled)
            {
                account.Balance += money;
            }
        }

        public void SetEnabled(Account account, bool enabled)
        {
            this.CheckItem(account);
            account.IsEnabled = enabled;
        }

        public void Transfer(Account sender, Account receiver, decimal money)
        {
            this.CheckItem(sender);
            this.CheckItem(receiver);
            if (sender.IsEnabled && receiver.IsEnabled)
            {
                sender.Balance -= money;
                receiver.Balance += money;
            }
        }

        public void Withdraw(Account account, decimal money)
        {
            this.CheckItem(account);
            if (account.IsEnabled)
            {
                account.Balance -= money;
            }
        }
    }
}
