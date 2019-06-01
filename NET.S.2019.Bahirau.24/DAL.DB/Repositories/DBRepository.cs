using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.DB.Repositories
{
    public abstract class DBRepository<T> : IRepository<T> where T : class
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
            ThisSet.Remove(item);
        }

        public void Update(T item)
        {
            CheckArgument(item);
            BankContext.Entry(item).State = EntityState.Modified;
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
