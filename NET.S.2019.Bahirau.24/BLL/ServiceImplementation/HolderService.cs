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
    public class HolderService : IHolderService
    {
        private readonly IHolderIdService _holderIdService;
        private readonly IRepository<DTOHolder> _repository;

        public HolderService(IHolderIdService holderIdService, IRepository<DTOHolder> repository)
        {
            _holderIdService = holderIdService ?? throw new ArgumentNullException("Holder id service must not be null");
            _repository = repository ?? throw new ArgumentNullException("Repository must not be null");
            InitAccountIdService();
        }

        public void AddHolder(string name, string surname)
        {
            var id = _holderIdService.GenerateHolderId();
            var holder = new Holder(id, name, surname, new List<long>());
            _repository.Add(holder.ToDTOHolder());
        }

        public IEnumerable<Holder> GetAllHolders()
        {
            return _repository.Items.ToHolders();
        }

        public Holder GetHolder(long id)
        {
            return GetDTOHolder(id).ToHolder();
        }

        public void RemoveHolder(long id)
        {
            _repository.Remove(GetDTOHolder(id));
        }

        public void UpdateAll()
        {
            _repository.Save();
        }

        private DTOHolder GetDTOHolder(long id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Id must be non-negative");
            }

            var holderEnumerable = from item in _repository.Items where item.Id == id select item;
            if (holderEnumerable.Any())
            {
                throw new InvalidOperationException("Holder not found");
            }

            return holderEnumerable.First();
        }

        private void InitAccountIdService()
        {
            if (_repository.Items.Count() > 0)
            {
                _holderIdService.PrimaryNumber = _repository.Items.Max((acc) => acc.Id) + 1;
            }
        }
    }
}
