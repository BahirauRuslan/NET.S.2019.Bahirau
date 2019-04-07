using System;

namespace BankAccount
{
    public class BaseAccountType : AccountType
    {
        public BaseAccountType()
        {
            this.DifferenceCost = 3;
            this.BalanceCost = 7;
        }

        public override string TypeName
        {
            get
            {
                return "Base";
            }
        }

        public override void ChangeBonus(decimal balanceDifference, decimal balance)
        {
            var differenceBonus = balanceDifference * DifferenceCost;
            var balanceBonus = balance * BalanceCost;
            this.Bonus += (differenceBonus + balanceBonus) 
                * Math.Abs(balanceDifference) / (Math.Abs(balance + balanceDifference) + 1) * 0.01m;
        }
    }
}
