using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.Interface.Entities
{
    [DisplayName("Holder")]
    public class Holder : IEquatable<Holder>
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

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Holder);
        }

        public bool Equals(Holder other)
        {
            return other != null &&
                   Id == other.Id &&
                   Name == other.Name &&
                   Surname == other.Surname;
        }

        public override int GetHashCode()
        {
            var hashCode = -129878884;
            hashCode = (hashCode * -1521134295) + Id.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Surname);
            return hashCode;
        }

        public override string ToString()
        {
            return $"Holder (Id = { Id }, Name = { Name }, Surname = { Surname })";
        }
    }
}
