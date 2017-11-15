using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerLibrary;

namespace TRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeChecker tc = new TimeChecker();

            int timeSec = 5000;
            TestTimeChecker tester = new TestTimeChecker(tc);

            tc.TickSender(timeSec);

            Console.ReadKey();
        }
    }
}
