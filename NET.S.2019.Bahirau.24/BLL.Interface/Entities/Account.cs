using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.Interface.Entities
{
    public delegate void AccountEvent(Account sender, AccountEventArgs e);

    [DisplayName("Account")]
    public class Account
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
    }
}
