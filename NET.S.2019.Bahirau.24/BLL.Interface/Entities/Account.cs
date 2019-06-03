using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.Interface.Entities
{
    public delegate void AccountEvent(Account sender, AccountEventArgs e);

    [DisplayName("Account")]
    public class Account : IEquatable<Account>
    {
        private decimal _balance;

        public event AccountEvent OnTransaction;

        [Range(0, long.MaxValue)]
        public long Id { get; set; }

        [Required]
        public bool IsEnabled { get; set; }

        [DisplayName("Balance")]
        public decimal Balance
        {
            get
            {
                return _balance;
            }

            set
            {
                OnTransaction?.Invoke(this, new AccountEventArgs(_balance, value));
                _balance = value;
            }
        }

        [DisplayName("Account type")]
        [Required]
        public AccountType AccountType { get; set; }

        [DisplayName("Holder")]
        [Required]
        public Holder Holder { get; set; }

        [DisplayName("Bonus")]
        public Bonus Bonus { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Account);
        }

        public bool Equals(Account other)
        {
            return other != null &&
                   _balance == other._balance &&
                   Id == other.Id &&
                   IsEnabled == other.IsEnabled &&
                   EqualityComparer<AccountType>.Default.Equals(AccountType, other.AccountType) &&
                   EqualityComparer<Holder>.Default.Equals(Holder, other.Holder) &&
                   EqualityComparer<Bonus>.Default.Equals(Bonus, other.Bonus);
        }

        public override int GetHashCode()
        {
            var hashCode = 93277711;
            hashCode = (hashCode * -1521134295) + _balance.GetHashCode();
            hashCode = (hashCode * -1521134295) + Id.GetHashCode();
            hashCode = (hashCode * -1521134295) + IsEnabled.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<AccountType>.Default.GetHashCode(AccountType);
            hashCode = (hashCode * -1521134295) + EqualityComparer<Holder>.Default.GetHashCode(Holder);
            hashCode = (hashCode * -1521134295) + EqualityComparer<Bonus>.Default.GetHashCode(Bonus);
            return hashCode;
        }

        public override string ToString()
        {
            return $"Account (Id = { Id }, IsEnabled = { IsEnabled }, Balance = { Balance }, " +
                $"AccountType = { AccountType }), Holder = { Holder }, Bonus = { Bonus }";
        }
    }
}
