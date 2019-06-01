using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

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
