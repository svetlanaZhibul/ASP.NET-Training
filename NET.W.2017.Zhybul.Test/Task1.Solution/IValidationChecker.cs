using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    public interface IValidationChecker
    {
        Tuple<bool, string> CheckTextFile(string psw, TextFileReporitory creator);
        Tuple<bool, string> CheckSqlFile(string psw, SqlRepository creator);
    }
}
