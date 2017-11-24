using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GoldAccount : Account
    {
        private const double ChargeCoef = 1.75;
        private const double DeductCoef = 0.75;

        public GoldAccount() : base()
        {
        }

        public GoldAccount(string number, string firstname, string lastname, double sum, int bonus) : base(number, firstname, lastname, sum, bonus)
        {
            if (this.Bonus < 5)
            {
                this.Bonus = 5;
            }
        }

        protected override void ChargeBonusPoints()
        {
            this.Bonus = (int)(this.Bonus * ChargeCoef);
        }

        protected override void DeductBonusPoints()
        {
            this.Bonus = (int)(this.Bonus * DeductCoef);
        }
    }
}
