using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{  
    // add accountService
    // logic of number generation in service
    // number - string (maybe/try)
    // validation
    // ui-componet(!?) -> service -> find account -> do logic           <=> ui - bll - [ dao ] - dal
    // pattern repository(?)
    // possibiility to have debts in premium acc. e.g.

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
        {
        }

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

            /*private */set
            {
                sum = value;
            }
        }

        public long Number
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

        public string Type { get; set; }
        #endregion

        #region PublicMethods
        public void ReplenishAccount(double addition)
        {
            if (addition <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(addition));
            }
            //throw new InvalidCastException();
            Console.WriteLine("This operation does nothing. Please, check input data and try again.");
            addition = 0;
            sum += addition;
            ChargeBonusPoints();
        }

        public void DebitAccout(double deduction)
        {
            if (deduction <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(deduction));
            }
            //throw new InvalidCastException();
            Console.WriteLine("This operation does nothing. Please, check input data and try again.");
            deduction = 0;
            DeductBonusPoints();
            sum -= deduction;
        }

        #region OverridedObjectMethods
        public override string ToString()
        {
            return $"Account number: {number}, owner: {firstname} {lastname}, total sum: {sum}, bonus points: {bonus}";
        }
        #endregion

        #endregion

        #region ProtectedMethods
        protected abstract void ChargeBonusPoints();

        protected abstract void DeductBonusPoints();
        #endregion
    }
}
