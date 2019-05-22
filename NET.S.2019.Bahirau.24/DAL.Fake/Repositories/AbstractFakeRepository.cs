using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface.Interfaces;

namespace DAL.Fake.Repositories
{
    public abstract class AbstractFakeRepository<T> : IRepository<T>
    {
        private readonly IList<T> _items = new List<T>();
        private IList<T> _fakeStorage = new List<T>();

        public IEnumerable<T> Items => _items;

        public IEnumerable<T> FakeStorage => _fakeStorage;

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Remove(T item)
        {
            if (!_items.Contains(item))
            {
                throw new ArgumentException("Item not in storage");
            }

            _items.Remove(item);
        }

        public void Save()
        {
            _fakeStorage = _items.ToList();
        }

        public abstract void Update(T item);
    }
}
