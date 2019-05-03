using System;
using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    [Serializable]
    public class DTOHolder
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public IList<long> Accounts { get; set; }
    }
}
