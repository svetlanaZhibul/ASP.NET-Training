using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class PremiumAccount : Account
    {
        private const double ChargeCoef = 0.75;
        private const double DeductCoef = 0.25;
        //private double chargePoints;
        public PremiumAccount() 
            : base()
        {
            this.Type = "Premium";
        }

        public PremiumAccount(long number, string firstname, string lastname, double sum, int bonus) : base(number, firstname, lastname, sum, bonus)
        {
            //chargePoints = 1;
            this.Type = "Premium";
        }

        protected override void ChargeBonusPoints()
        {
            //chargePoints *= 1 + chargeCoef;
            this.Bonus *= (int)(1 + ChargeCoef);
        }

        protected override void DeductBonusPoints()
        {
            //chargePoints *= 1 - deductCoef;
            this.Bonus *= (1 - DeductCoef < 0) ? 0 : (int)(1 - DeductCoef);
        }
    }
}
