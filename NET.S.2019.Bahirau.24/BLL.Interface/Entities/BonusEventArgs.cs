using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BonusEventArgs
    {
        public BonusEventArgs(int bonusPoints, int newBonusPoints)
        {
            BonusPoints = bonusPoints;
            NewBonusPoints = newBonusPoints;
        }

        public decimal BonusPoints { get; }

        public decimal NewBonusPoints { get; }
    }
}
