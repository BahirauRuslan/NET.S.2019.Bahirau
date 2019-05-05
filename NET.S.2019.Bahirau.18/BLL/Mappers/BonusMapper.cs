using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BonusMapper
    {
        public static DTOBonus ToDTOBonus(this Bonus bonus)
        {
            return new DTOBonus { BonusPoints = bonus.BonusPoints };
        }

        public static Bonus ToBonus(this DTOBonus dtoBonus)
        {
            return new Bonus { BonusPoints = dtoBonus.BonusPoints };
        }
    }
}
