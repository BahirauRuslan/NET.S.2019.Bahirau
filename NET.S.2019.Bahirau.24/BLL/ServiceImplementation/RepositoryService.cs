using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class RepositoryService<T, DTOT> : ICRUDService<T>, IUptatable where DTOT : class where T : class
    {
        public RepositoryService(IRepository<DTOT> repository)
        {
            Repository = repository ?? throw new ArgumentNullException("Repository must not be null");
        }

        public IRepository<DTOT> Repository { get; }

        public void Add(T item)
        {
            CheckItem(item);
            Repository.Add(Map<T, DTOT>(item));
        }

        public T Get(long id)
        {
            return Map<DTOT, T>(Repository.Get(id));
        }

        public IEnumerable<T> GetAll()
        {
            return Map<IEnumerable<DTOT>, IEnumerable<T>>(Repository.Items);
        }

        public IEnumerable<T> GetBy(Func<T, bool> predicate)
        {
            var items = GetAll();
            return items?.Select(item => item).Where(predicate);
        }

        public void Remove(T item)
        {
            CheckItem(item);
            Repository.Remove(Map<T, DTOT>(item));
        }

        public void Update(T item)
        {
            CheckItem(item);
            Repository.Update(Map<T, DTOT>(item));
        }

        public void UpdateAll()
        {
            Repository.Save();
        }

        protected Tout Map<Tin, Tout>(Tin item)
        {
            return Mapper.Map<Tin, Tout>(item);
        }

        protected void CheckItem(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException("Item must not be null");
            }
        }
    }
}
