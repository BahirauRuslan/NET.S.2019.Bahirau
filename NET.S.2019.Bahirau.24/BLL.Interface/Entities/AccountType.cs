using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.Interface.Entities
{
    [DisplayName("Account type")]
    public class AccountType : IEquatable<AccountType>
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

        public override bool Equals(object obj)
        {
            return this.Equals(obj as AccountType);
        }

        public bool Equals(AccountType other)
        {
            return other != null &&
                   Id == other.Id &&
                   TypeName == other.TypeName &&
                   TypeValue == other.TypeValue;
        }

        public override int GetHashCode()
        {
            var hashCode = -7176464;
            hashCode = (hashCode * -1521134295) + Id.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(TypeName);
            hashCode = (hashCode * -1521134295) + TypeValue.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"AccountType (Id = { Id }, TypeName = { TypeName }, TypeValue = { TypeValue })";
        }
    }
}
