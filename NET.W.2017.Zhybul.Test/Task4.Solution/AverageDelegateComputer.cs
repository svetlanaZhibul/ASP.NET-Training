using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Solution
{
    public class AverageDelegateComputer
    {
        public delegate double ToCompute(List<double> values);

        public double CalculateAverage(List<double> values, IAverageMethod averagingMethod)
        {
            ToCompute compare = averagingMethod.Calculate;

            if (averagingMethod == null)
            {
                throw new ArgumentException(nameof(averagingMethod));
            }
            else
            {
                return CalculateAverage(values, compare);
            }
        
        }

        public double CalculateAverage(List<double> values, ToCompute computing)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return computing(values);
        }
    }

}
