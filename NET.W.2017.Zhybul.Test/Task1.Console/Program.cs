using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Solution;

namespace Task1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            List <IUserCreator> user_repos = new List<IUserCreator>();
            user_repos.Add(new SqlRepository());
            user_repos.Add(new TextFileReporitory());

            foreach (IUserCreator repo in user_repos)
            {
                System.Console.WriteLine(repo.GetType().Name);
                repo.Create("lalalala", new CommonValidatorService());
                repo.Create("a9qwerty", new SpecialisedValidatorService());
                System.Console.WriteLine();
            }

            System.Console.ReadKey();
        }
    }
}
