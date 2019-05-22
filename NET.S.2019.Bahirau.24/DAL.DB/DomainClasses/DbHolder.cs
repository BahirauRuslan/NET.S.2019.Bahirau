using System.Collections.Generic;

namespace DAL.DB.DomainClasses
{
    public class DbHolder
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public IList<DbAccount> Accounts { get; set; }
    }
}