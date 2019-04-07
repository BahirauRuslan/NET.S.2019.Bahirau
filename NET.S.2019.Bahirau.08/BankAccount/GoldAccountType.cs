using System;

namespace BankAccount
{
    [Serializable]
    public class GoldAccountType : AccountType
    {
        public GoldAccountType()
        {
            this.DifferenceCost = 12;
            this.BalanceCost = 17;
        }

        public override string TypeName
        {
            get
            {
                return "Gold";
            }
        }

        public override void ChangeBonus(decimal balanceDifference, decimal balance)
        {
            var differenceBonus = balanceDifference * DifferenceCost;
            var balanceBonus = balance * BalanceCost;
            this.Bonus += (differenceBonus + balanceBonus)
                * (Math.Abs(balanceDifference) + 7) / (Math.Abs(balance + balanceDifference) + 0.7m) * 0.01m;
        }
    }
}
