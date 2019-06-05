using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Interface.Interfaces;

namespace DAL.Interface.DTO
{
    [Serializable]
    public class DTOAccountType : IUniqueEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string TypeName { get; set; }

        public int TypeValue { get; set; }

        public IList<DTOAccount> Accounts { get; set; }
    }
}
