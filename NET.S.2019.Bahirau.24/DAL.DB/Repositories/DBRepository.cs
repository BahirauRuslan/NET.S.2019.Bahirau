using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Utilities;
using System.Data.Entity.Migrations;
using DAL.Interface.Interfaces;

namespace DAL.DB.Repositories
{
    public abstract class DBRepository<T> : IRepository<T> where T : class, IUniqueEntity
    {
        public DBRepository(BankContext bankContext)
        {
            BankContext = bankContext ?? throw new ArgumentNullException("Bank context must not be null");
        }

        public BankContext BankContext { get; }

        public IEnumerable<T> Items
        {
            get
            {
                return ThisSet;
            }
        }

        protected abstract DbSet<T> ThisSet { get; }

        public void Add(T item)
        {
            CheckArgument(item);
            ThisSet.Add(item);
        }

        public T Get(long id)
        {
            var item = ThisSet.Find(id);

            if (item is null)
            {
                throw new ArgumentException("Item not found");
            }

            return item;
        }

        public void Remove(T item)
        {
            CheckArgument(item);
            ThisSet.Remove(ThisSet.Find(item.Id));
        }

        public void Update(T item)
        {
            CheckArgument(item);
            ThisSet.AddOrUpdate(item);
        }

        public void Save()
        {
            BankContext.SaveChanges();
        }

        private void CheckArgument(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException("Item must not be null");
            }
        }
    }
}
