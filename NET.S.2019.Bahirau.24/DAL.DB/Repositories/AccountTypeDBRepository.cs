using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

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
