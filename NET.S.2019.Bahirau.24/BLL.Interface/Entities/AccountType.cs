using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.Interface.Entities
{
    [DisplayName("Account type")]
    public class AccountType
    {
        [Range(0, long.MaxValue)]
        public long Id { get; set; }

        [Required]
        [DisplayName("Type name")]
        [StringLength(35, MinimumLength = 2)]
        public string TypeName { get; set; }

        [Required]
        [DisplayName("Value")]
        [Range(1, int.MaxValue)]
        public int TypeValue { get; set; }

        public IList<Account> Accounts { get; set; }
    }
}
