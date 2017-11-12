using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayLibrary
{
    public class ArrayComparisonCreteriaLogic
    {
        /// <summary>Computes sum of array's elements.</summary>
        /// <param name="array"> Original one-dimensional array, representing one of the jagged array rows.</param>
        /// <returns>Returns sum of row's elements. </returns>
        internal static int SumByLine(int[] array)
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        /// <summary>Searches for the maximal element in array.</summary>
        /// <param name="array"> Original one-dimensional array, representing one of the jagged array rows.</param>
        /// <returns>Returns value of the maxmimal element of the row. </returns>
        internal static int MaxElementByLine(int[] array)
        {
            int max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                }
            }

            return max;
        }

        /// <summary>Searches for the minimal element in array.</summary>
        /// <param name="array"> Original one-dimensional array, representing one of the jagged array rows.</param>
        /// <returns>Returns value of the minmimal element of the row. </returns>
        internal static int MinElementByLine(int[] array)
        {
            int min = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (min > array[i])
                {
                    min = array[i];
                }
            }

            return min;
        }
    }
}