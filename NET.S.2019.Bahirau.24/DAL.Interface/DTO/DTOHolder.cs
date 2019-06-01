using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Interface.DTO
{
    [Serializable]
    public class DTOHolder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public IList<DTOAccount> Accounts { get; set; }

        public IList<DTONotification> Notifications { get; set; }
    }
}
