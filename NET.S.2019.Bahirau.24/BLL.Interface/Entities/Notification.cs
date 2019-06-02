using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.Interface.Entities
{
    [DisplayName("Notification")]
    public class Notification
    {
        [Range(0, long.MaxValue)]
        public long Id { get; set; }

        [DisplayName("Content")]
        [StringLength(5000, MinimumLength = 1)]
        public string Content { get; set; }

        [Required]
        [DisplayName("Holder")]
        public Holder Holder { get; set; }
    }
}
