using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class GoldAccount : Account
    {
        private const double ChargeCoef = 0.5;
        private const double DeductCoef = 0.25;
        //private double chargePoints;
        public GoldAccount() : base()
        {
            this.Type = "Gold";
        }

        public GoldAccount(long number, string firstname, string lastname, double sum, int bonus) : base(number, firstname, lastname, sum, bonus)
        {
            //chargePoints = 1;
            this.Type = "Gold";
        }

        protected override void ChargeBonusPoints()
        {
            //chargePoints *= 1 + chargeCoef;
            this.Bonus *= (int)(1 + ChargeCoef);
        }

        protected override void DeductBonusPoints()
        {
            //chargePoints *= 1 - deductCoef;
            this.Bonus *= (1 < DeductCoef) ? 0 : (int)(1 - DeductCoef);
        }   
    }
}