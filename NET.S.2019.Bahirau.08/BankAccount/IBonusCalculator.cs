namespace BankAccount
{
    /// <summary>
    /// The IBonusCalculator interface
    /// </summary>
    public interface IBonusCalculator
    {
        /// <summary>
        /// Get the change in bonus points
        /// </summary>
        /// <param name="balanceDifference">Balance difference</param>
        /// <param name="balance">Account balance</param>
        /// <param name="differenceCost">Cost of balance difference</param>
        /// <param name="balanceCost">Cost of balance</param>
        /// <returns>Decimal change in bonus points</returns>
        decimal GetBonusDifference(decimal balanceDifference, decimal balance, int differenceCost, int balanceCost);
    }
}
