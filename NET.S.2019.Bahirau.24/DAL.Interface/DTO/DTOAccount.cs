using System;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Interface.Interfaces;

namespace DAL.Interface.DTO
{
    [Serializable]
    public class DTOAccount : IUniqueEntity
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
