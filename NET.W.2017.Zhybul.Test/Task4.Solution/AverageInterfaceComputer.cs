using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Solution
{
    public class AverageInterfaceComputer
    {
        public delegate double ToCompute(List<double> values);

        private class DelegateToInterfaceAdapter : IAverageMethod
        {
            ToCompute computing;
            public DelegateToInterfaceAdapter(ToCompute c)
            {
                computing = c;
            }

            public double Calculate(List<double> values)
            {
                return computing(values);
            }
        }

        public double CalculateAverage(List<double> values, IAverageMethod averagingMethod)
        {
          
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return averagingMethod.Calculate(values);
        }

        public double CalculateAverage(List<double> values, ToCompute computing)
        {
            if (computing == null)
            {
                throw new ArgumentException(nameof(computing));
            }
            else
            {
                DelegateToInterfaceAdapter adapter = new DelegateToInterfaceAdapter(computing);
                return CalculateAverage(values, adapter);
            }
        }
    }

}
