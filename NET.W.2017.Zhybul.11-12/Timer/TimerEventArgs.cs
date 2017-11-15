using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                return this.time;
            }
        }
    }
}
