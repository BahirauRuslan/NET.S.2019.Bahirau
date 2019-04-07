using System;
using System.Collections.Generic;

namespace BankAccount
{
    /// <summary>
    /// The Account class.
    /// Describes a bank account
    /// </summary>
    [Serializable]
    public class Account : IEquatable<Account>, IComparable<Account>
    {
        /// <summary>
        /// Balance identification number
        /// </summary>
        private long _id;

        /// <summary>
        /// User's first name
        /// </summary>
        private string _firstName = string.Empty;

        /// <summary>
        /// User's last name
        /// </summary>
        private string _lastName = string.Empty;

        /// <summary>
        /// Type of account
        /// </summary>
        private AccountType _accountType = new BaseAccountType();

        /// <summary>
        /// Account balance
        /// </summary>
        public decimal Balance { get; private set; }

        /// <summary>
        /// Account enabled
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Balance identification number
        /// </summary>
        public long Id
        {
            get
            {
                return _id;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id must be positive");
                }

                _id = value;
            }
        }

        /// <summary>
        /// User's first name
        /// </summary>
        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                _firstName = value ?? throw new ArgumentNullException("First name must not be null");
            }
        }

        /// <summary>
        /// User's last name
        /// </summary>
        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value ?? throw new ArgumentNullException("Last name must not be null");
            }
        }

        /// <summary>
        /// Type of account
        /// </summary>
        public AccountType AccountType
        {
            get
            {
                return _accountType;
            }

            set
            {
                _accountType = value ?? throw new ArgumentNullException("Account type must not be null");
            }
        }

        /// <summary>
        /// Withdraws money from balance
        /// </summary>
        /// <param name="amount">Amount</param>
        public void WithdrawMoney(decimal amount)
        {
            Balance -= amount;
        }

        /// <summary>
        /// Deposit money to balance
        /// </summary>
        /// <param name="amount">Amount</param>
        public void DepositMoney(decimal amount)
        {
            Balance += amount;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Account);
        }

        public bool Equals(Account other)
        {
            return other != null &&
                   _id == other._id &&
                   _firstName == other._firstName &&
                   _lastName == other._lastName &&
                   EqualityComparer<AccountType>.Default.Equals(_accountType, other._accountType) &&
                   Balance == other.Balance;
        }

        public override int GetHashCode()
        {
            var hashCode = 1910998087;
            hashCode = (hashCode * -1521134295) + _id.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(_firstName);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(_lastName);
            hashCode = (hashCode * -1521134295) + EqualityComparer<AccountType>.Default.GetHashCode(_accountType);
            hashCode = (hashCode * -1521134295) + Balance.GetHashCode();
            return hashCode;
        }

        public int CompareTo(Account other)
        {
            if (other == null)
            {
                return 1;
            }

            return Balance.CompareTo(other.Balance);
        }

        public override string ToString()
        {
            return string.Format(
                "Account:\nStatus enabled: {0}\nId: {1}\nFirst name: {2}\nLast name: {3}\nBalance: {4}\n{5}",
                IsEnabled,
                _id, 
                _firstName, 
                _lastName, 
                Balance, 
                _accountType);
        }
    }
}
