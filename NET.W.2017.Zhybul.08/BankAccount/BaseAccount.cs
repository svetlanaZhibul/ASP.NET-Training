using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class BaseAccount : Account
    {
        private const int ChargePoints = 5;
        private const int DeductPoints = 2;

        public BaseAccount() : base()
        {
            this.Type = "Base";
        }

        public BaseAccount(long number, string firstname, string lastname, double sum, int bonus) : base(number, firstname, lastname, sum, bonus)
        {
            this.Type = "Base";
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
