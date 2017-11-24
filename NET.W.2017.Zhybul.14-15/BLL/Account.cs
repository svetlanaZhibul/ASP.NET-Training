using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public abstract class Account
    {
        #region Fields
        private string number;
        private string firstname;
        private string lastname;
        private double sum;
        private int bonus;
        #endregion

        #region Constructors
        protected Account()
        {
        }

        protected Account(string number, string firstname, string lastname, double sum, int bonus)
        {
            this.number = number;
            this.firstname = firstname;
            this.lastname = lastname;
            this.sum = sum;
            this.bonus = bonus;
        }

        #endregion

        #region Properties
        public int Bonus
        {
            get
            {
                return bonus;
            }

            set
            {
                bonus = value;
            }
        }

        public double Sum
        {
            get
            {
                return sum;
            }

            /*private */
            set
            {
                sum = value;
            }
        }

        public string Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;
            }
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }

            set
            {
                firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }

            set
            {
                lastname = value;
            }
        }
        #endregion

        #region PublicMethods
        public override string ToString()
        {
            return $"Account number: {number}, owner: {firstname} {lastname}, total sum: {sum}, bonus points: {bonus}";
        }
        #endregion

        #region ProtectedMethods
        protected abstract void ChargeBonusPoints();

        protected abstract void DeductBonusPoints();
        #endregion
    }

}
