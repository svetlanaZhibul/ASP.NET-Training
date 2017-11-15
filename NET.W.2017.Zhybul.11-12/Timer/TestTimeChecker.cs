using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TimerLibrary
{
    public class TestTimeChecker
    {
        public TestTimeChecker()
        {
        }

        public void StartCounting(TimeChecker timer)
        {
            timer.StartTimer += Countdown;
        }

        public void Countdown(object sender, TimerEvenArgs eventArgs)
        {
            Console.WriteLine($"Test time: {eventArgs.Time}.");
            int currTime = eventArgs.Time;
            int period = 1000;
            while (currTime > 1)
            {
                Thread.Sleep(period);
                Console.WriteLine($"{--currTime} seconds left");
            }
            ////TimerCallback tm = new TimerCallback(Count);
            ////Timer timer = new Timer(Count, eventArgs.Time, 0, 5000);
            ////this.timer = new Timer(Count, time-1000, 0, 1000);
        }

        ////public void Count(object obj)
        ////{
        ////    int x = (int)obj;
        ////    if (x <= 1000)
        ////    {
        ////        timer.Dispose();
        ////    }
        ////    else
        ////    {
        ////        Console.WriteLine("{0} seconds left", (x - 1000) /*/ 1000*/);
        ////        time = time - 1000;
        ////    }
        ////}

        public void StopCounting(TimeChecker timer)
        {
            timer.StartTimer -= Countdown;
        }
    }
}
