using System.Data.Entity;
using DAL.Interface.DTO;

namespace DAL.DB.Repositories
{
    public class AccountTypeDBRepository : DBRepository<DTOAccountType>
    {
        public AccountTypeDBRepository(BankContext bankContext) : base(bankContext)
        {
        }

        protected override DbSet<DTOAccountType> ThisSet => BankContext.AccountTypes;
    }
}
