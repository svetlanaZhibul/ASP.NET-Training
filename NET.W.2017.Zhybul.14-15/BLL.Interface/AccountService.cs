using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;

namespace BLL.Interface
{
    public class AccountService : IAccountInterface
    {
        public void CreateAccount(string id, string name, string surname, double sum, int bonus)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public double DepositAccount()
        {
            throw new NotImplementedException();
        }

        public void RepanishAccount()
        {
            throw new NotImplementedException();
        }
    }
}
