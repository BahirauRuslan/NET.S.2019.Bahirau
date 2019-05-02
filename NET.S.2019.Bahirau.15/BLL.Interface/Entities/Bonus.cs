using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class Bonus : IEquatable<Bonus>, IComparable<Bonus>
    {
        private int _bonusPoints;

        public Bonus(int bonusPoints = 0)
        {
            if (bonusPoints < 0)
            {
                throw new ArgumentException("Bonus points must be non-negative");
            }

            _bonusPoints = bonusPoints;
        }

        public int BonusPoints
        {
            get
            {
                return _bonusPoints;
            }

            set
            {
                _bonusPoints = (value > 0) ? value : 0;
            }
        }

        public int CompareTo(Bonus other)
        {
            if (other == null)
            {
                return 1;
            }
            
            return _bonusPoints.CompareTo(other._bonusPoints);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Bonus);
        }

        public bool Equals(Bonus other)
        {
            return other != null &&
                   _bonusPoints == other._bonusPoints;
        }

        public override int GetHashCode()
        {
            return 1514057882 + _bonusPoints.GetHashCode();
        }

        public override string ToString()
        {
            return $"Bonus points: { _bonusPoints }";
        }
    }
}
