using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    interface INumberPresence
    {
        Tuple<bool, string> IsNumberPresent(string psw);
    }
}
