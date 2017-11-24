using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;

namespace DAL
{
    internal class TextFileAccountRepository : IRepository
    {
        private AccountStorageService accountDB;

        public TextFileAccountRepository()
        {
            accountDB = new AccountStorageService();
        }

        public void Create(Account item)
        {
            if (GetAccount(item.Number) == null)
            {
                accountDB.Accounts.Add(item); 
            }
            else
            {
                Update(item);
            }
        }

        public void Delete(string number)
        {
            Account account = accountDB.Find(number);
            if (account != null)
            {
                accountDB.Accounts.Remove(account);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Account GetAccount(string number)
        {
            return accountDB.Find(number);
        }

        public IEnumerable<Account> GetAccountList()
        {
            return accountDB.Accounts;
        }

        public void Save()
        {
            accountDB.SaveChanges();
        }

        public void Update(Account item)
        {
            if (accountDB.Find(item.Number) != null)
            {
                accountDB.Accounts[accountDB.Accounts.IndexOf(item)] = item; 
            }
        }
    }
}
