using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
            BinaryFormatter formatter = new BinaryFormatter();
            using (var stream = new FileStream(this.FilePath, FileMode.OpenOrCreate))
            {
                Account[] accounts = (Account[])formatter.Deserialize(stream);
                
                foreach (var account in accounts)
                {
                    this.AddAccount(account);
                }
            }
        }

        public override void SaveToStorage()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (var stream = new FileStream(this.FilePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream, this.ToAccountArray());
            }
        }
    }
}
