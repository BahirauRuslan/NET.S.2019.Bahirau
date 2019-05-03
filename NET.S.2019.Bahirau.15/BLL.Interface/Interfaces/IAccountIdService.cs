using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountIdService
    {
        long GenerateAccountId(Holder holder);
    }
}
