using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public delegate void AccountEvent(Account sender, AccountEventArgs e);

    public class Account : IComparable<Account>, IEquatable<Account>
    {
        private decimal _balance;
        private Holder _holder;
        private Bonus _bonus;

        public Account()
        {
            Id = 0;
            _balance = 0;
            _holder = new Holder();
            AccountType = AccountType.Base;
            _bonus = new Bonus();
            IsEnabled = true;
        }

        public Account(
            long id, decimal balance, Holder holder, AccountType accountType, Bonus bonus, bool isEnabled = true)
        {
            Id = id;
            _balance = balance;
            Holder = holder;
            AccountType = accountType;
            Bonus = bonus;
            IsEnabled = isEnabled;
        }

        public event AccountEvent OnTransaction;

        public long Id { get; set; }

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

        public Holder Holder
        {
            get
            {
                return _holder;
            }

            set
            {
                _holder = value ?? throw new ArgumentNullException("Holder record must not be null");
            }
        }

        public AccountType AccountType { get; set; }

        public Bonus Bonus
        {
            get
            {
                return _bonus;
            }

            set
            {
                _bonus = value ?? throw new ArgumentNullException("Bonus record must not be null");
            }
        }

        public bool IsEnabled { get; set; }

        public int CompareTo(Account other)
        {
            if (other == null)
            {
                return 1;
            }

            return _balance.CompareTo(other._balance);
        }

        public override string ToString()
        {
            return $"Account #{ Id }\n{ _holder }\nBalance: { _balance }$\n" +
                $"Account type: { AccountType }\nIs enabled: { IsEnabled }\n{ _bonus }";
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Account);
        }

        public bool Equals(Account other)
        {
            return other != null &&
                   _balance == other._balance &&
                   EqualityComparer<Holder>.Default.Equals(_holder, other._holder) &&
                   EqualityComparer<Bonus>.Default.Equals(_bonus, other._bonus) &&
                   Id == other.Id &&
                   AccountType == other.AccountType &&
                   IsEnabled == other.IsEnabled;
        }

        public override int GetHashCode()
        {
            var hashCode = 965994417;
            hashCode = (hashCode * -1521134295) + _balance.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<Holder>.Default.GetHashCode(_holder);
            hashCode = (hashCode * -1521134295) + EqualityComparer<Bonus>.Default.GetHashCode(_bonus);
            hashCode = (hashCode * -1521134295) + Id.GetHashCode();
            hashCode = (hashCode * -1521134295) + AccountType.GetHashCode();
            hashCode = (hashCode * -1521134295) + IsEnabled.GetHashCode();
            return hashCode;
        }
    }
}
