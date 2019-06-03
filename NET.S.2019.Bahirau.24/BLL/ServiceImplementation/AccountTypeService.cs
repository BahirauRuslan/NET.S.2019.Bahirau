using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class AccountTypeService : RepositoryService<AccountType, DTOAccountType>, IAccountTypeService
    {
        public AccountTypeService(IRepository<DTOAccountType> repository) : base(repository)
        {
        }
    }
}
