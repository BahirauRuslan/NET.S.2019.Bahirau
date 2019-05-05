using System.Collections.Generic;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class HolderMapper
    {
        public static DTOHolder ToDTOHolder(this Holder holder)
        {
            return new DTOHolder
            {
                Id = holder.Id,
                Name = holder.Name,
                Surname = holder.Surname,
                Accounts = holder.Accounts
            };
        }

        public static Holder ToHolder(this DTOHolder dtoHolder)
        {
            return new Holder
            {
                Id = dtoHolder.Id,
                Name = dtoHolder.Name,
                Surname = dtoHolder.Surname,
                Accounts = dtoHolder.Accounts
            };
        }

        public static IEnumerable<DTOHolder> ToDTOHolders(this IEnumerable<Holder> holders)
        {
            foreach (var holder in holders)
            {
                yield return holder.ToDTOHolder();
            }
        }

        public static IEnumerable<Holder> ToHolders(this IEnumerable<DTOHolder> dtoHolders)
        {
            foreach (var dtoHolder in dtoHolders)
            {
                yield return dtoHolder.ToHolder();
            }
        }
    }
}
