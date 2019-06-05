using System;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Interface.Interfaces;

namespace DAL.Interface.DTO
{
    [Serializable]
    public class DTONotification : IUniqueEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Content { get; set; }

        public DTOHolder Holder { get; set; }
    }
}
