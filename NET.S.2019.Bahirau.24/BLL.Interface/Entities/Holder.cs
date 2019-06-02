using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.Interface.Entities
{
    [DisplayName("Holder")]
    public class Holder
    {
        [Range(0, long.MaxValue)]
        public long Id { get; set; }

        [Required]
        [DisplayName("Name")]
        [StringLength(35, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Surname")]
        [StringLength(35, MinimumLength = 2)]
        public string Surname { get; set; }

        public IList<Account> Accounts { get; set; }

        public IList<Notification> Notifications { get; set; }
    }
}
