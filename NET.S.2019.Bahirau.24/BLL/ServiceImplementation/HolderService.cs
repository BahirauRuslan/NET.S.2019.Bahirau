using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class HolderService : RepositoryService<Holder, DTOHolder>, IHolderService
    {
        public HolderService(IRepository<DTOHolder> repository) : base(repository)
        {
        }
    }
}
