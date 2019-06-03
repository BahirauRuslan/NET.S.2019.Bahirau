using System;
using System.ComponentModel;

namespace BLL.Interface.Entities
{
    public delegate void BonusEvent(Bonus sender, BonusEventArgs e);

    [DisplayName("Bonus")]
    public class Bonus : IEquatable<Bonus>
    {
        private int _points;

        public event BonusEvent OnTransaction;

        [DisplayName("Points")]
        public int Points
        {
            get
            {
                return _points;
            }

            set
            {
                OnTransaction?.Invoke(this, new BonusEventArgs(_points, value));
                _points = value;
            }
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Bonus);
        }

        public bool Equals(Bonus other)
        {
            return other != null &&
                   _points == other._points;
        }

        public override int GetHashCode()
        {
            return 1928246129 + _points.GetHashCode();
        }

        public override string ToString()
        {
            return $"Bonus (Points = { Points })";
        }
    }
}
