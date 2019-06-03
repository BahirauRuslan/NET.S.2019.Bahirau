using System.Collections.Generic;
using AutoMapper;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class AccountMapper
    {
        public static DTOAccount ToDTOAccount(this Account account)
        {
            return Mapper.Map<DTOAccount>(account);
        }

        public static Account ToAccount(this DTOAccount dtoAccount)
        {
            return Mapper.Map<Account>(dtoAccount);
        }

        public static IEnumerable<DTOAccount> ToDTOAccounts(this IEnumerable<Account> accounts)
        {
            return Mapper.Map<IEnumerable<DTOAccount>>(accounts);
        }

        public static IEnumerable<Account> ToAccounts(this IEnumerable<DTOAccount> dtoAccounts)
        {
            return Mapper.Map<IEnumerable<Account>>(dtoAccounts);
        }
    }
}
