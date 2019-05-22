using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.DB.DomainClasses;
using DAL.DB.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.DB.Repositories
{
    public class HolderDBRepository : IRepository<DTOHolder>
    {
        private readonly BankContext _bankContext;

        public HolderDBRepository(BankContext bankContext)
        {
            _bankContext = bankContext ?? throw new ArgumentNullException(nameof(bankContext));
        }

        public IEnumerable<DTOHolder> Items => _bankContext.Holders.ToDTOHolders();

        public void Add(DTOHolder item)
        {
            var holder = new DbHolder
            {
                Id = item.Id
            };
            var accounts = ToAccounts(item.Accounts);
            holder = HolderMapper.UpdateDbHolder(item, holder, accounts);
            _bankContext.Holders.Add(holder);
        }

        public void Remove(DTOHolder item)
        {
            _bankContext.Holders.Remove(ToDbHolder(item));
        }

        public void Save()
        {
            _bankContext.SaveChanges();
        }

        public void Update(DTOHolder item)
        {
            _bankContext.Entry(ToDbHolder(item)).State = EntityState.Modified;
        }

        private DbHolder ToDbHolder(DTOHolder item)
        {
            var holder = _bankContext.Holders.Find(item.Id) ?? throw new InvalidOperationException("Holder not found, incorrect id!");
            var accounts = ToAccounts(item.Accounts);
            return HolderMapper.UpdateDbHolder(item, holder, accounts);
        }

        private IList<DbAccount> ToAccounts(IList<long> ids)
        {
            var list = new List<DbAccount>();
            foreach (var id in ids)
            {
                var acc = _bankContext.Accounts.Find(id) ?? throw new InvalidOperationException("Account not found, incorrect id!");
                list.Add(acc);
            }

            return list;
        }
    }
}
