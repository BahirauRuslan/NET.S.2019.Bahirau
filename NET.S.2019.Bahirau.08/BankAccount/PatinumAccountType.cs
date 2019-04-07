using System;

namespace BankAccount
{
    [Serializable]
    public class PatinumAccountType : AccountType
    {
        public PatinumAccountType()
        {
            this.DifferenceCost = 21;
            this.BalanceCost = 33;
        }

        public override string TypeName
        {
            get
            {
                return "Platinum";
            }
        }

        public override void ChangeBonus(decimal balanceDifference, decimal balance)
        {
            var differenceBonus = balanceDifference * DifferenceCost;
            var balanceBonus = balance * BalanceCost;
            this.Bonus += (differenceBonus + balanceBonus)
                * (Math.Abs(balanceDifference) + 11) / (Math.Abs(balance + balanceDifference) + 0.55m) * 0.01m;
        }
    }
}
