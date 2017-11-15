using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TimerLibrary
{
    public class TimerSimulator
    {
        public TimerSimulator()
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
                Console.WriteLine($"{--currTime} seconds to simulate");
            }
        }

        public void StopCounting(TimeChecker timer)
        {
            timer.StartTimer -= Countdown;
        }
    }
}
