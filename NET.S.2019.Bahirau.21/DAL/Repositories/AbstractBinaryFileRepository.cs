using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    public abstract class AbstractBinaryFileRepository<T> : IRepository<T>
    {
        private readonly string _filePath;
        private IList<T> _items = new List<T>();

        public AbstractBinaryFileRepository(string filePath)
        {
            _filePath = filePath;
            if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)
            {
                Load();
            }
        }

        public IEnumerable<T> Items => _items;

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
            var formatter = new BinaryFormatter();
            using (var stream = new FileStream(_filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream, _items);
            }
        }

        public abstract void Update(T item);

        private void Load()
        {
            var formatter = new BinaryFormatter();
            using (var stream = new FileStream(_filePath, FileMode.OpenOrCreate))
            {
                _items = (IList<T>)formatter.Deserialize(stream);
            }
        }
    }
}
