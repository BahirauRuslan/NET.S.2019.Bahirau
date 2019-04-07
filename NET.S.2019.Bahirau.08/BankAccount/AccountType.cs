using System;

namespace BankAccount
{
    /// <summary>
    /// The AccountType class
    /// </summary>
    public abstract class AccountType
    {
        /// <summary>
        /// Cost of balance difference
        /// </summary>
        protected readonly int DifferenceCost;

        /// <summary>
        /// Cost of balance
        /// </summary>
        protected readonly int BalanceCost;

        /// <summary>
        /// Bonus points
        /// </summary>
        private decimal _bonus = 0m;

        /// <summary>
        /// Bonus points
        /// </summary>
        public decimal Bonus
        {
            get
            {
                return _bonus;
            }

            private set
            {
                _bonus = (value > 0) ? value : 0;
            }
        }

        /// <summary>
        /// Name of account type
        /// </summary>
        public abstract string TypeName { get; }

        /// <summary>
        /// Change bonus
        /// </summary>
        /// <param name="balanceDifference">Balance difference</param>
        /// <param name="balance">Account balance</param>
        /// <param name="func">Function that get the change in bonus points</param>
        public void ChangeBonus(
            decimal balanceDifference, decimal balance, Func<decimal, decimal, int, int, decimal> func)
        {
            Bonus += func(balanceDifference, balance, DifferenceCost, BalanceCost);
        }

        /// <summary>
        /// Change bonus
        /// </summary>
        /// <param name="balanceDifference">Balance difference</param>
        /// <param name="balance">Account balance</param>
        /// <param name="calculator">Calculator that get the change in bonus points</param>
        public void ChangeBonus(decimal balanceDifference, decimal balance, IBonusCalculator calculator)
        {
            Bonus += calculator.GetBonusDifference(balanceDifference, balance, DifferenceCost, BalanceCost);
        }

        /// <summary>
        /// Change bonus
        /// </summary>
        /// <param name="balanceDifference">Balance difference</param>
        /// <param name="balance">Account balance</param>
        public abstract void ChangeBonus(decimal balanceDifference, decimal balance);
    }
}
