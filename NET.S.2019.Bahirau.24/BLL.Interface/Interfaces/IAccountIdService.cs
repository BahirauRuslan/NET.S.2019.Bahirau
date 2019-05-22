using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountIdService
    {
        long PrimaryNumber { get; set; }

        long GenerateAccountId();
    }
}
