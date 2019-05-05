using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class AccountTypeMapper
    {
        private static readonly IList<AccountType> AccountTypes
            = new List<AccountType>
        {
            new AccountType(
                "Base", 
                (acc, e) => acc.Bonus.BonusPoints += (int)(5m * (e.NewBalance - e.Balance) / (Math.Abs(e.NewBalance) + 9m))),
            new AccountType(
                "Gold",
                (acc, e) => acc.Bonus.BonusPoints += (int)(9m * (e.NewBalance - e.Balance) / (Math.Abs(e.NewBalance) + 5m))),
            new AccountType(
                "Platinum",
                (acc, e) => acc.Bonus.BonusPoints += (int)(14m * (e.NewBalance - e.Balance) / (Math.Abs(e.NewBalance) + 1m))),
        };

        public static AccountType GetAccountType(string typeName)
        {
            return (from type in AccountTypes where type.TypeName == typeName select type).First();
        }

        public static void AddAccountType(AccountType type)
        {
            AccountTypes.Add(type);
        }

        public static DTOAccountType ToDTOAccountType(this AccountType accountType)
        {
            return new DTOAccountType { TypeName = accountType.TypeName };
        }

        public static AccountType ToAccountType(this DTOAccountType dtoAccountType)
        {
            return GetAccountType(dtoAccountType.TypeName);
        }
    }
}
