using System.Collections.Generic;
using AutoMapper;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class HolderMapper
    {
        public static DTOHolder ToDTOHolder(this Holder holder)
        {
            return Mapper.Map<DTOHolder>(holder);
        }

        public static Holder ToHolder(this DTOHolder dtoHolder)
        {
            return Mapper.Map<Holder>(dtoHolder);
        }

        public static IEnumerable<DTOHolder> ToDTOHolders(this IEnumerable<Holder> holders)
        {
            return Mapper.Map<IEnumerable<DTOHolder>>(holders);
        }

        public static IEnumerable<Holder> ToHolders(this IEnumerable<DTOHolder> dtoHolders)
        {
            return Mapper.Map<IEnumerable<Holder>>(dtoHolders);
        }
    }
}
