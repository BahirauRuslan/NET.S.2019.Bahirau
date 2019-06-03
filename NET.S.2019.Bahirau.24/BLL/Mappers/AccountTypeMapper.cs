using System.Collections.Generic;
using AutoMapper;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class AccountTypeMapper
    {
        public static DTOAccountType ToDTOAccountType(this AccountType accountType)
        {
            return Mapper.Map<DTOAccountType>(accountType);
        }

        public static AccountType ToAccountType(this DTOAccountType dtoAccountType)
        {
            return Mapper.Map<AccountType>(dtoAccountType);
        }

        public static IEnumerable<DTOAccountType> ToDTOAccountTypes(this IEnumerable<AccountType> accountTypes)
        {
            return Mapper.Map<IEnumerable<DTOAccountType>>(accountTypes);
        }

        public static IEnumerable<AccountType> ToAccountTypes(this IEnumerable<DTOAccountType> dtoAccountTypes)
        {
            return Mapper.Map<IEnumerable<AccountType>>(dtoAccountTypes);
        }
    }
}
