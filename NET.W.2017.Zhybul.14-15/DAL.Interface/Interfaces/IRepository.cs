using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace DAL.Interface.Interfaces
{
    public interface IRepository : IDisposable
    {
        IEnumerable<Account> GetAccountList();
        Account GetAccount(string number);
        void Create(Account item);
        void Update(Account item);
        void Delete(string number);
        void Save();
    }
}
