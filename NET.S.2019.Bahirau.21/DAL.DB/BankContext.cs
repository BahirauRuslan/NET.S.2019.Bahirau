using System.Data.Entity;
using DAL.DB.DomainClasses;

namespace DAL.DB
{
    public class BankContext : DbContext
    {
        public BankContext() : base("BankDB")
        {
        }

        public DbSet<DbAccount> Accounts { get; set; }

        public DbSet<DbHolder> Holders { get; set; }
    }
}
