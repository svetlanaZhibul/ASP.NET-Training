using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace DAL.Interface.DTO
{
    public class AccountStorageService
    {
        public AccountStorageService()
        {

        }

        public List<Account> Accounts { get; set; }

        public Account Find(string number)
        {
            if (Accounts.Any(x => x.Number.Equals(number)))
            {
                return Accounts.Find(x => x.Number.Equals(number));
            }

            return null;
        }

        public void SaveChanges()
        {
            WriteStorage();
        }

        public void ReadStorage()
        {

        }

        public void WriteStorage()
        {

        }
    }
}
