using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    public class SqlRepository : IUserCreator
    {
        public void Create(string password, IValidationChecker validator)
        {
            Tuple<bool, string> response = validator.CheckSqlFile(password, this);

            Console.WriteLine(response.Item2);

            if (response.Item1 == true)
            {
                Console.WriteLine("User added to the database.");
            }
        }
    }
}
