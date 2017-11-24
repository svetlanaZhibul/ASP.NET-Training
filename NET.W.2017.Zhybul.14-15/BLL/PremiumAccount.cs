using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PremiumAccount : Account
    {
        private const int ChargePoints = 8;
        private const int DeductPoints = 3;

        public PremiumAccount() : base()
        {
        }

        public PremiumAccount(string number, string firstname, string lastname, double sum, int bonus) : base(number, firstname, lastname, sum, bonus)
        {
        }

        protected override void ChargeBonusPoints()
        {
            this.Bonus = this.Bonus + ChargePoints;
        }

        protected override void DeductBonusPoints()
        {
            this.Bonus = (this.Bonus - DeductPoints < 0) ? 0 : this.Bonus - DeductPoints;
        }
    }
}
