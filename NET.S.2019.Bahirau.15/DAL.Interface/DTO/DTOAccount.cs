using System;

namespace DAL.Interface.DTO
{
    [Serializable]
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
