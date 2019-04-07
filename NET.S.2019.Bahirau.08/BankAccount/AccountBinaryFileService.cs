using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// The AccountBinaryFileService class.
    /// Account service that uses a binary file as storage
    /// </summary>
    public class AccountBinaryFileService : AccountService
    {
        /// <summary>
        /// The path to the file
        /// </summary>
        public string FilePath { get; set; } = "Accounts.dat";

        public override void LoadFromStorage()
        {
            throw new NotImplementedException();
        }

        public override void SaveToStorage()
        {
            throw new NotImplementedException();
        }
    }
}
