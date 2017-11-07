using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{  
    //struct AccountHolder
    //{
    //    private string firstname;
    //    private string lastname;
    //    private string origins;
    //    private string dateOfBirth;
    //}
    public abstract class Account
    {
        #region Fields
        private long number;
        private string firstname;
        private string lastname;
        private double sum;
        private int bonus;
        #endregion

        #region Constructors
        protected Account()
        {}
        protected Account(long number, string firstname, string lastname, double sum, int bonus)
        {
            this.number = number;
            this.firstname = firstname;
            this.lastname = lastname;
            this.sum = sum;
            this.bonus = bonus;
        }

        #endregion

        #region Properties
        public int Bonus { get { return bonus; } set { bonus = value; } }
        public double Sum { get { return sum; } set { sum = value; } }
        public long Number { get { return number; } set { number = value; } }
        public string Firstname { get { return firstname; } set { firstname = value; } }
        public string Lastname { get { return lastname; } set { lastname = value; } }
        public string Type { get; set; }
        #endregion

        #region PublicMethods
        public void ReplenishAccount(double addition)
        {
            try
            {
                if (addition <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(addition));
                }
            }
            catch (Exception e)
            {
                //throw new InvalidCastException();
                Console.WriteLine("This operation does nothing. Please, check input data and try again.");
                addition = 0;
            }
            finally
            {
                sum += addition;
                ChargeBonusPoints();
            }
        }
        public void DebitAccout(double deduction)
        {
            try
            {
                if (deduction <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(deduction));
                }
            }
            catch (Exception e)
            {
                //throw new InvalidCastException();
                Console.WriteLine("This operation does nothing. Please, check input data and try again.");
                deduction = 0;
            }
            finally
            {
                sum -= deduction;
                DeductBonusPoints();
            }
        }
        #endregion

        #region ProtectedMethods
        protected abstract void ChargeBonusPoints();
        protected abstract void DeductBonusPoints();
        #endregion

        #region OverridedObjectMethods
        public override string ToString()
        {
            return $"Account number: {number}, owner: {firstname} {lastname}, total sum: {sum}, bonus points: {bonus}";
        } 
        #endregion
    }

    public class BaseAccount : Account
    {
        private const int chargePoints = 5;
        private const int deductPoints = 2;
        public BaseAccount() : base() { Type = "Base"; }
        public BaseAccount(long number, string firstname, string lastname, double sum, int bonus) : base(number, firstname, lastname, sum, bonus) { Type = "Base"; }

        protected override void ChargeBonusPoints()
        {
            Bonus = Bonus + chargePoints;
        }
        protected override void DeductBonusPoints()
        {
            Bonus = (Bonus - deductPoints < 0) ? 0 : Bonus - deductPoints;
        }
    }

    public class GoldAccount : Account
    {
        private const double chargeCoef = 0.5;
        private const double deductCoef = 0.25;
        //private double chargePoints;
        public GoldAccount() : base() { Type = "Gold"; }
        public GoldAccount(long number, string firstname, string lastname, double sum, int bonus) : base(number, firstname, lastname, sum, bonus)
        {
            //chargePoints = 1;
            Type = "Gold";
        }

        protected override void ChargeBonusPoints()
        {
            //chargePoints *= 1 + chargeCoef;
            Bonus *= (int)(1 + chargeCoef);
        }
        protected override void DeductBonusPoints()
        {
            //chargePoints *= 1 - deductCoef;
            Bonus *= (1 < deductCoef ) ? 0 : (int)(1 - deductCoef);
        }
    }

    public class PremiumAccount : Account
    {
        private const double chargeCoef = 0.75;
        private const double deductCoef = 0.25;
        //private double chargePoints;
        public PremiumAccount() : base() { Type = "Premium"; }
        public PremiumAccount(long number, string firstname, string lastname, double sum, int bonus) : base(number, firstname, lastname, sum, bonus)
        {
            //chargePoints = 1;
            Type = "Premium";
        }

        protected override void ChargeBonusPoints()
        {
            //chargePoints *= 1 + chargeCoef;
            Bonus *= (int)(1 + chargeCoef);
        }
        protected override void DeductBonusPoints()
        {
            //chargePoints *= 1 - deductCoef;
            Bonus *= (1 - deductCoef < 0) ? 0 : (int)(1 - deductCoef);
        }
    }
}
