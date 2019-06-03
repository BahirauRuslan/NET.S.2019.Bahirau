using System.Data.Entity;
using DAL.Interface.DTO;

namespace DAL.DB.Repositories
{
    public class HolderDBRepository : DBRepository<DTOHolder>
    {
        public HolderDBRepository(BankContext bankContext) : base(bankContext)
        {
        }

        protected override DbSet<DTOHolder> ThisSet => BankContext.Holders;
    }
}
