using System.Collections.Generic;
using DAL.DB.DomainClasses;
using DAL.Interface.DTO;

namespace DAL.DB.Mappers
{
    public static class AccountMapper
    {
        public static DbAccount UpdateDbAccount(DTOAccount dtoAccount, DbAccount account, DbHolder holder)
        {
            account.AccountType = dtoAccount.AccountType;
            account.Balance = dtoAccount.Balance;
            account.Bonus = dtoAccount.Bonus;
            account.Holder = holder;
            account.IsEnabled = dtoAccount.IsEnabled;
            return account;
        }

        public static DTOAccount ToDTOAccount(this DbAccount account)
        {
            return new DTOAccount()
            {
                Id = account.Id,
                Balance = account.Balance,
                Holder = account.Holder?.ToDTOHolder(),
                Bonus = account.Bonus,
                AccountType = account.AccountType,
                IsEnabled = account.IsEnabled
            };
        }

        public static IEnumerable<DTOAccount> ToDTOAccounts(this IEnumerable<DbAccount> accounts)
        {
            foreach (var account in accounts)
            {
                yield return account?.ToDTOAccount();
            }
        }
    }
}
