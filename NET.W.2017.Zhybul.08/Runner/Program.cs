using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BankAccountFactory;
using BankAccount;

namespace BankAccountRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountStorage storage = new AccountStorage();
            
            AccountFactory aFactory = new AccountFactory();
            List<Account> accounts = new List<Account>();

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Enter type of account to create one. Choose from base, gold and premium types.");
                string aType = Console.ReadLine();
                try
                {
                    Account account = aFactory.OpenAccount(aType);
                    account.ReplenishAccount(22 * i + 1);
                    account.Number = 1000000 + i;
                    account.Firstname = "Ivanov" + i;
                    account.Lastname = "Alex" + i;
                    account.Bonus = 11;
                    accounts.Add(account);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid account type entered.");
                    //throw;
                } 
            }

            storage.WriteToAccountStorage(accounts);
            List<Account> newlist = storage.ReadFromAccountStorage();
            
            foreach (Account acc in newlist)
            {
                Console.WriteLine(acc);
            }

            newlist[0].ReplenishAccount(100);
            newlist[1].DebitAccout(15);

            foreach (Account acc in newlist)
            {
                Console.WriteLine(acc);
            }

            Console.ReadKey();

        }
    }
}
