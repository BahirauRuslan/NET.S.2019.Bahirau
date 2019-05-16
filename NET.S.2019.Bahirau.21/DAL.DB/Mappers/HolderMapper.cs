using System.Collections.Generic;
using System.Linq;
using DAL.DB.DomainClasses;
using DAL.Interface.DTO;

namespace DAL.DB.Mappers
{
    public static class HolderMapper
    {
        public static DbHolder UpdateDbHolder(DTOHolder dtoHolder, DbHolder holder, IList<DbAccount> accounts)
        {
            holder.Name = dtoHolder.Name;
            holder.Surname = dtoHolder.Surname;
            holder.Accounts = accounts;
            return holder;
        }

        public static DbHolder ToSurrogateDbHolder(this DTOHolder dtoHolder)
        {
            return new DbHolder()
            {
                Id = dtoHolder.Id,
                Name = dtoHolder.Name,
                Surname = dtoHolder.Surname
            };
        }

        public static DTOHolder ToDTOHolder(this DbHolder holder)
        {
            var accounts = (holder.Accounts != null) ? (from acc in holder.Accounts select acc.Id).ToList() : new List<long>();

            return new DTOHolder()
            {
                Id = holder.Id,
                Name = holder.Name,
                Surname = holder.Surname,
                Accounts = accounts
            };
        }

        public static IEnumerable<DTOHolder> ToDTOHolders(this IEnumerable<DbHolder> holders)
        {
            foreach (var holder in holders)
            {
                yield return holder?.ToDTOHolder();
            }
        }
    }
}
