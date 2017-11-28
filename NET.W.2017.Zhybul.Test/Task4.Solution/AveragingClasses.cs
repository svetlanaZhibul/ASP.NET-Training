﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Solution
{
    public class AverageByMean : IAverageMethod
    {
        public double Calculate(List<double> values)
        {
            return values.Sum() / values.Count;
        }
    }

    public class AverageByMedian : IAverageMethod
    {
        public double Calculate(List<double> values)
        {
            var sortedValues = values.OrderBy(x => x).ToList();

            int n = sortedValues.Count;

            if (n % 2 == 1)
            {
                return sortedValues[(n - 1) / 2];
            }

            return (sortedValues[sortedValues.Count / 2 - 1] + sortedValues[n / 2]) / 2;
        }
    }
}
