using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class AccountService : IAccountService
    {
        private readonly IAccountIdService _accountIdService;
        private readonly IRepository<DTOAccount> _repository;

        public AccountService(IAccountIdService accountIdService, IRepository<DTOAccount> repository)
        {
            _accountIdService = accountIdService ?? throw new ArgumentNullException("Account id service must not be null");
            _repository = repository ?? throw new ArgumentNullException("Repository must not be null");
            InitAccountIdService();
        }

        public void AddAccount(Holder holder, string type)
        {
            var id = _accountIdService.GenerateAccountId();
            var accountType = AccountTypeMapper.GetAccountType(type);
            var account = new Account(id, 0, holder, accountType, new Bonus());
            _repository.Add(account.ToDTOAccount());
            holder.Accounts.Add(id);
        }

        public void CloseAccount(long id)
        {
            var account = GetAccount(id);
            account.IsEnabled = false;
        }

        public void Deposit(long id, decimal money)
        {
            ValidateMoney(money);
            var account = GetAccount(id);

            if (account.IsEnabled)
            {
                account.Balance += money;
            }
        }

        public Account GetAccount(long id)
        {
            return GetDTOAccount(id).ToAccount();
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _repository.Items.ToAccounts();
        }

        public void OpenAccount(long id)
        {
            var account = GetAccount(id);
            account.IsEnabled = true;
        }

        public void RemoveAccount(long id)
        {
            _repository.Remove(GetDTOAccount(id));
        }

        public void UpdateAll()
        {
            _repository.Save();
        }

        public void Withdraw(long id, decimal money)
        {
            ValidateMoney(money);
            var account = GetAccount(id);

            if (account.IsEnabled)
            {
                account.Balance -= money;
            }
        }

        private DTOAccount GetDTOAccount(long id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Id must be non-negative");
            }

            var accountEnumerable = from item in _repository.Items where item.Id == id select item;
            if (accountEnumerable.Any())
            {
                throw new InvalidOperationException("Account not found");
            }

            return accountEnumerable.First();
        }

        private void ValidateMoney(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentException("Money must be non-negative");
            }
        }

        private void InitAccountIdService()
        {
            if (_repository.Items.Count() > 0)
            {
                _accountIdService.PrimaryNumber = _repository.Items.Max((acc) => acc.Id) + 1;
            }
        }
    }
}
