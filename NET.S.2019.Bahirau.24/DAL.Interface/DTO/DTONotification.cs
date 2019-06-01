using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Interface.DTO
{
    [Serializable]
    public class DTONotification
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Content { get; set; }

        public DTOHolder Holder { get; set; }
    }
}
