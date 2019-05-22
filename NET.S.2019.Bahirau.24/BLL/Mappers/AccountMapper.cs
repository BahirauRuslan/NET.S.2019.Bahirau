using System.Collections.Generic;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class AccountMapper
    {
        public static DTOAccount ToDTOAccount(this Account account)
        {
            return new DTOAccount
            {
                Id = account.Id,
                Balance = account.Balance,
                Holder = account.Holder.ToDTOHolder(),
                AccountType = account.AccountType.ToDTOAccountType(),
                Bonus = account.Bonus.ToDTOBonus(),
                IsEnabled = account.IsEnabled
            };
        }

        public static Account ToAccount(this DTOAccount dtoAccount)
        {
            var account = new Account
            {
                Id = dtoAccount.Id,
                Balance = dtoAccount.Balance,
                Holder = dtoAccount.Holder.ToHolder(),
                AccountType = dtoAccount.AccountType.ToAccountType(),
                Bonus = dtoAccount.Bonus.ToBonus(),
                IsEnabled = dtoAccount.IsEnabled
            };
            account.OnTransaction += account.AccountType.AccountEvent;
            return account;
        }

        public static IEnumerable<DTOAccount> ToDTOAccounts(this IEnumerable<Account> accounts)
        {
            foreach (var account in accounts)
            {
                yield return account.ToDTOAccount();
            }
        }

        public static IEnumerable<Account> ToAccounts(this IEnumerable<DTOAccount> dtoAccounts)
        {
            foreach (var dtoAccount in dtoAccounts)
            {
                yield return dtoAccount.ToAccount();
            }
        }
    }
}
