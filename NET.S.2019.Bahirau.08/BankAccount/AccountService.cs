using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public abstract class AccountService
    {
        private List<Account> _buffer = new List<Account>();

        public void Withdraw()
        {
        }

        public Account[] ToAccountArray()
        {
            return _buffer.ToArray();
        }

        public abstract void LoadFromStorage();

        public abstract void SaveToStorage();
    }
}
