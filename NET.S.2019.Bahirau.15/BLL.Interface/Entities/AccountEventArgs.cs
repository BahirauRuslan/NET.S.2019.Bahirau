namespace BLL.Interface.Entities
{
    public class AccountEventArgs
    {
        public AccountEventArgs(decimal balance, decimal newBalance)
        {
            Balance = balance;
            NewBalance = newBalance;
        }

        public decimal Balance { get; }

        public decimal NewBalance { get; }
    }
}
