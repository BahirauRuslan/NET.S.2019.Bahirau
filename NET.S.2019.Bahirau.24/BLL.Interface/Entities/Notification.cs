using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.Interface.Entities
{
    [DisplayName("Notification")]
    public class Notification : IEquatable<Notification>
    {
        [Range(0, long.MaxValue)]
        public long Id { get; set; }

        [DisplayName("Content")]
        [StringLength(5000, MinimumLength = 1)]
        public string Content { get; set; }

        [Required]
        [DisplayName("Holder")]
        public Holder Holder { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Notification);
        }

        public bool Equals(Notification other)
        {
            return other != null &&
                   Id == other.Id &&
                   Content == other.Content &&
                   EqualityComparer<Holder>.Default.Equals(Holder, other.Holder);
        }

        public override int GetHashCode()
        {
            var hashCode = 2020934497;
            hashCode = (hashCode * -1521134295) + Id.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Content);
            hashCode = (hashCode * -1521134295) + EqualityComparer<Holder>.Default.GetHashCode(Holder);
            return hashCode;
        }

        public override string ToString()
        {
            return $"Notification (Id = { Id }, Content = { Content }, Holder = { Holder })";
        }
    }
}
