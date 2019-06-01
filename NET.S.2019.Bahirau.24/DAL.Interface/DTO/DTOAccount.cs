using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Interface.DTO
{
    [Serializable]
    public class DTOAccount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public bool IsEnabled { get; set; }

        public decimal Balance { get; set; }

        public DTOAccountType AccountType { get; set; }

        public DTOHolder Holder { get; set; }

        public DTOBonus Bonus { get; set; }
    }
}
