using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class AccountFactory
    {
        //public Exception AccountTypeNotFoundException { get; private set; }

        public Account OpenAccount(string accountType)
        {
            if (accountType == null)
            {
                return null;
            }

            Account account = null;

            switch (accountType.ToLower())
            {
                case "base":
                    account = new BaseAccount();
                    break;
                case "gold":
                    account = new GoldAccount();
                    break;
                case "premium":
                    account = new PremiumAccount();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return account;
        }

        public void CloseAccount(Account account)
        {
            account = null;
        }
    }
}
