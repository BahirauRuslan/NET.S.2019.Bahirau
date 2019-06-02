using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.Interface.Entities
{
    public delegate void BonusEvent(Bonus sender, BonusEventArgs e);

    [DisplayName("Bonus")]
    public class Bonus
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
    }
}
