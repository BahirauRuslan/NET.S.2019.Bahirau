using System.Data.Entity;
using DAL.Interface.DTO;

namespace DAL.DB
{
    public class BankContext : DbContext
    {
        public BankContext() : base("BankDB")
        {
        }

        public DbSet<DTOAccount> Accounts { get; set; }

        public DbSet<DTOAccountType> AccountTypes { get; set; }

        public DbSet<DTOHolder> Holders { get; set; }

        public DbSet<DTONotification> Notifications { get; set; }
    }
}
