using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerLibrary
{
    public class TimeChecker
    {
        public event EventHandler<TimerEvenArgs> StartTimer;

        public void TickSender(int time)
        {
            OnStartTimer(new TimerEvenArgs(time));
        }

        protected virtual void OnStartTimer(TimerEvenArgs args)
        {
            EventHandler<TimerEvenArgs> currTime = StartTimer;
            if (currTime != null)
            {
                currTime(this, args);
            }
        }
    } 
}
