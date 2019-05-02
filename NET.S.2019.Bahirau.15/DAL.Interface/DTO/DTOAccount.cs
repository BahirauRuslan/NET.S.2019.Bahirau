using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DTOAccount
    {
        public long Id { get; set; }

        public decimal Balance { get; set; }

        public DTOHolder Holder { get; set; }

        public DTOAccountType AccountType { get; set; }

        public DTOBonus Bonus { get; set; }

        public bool IsEnabled { get; set; }
    }
}
