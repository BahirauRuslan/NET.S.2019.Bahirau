using System;
using System.Collections.Generic;

namespace BankAccount
{
    public class Program
    {
        private static AccountService service = new AccountBinaryFileService();

        public static void Main(string[] args)
        {
            while (MainMenu())
            {
            }
        }

        private static bool MainMenu()
        {
            var enabled = true;
            var menu = "1. Load accounts\n2. Add account\n" +
                "3. Remove account\n4. Find account by id\n" +
                "5. Sort account by balance\n6. Save account\n" +
                "7. Close account\n8. Open account\n9. Deposit\n10. Withdraw\nCase: ";
            var menuCase = GetLong(menu);
            try
            {
                switch (menuCase)
                {
                    case 1:
                        LoadAccounts();
                        break;
                    case 2:
                        AddAccount();
                        break;
                    case 3:
                        RemoveAccount();
                        break;
                    case 4:
                        FindAccount();
                        break;
                    case 5:
                        SortAccounts();
                        break;
                    case 6:
                        SaveAccounts();
                        break;
                    case 7:
                        CloseAccount();
                        break;
                    case 8:
                        OpenAccount();
                        break;
                    case 9:
                        DepositAccount();
                        break;
                    case 10:
                        WithdrawAccount();
                        break;
                    default:
                        enabled = false;
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return enabled;
        }

        private static void LoadAccounts()
        {
            service.LoadFromStorage();
            PrintAccounts(service.ToAccountArray());
        }

        private static void AddAccount()
        {
            var account = new Account
            {
                Id = GetLong("Id: "),
                FirstName = GetString("First name: "),
                LastName = GetString("Last name: ")
            };
            service.AddAccount(account);
            PrintAccounts(service.ToAccountArray());
        }

        private static void RemoveAccount()
        {
            var accounts = service.ToAccountArray();

            if (accounts.Length > 0)
            {
                var account = GetAccount();
                service.RemoveAccount(account);
            }

            PrintAccounts(service.ToAccountArray());
        }

        private static void CloseAccount()
        {
            var accounts = service.ToAccountArray();

            if (accounts.Length > 0)
            {
                var account = GetAccount();
                service.CloseAccount(account);
            }

            PrintAccounts(service.ToAccountArray());
        }

        private static void OpenAccount()
        {
            var accounts = service.ToAccountArray();

            if (accounts.Length > 0)
            {
                var account = GetAccount();
                service.OpenAccount(account);
            }

            PrintAccounts(service.ToAccountArray());
        }

        private static void DepositAccount()
        {
            var accounts = service.ToAccountArray();

            if (accounts.Length > 0)
            {
                var account = GetAccount();
                var amount = GetDecimal("Amount: ");
                service.Deposit(account, amount);
            }

            PrintAccounts(service.ToAccountArray());
        }

        private static void WithdrawAccount()
        {
            var accounts = service.ToAccountArray();

            if (accounts.Length > 0)
            {
                var account = GetAccount();
                var amount = GetDecimal("Amount: ");
                service.Withdraw(account, amount);
            }

            PrintAccounts(service.ToAccountArray());
        }

        private static Account GetAccount()
        {
            var accounts = service.ToAccountArray();
            PrintAccounts(accounts);
            var index = GetLong("Index: ") - 1;
            while (index < -1 || index > accounts.Length)
            {
                index = GetLong("Try again: ") - 1;
            }

            return accounts[index];
        }

        private static void FindAccount()
        {
            Console.WriteLine(service.FindById(GetLong("Id: ")));
        }

        private static void SortAccounts()
        {
            service.SortByBalance();
            PrintAccounts(service.ToAccountArray());
        }

        private static void SaveAccounts()
        {
            service.SaveToStorage();
            Console.WriteLine("Accounts saved successfully");
        }

        private static void PrintAccounts(IEnumerable<Account> accounts)
        {
            var index = 1;

            foreach (var account in accounts)
            {
                Console.Write(index++);
                Console.Write(". ");
                Console.WriteLine(account);
            }
        }

        private static long GetLong(string msg)
        {
            long num;
            Console.Write(msg);
            var strNum = Console.ReadLine();
            while (!long.TryParse(strNum, out num))
            {
                Console.Write("Try again: ");
                strNum = Console.ReadLine();
            }

            return num;
        }

        private static decimal GetDecimal(string msg)
        {
            decimal num;
            Console.Write(msg);
            var strNum = Console.ReadLine();
            while (!decimal.TryParse(strNum, out num))
            {
                Console.Write("Try again: ");
                strNum = Console.ReadLine();
            }

            return num;
        }

        private static string GetString(string msg)
        {
            Console.Write(msg);
            return Console.ReadLine();
        }
    }
}
