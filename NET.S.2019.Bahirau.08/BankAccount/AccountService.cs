using System;
using System.Collections.Generic;

namespace BankAccount
{
    /// <summary>
    /// The AccountService abstract class
    /// </summary>
    public abstract class AccountService
    {
        /// <summary>
        /// List with bank accounts
        /// </summary>
        private List<Account> _buffer = new List<Account>();

        /// <summary>
        /// Withdraw money from balance and change bonus points
        /// </summary>
        /// <param name="account">Account</param>
        /// <param name="amount">Amount</param>
        /// <returns>Operation successfully completed</returns>
        public bool Withdraw(Account account, decimal amount)
        {
            if (account.IsEnabled)
            {
                account.WithdrawMoney(amount);
                account.AccountType.ChangeBonus(-amount, account.Balance);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Withdraw money from balance and change bonus points
        /// </summary>
        /// <param name="account">Account</param>
        /// <param name="amount">Amount</param>
        /// <returns>Operation successfully completed</returns>
        public bool Deposit(Account account, decimal amount)
        {
            if (account.IsEnabled)
            {
                account.DepositMoney(amount);
                account.AccountType.ChangeBonus(amount, account.Balance);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Add account to buffer
        /// </summary>
        /// <param name="account">Account</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the account is already in the buffer
        /// </exception>
        public void AddAccount(Account account)
        {
            if (Contains(account))
            {
                throw new ArgumentException("This account is already in buffer");
            }

            _buffer.Add(account);
        }

        /// <summary>
        /// Remove account from buffer
        /// </summary>
        /// <param name="account">Account</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the account is not in the buffer
        /// </exception>
        public void RemoveAccount(Account account)
        {
            if (!Contains(account))
            {
                throw new ArgumentException("This account is not in buffer");
            }

            _buffer.Remove(account);
        }

        /// <summary>
        /// Close account
        /// </summary>
        /// <param name="account">Account</param>
        public void CloseAccount(Account account)
        {
            account.IsEnabled = false;
        }

        /// <summary>
        /// Make account enable
        /// </summary>
        /// <param name="account">Account</param>
        public void OpenAccount(Account account)
        {
            account.IsEnabled = true;
        }

        /// <summary>
        /// Sorts accounts in buffer by balance
        /// </summary>
        public void SortByBalance()
        {
            _buffer.Sort();
        }

        /// <summary>
        /// Finds an account by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Account or null</returns>
        public Account FindById(long id)
        {
            return _buffer.Find((Account a) => a.Id == id);
        }

        /// <summary>
        /// Indicates that book buffer contains the book
        /// </summary>
        /// <param name="account">Book</param>
        /// <returns>true when buffer contains the book, else - false</returns>
        public bool Contains(Account account)
        {
            return _buffer.Contains(account);
        }

        /// <summary>
        /// Get the array of accounts than in the account buffer
        /// </summary>
        /// <returns>Array of accounts</returns>
        public Account[] ToAccountArray()
        {
            return _buffer.ToArray();
        }

        /// <summary>
        /// Load accounts from storage to account buffer
        /// </summary>
        public abstract void LoadFromStorage();

        /// <summary>
        /// Save accounts from account buffer to storage
        /// </summary>
        public abstract void SaveToStorage();
    }
}
