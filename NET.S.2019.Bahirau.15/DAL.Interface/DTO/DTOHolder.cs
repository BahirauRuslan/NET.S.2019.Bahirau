using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DTOHolder
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public IList<DTOAccount> Accounts { get; set; }
    }
}
