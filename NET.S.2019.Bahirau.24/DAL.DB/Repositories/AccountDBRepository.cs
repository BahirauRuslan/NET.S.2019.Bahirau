using System.Data.Entity;
using DAL.Interface.DTO;

namespace DAL.DB.Repositories
{
    public class AccountDBRepository : DBRepository<DTOAccount>
    {
        public AccountDBRepository(BankContext bankContext) : base(bankContext)
        {
        }

        protected override DbSet<DTOAccount> ThisSet => BankContext.Accounts;
    }
}
