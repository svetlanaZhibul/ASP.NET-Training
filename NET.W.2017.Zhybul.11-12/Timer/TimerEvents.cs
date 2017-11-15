using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerLibrary
{
    public sealed class TimerEvenArgs : EventArgs
    {
        private readonly int time;

        public TimerEvenArgs(int time)
        {
            this.time = time;
        }

        public int Time
        {
            get
            {
                return time;
            }
        }
    }
        
    public class TimeChecker
    {
        public event EventHandler<TimerEvenArgs> StartTimer;

        protected virtual void OnStartTimer(TimerEvenArgs args)
        {
            EventHandler<TimerEvenArgs> currTime = StartTimer;
            if (currTime != null)
            {
                currTime(this, args);
            }
        }

        public void TickSender(int time)
        {
            OnStartTimer(new TimerEvenArgs(time));
        }
    }

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
            //TimerCallback tm = new TimerCallback(Count);
            //Timer timer = new Timer(Count, eventArgs.Time, 0, 5000);
            //this.timer = new Timer(Count, time-1000, 0, 1000);
        }

        //public void Count(object obj)
        //{
        //    int x = (int)obj;
        //    if (x <= 1000)
        //    {
        //        timer.Dispose();
        //    }
        //    else
        //    {
        //        Console.WriteLine("{0} seconds left", (x - 1000) /*/ 1000*/);
        //        time = time - 1000;
        //    }
        //}

        public void StopCounting(TimeChecker timer)
        {
            timer.StartTimer -= Countdown;
        }
    }

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
