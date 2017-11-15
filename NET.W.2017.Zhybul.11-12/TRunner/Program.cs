using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerLibrary;

namespace TRunner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TimeChecker tc = new TimeChecker();

            // User enters time in seconds
            int time1 = 10;
            int time2 = 20;

            TestTimeChecker tester = new TestTimeChecker();
            tester.StartCounting(tc);
            TimerSimulator simulator = new TimerSimulator();
            simulator.StartCounting(tc);

            tc.TickSender(time1);

            tester.StopCounting(tc);

            tc.TickSender(time2);

            Console.ReadKey();
        }
    }
}
