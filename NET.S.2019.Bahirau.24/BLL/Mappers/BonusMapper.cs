using System.Collections.Generic;
using AutoMapper;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BonusMapper
    {
        public static DTOBonus ToDTOBonus(this Bonus bonus)
        {
            return Mapper.Map<DTOBonus>(bonus);
        }

        public static Bonus ToBonus(this DTOBonus dtoBonus)
        {
            return Mapper.Map<Bonus>(dtoBonus);
        }

        public static IEnumerable<DTOBonus> ToDTOBonuses(this IEnumerable<Bonus> bonuses)
        {
            return Mapper.Map<IEnumerable<DTOBonus>>(bonuses);
        }

        public static IEnumerable<Bonus> ToBonuses(this IEnumerable<DTOBonus> dtoBonuses)
        {
            return Mapper.Map<IEnumerable<Bonus>>(dtoBonuses);
        }
    }
}
