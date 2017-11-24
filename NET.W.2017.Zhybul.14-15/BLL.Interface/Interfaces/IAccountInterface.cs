using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Interfaces
{
    interface IAccountInterface
    {
        void CreateAccount(string id, string name, string surname, double sum, int bonus);

        void Delete(string id);

        void RepanishAccount();

        double DepositAccount();
    }
}
