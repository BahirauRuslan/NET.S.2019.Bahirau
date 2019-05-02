using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
