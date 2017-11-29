using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    interface ILetterPresence
    {
        Tuple<bool, string> IsLetterPresent(string psw);
    }
}
