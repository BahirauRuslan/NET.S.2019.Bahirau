using DAL.Interface.DTO;

namespace DAL.DB.DomainClasses
{
    public class DbAccount
    {
        public long Id { get; set; }

        public decimal Balance { get; set; }

        public DbHolder Holder { get; set; }

        public DTOAccountType AccountType { get; set; }

        public DTOBonus Bonus { get; set; }

        public bool IsEnabled { get; set; }
    }
}