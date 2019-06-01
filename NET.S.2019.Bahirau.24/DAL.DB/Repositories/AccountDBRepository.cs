using System;
using System.Collections.Generic;
using System.Data.Entity;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

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
