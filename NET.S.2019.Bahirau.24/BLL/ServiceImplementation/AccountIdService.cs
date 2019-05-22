using BLL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class AccountIdService : IAccountIdService
    {
        public long PrimaryNumber { get; set; } = 1;

        public long GenerateAccountId()
        {
            return PrimaryNumber++;
        }
    }
}
