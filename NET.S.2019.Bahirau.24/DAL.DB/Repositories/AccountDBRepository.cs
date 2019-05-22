using System;
using System.Collections.Generic;
using System.Data.Entity;
using DAL.DB.DomainClasses;
using DAL.DB.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.DB.Repositories
{
    public class AccountDBRepository : IRepository<DTOAccount>
    {
        private readonly BankContext _bankContext;

        public AccountDBRepository(BankContext bankContext)
        {
            _bankContext = bankContext ?? throw new ArgumentNullException(nameof(bankContext));
        }

        public IEnumerable<DTOAccount> Items => _bankContext.Accounts.ToDTOAccounts();

        public void Add(DTOAccount item)
        {
            var account = new DbAccount
            {
                Id = item.Id
            };
            var holder = _bankContext.Holders.Find(item.Holder.Id) ?? throw new InvalidOperationException("Holder not found.");
            account = AccountMapper.UpdateDbAccount(item, account, holder);
            _bankContext.Accounts.Add(account);
        }

        public void Remove(DTOAccount item)
        {
            _bankContext.Accounts.Remove(ToDbAccount(item));
        }

        public void Save()
        {
            _bankContext.SaveChanges();
        }

        public void Update(DTOAccount item)
        {
            _bankContext.Entry(ToDbAccount(item)).State = EntityState.Modified;
        }

        private DbAccount ToDbAccount(DTOAccount item)
        {
            var account = _bankContext.Accounts.Find(item.Id) ?? throw new InvalidOperationException("Account not found, incorrect id!");
            var holder = _bankContext.Holders.Find(item.Holder.Id) ?? throw new InvalidOperationException("Holder not found, incorrect id!");
            return AccountMapper.UpdateDbAccount(item, account, holder);
        }
    }
}
