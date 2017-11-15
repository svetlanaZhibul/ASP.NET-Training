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
        public TestTimeChecker(TimeChecker timer)
        {
            timer.StartTimer += Countdown;
        }

        public void Countdown(object sender, TimerEvenArgs eventArgs)
        {
            Console.WriteLine($"Test time: {eventArgs.Time}.");
            //int currTime = eventArgs.Time;
            //TimerCallback tm = new TimerCallback(Count);
            //Timer timer = new Timer(Count, eventArgs.Time, 0, 5000);
            //i = 45;
            //this.Text = i.ToString();
            //timer1.Interval = 1000;
            //timer1.Enabled = true;
            //timer1.Start();
        }

        //public static void Count(object obj)
        //{
        //    int x = (int)obj;
        //    if (x < 0)
        //    {

        //    }
        //    for ()
        //    {
        //        Console.WriteLine("{0} seconds left", (x - 5000) / 1000);
        //    }
        //}

        public void StopCounting(TimeChecker timer)
        {
            timer.StartTimer -= Countdown;
        }
    }
}
