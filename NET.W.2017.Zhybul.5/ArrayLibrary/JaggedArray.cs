using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayLibrary
{
    /// <summary>
    /// Provides methods for sorting rows in two-dimentional jagged array of integers.</summary>
    /// <remarks>
    /// Sorting creteria: 
    /// Sum of elements in the rows, Maximal or Minimal elements of the rows.</remarks>
    public class JaggedArray
    {
        public delegate bool ToCompare(int[] lhs, int[] rhs);

        /// <summary>Sorts jagged integer array using mehtod for particular creterion in particular order.</summary>
        /// <param name="array"> An array to be sorted.</param>
        /// <param name="comparer"> Method setting the logic of particular kind of sorting.</param>
        public static void Sort(int[][] array, ToCompare comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentException(nameof(comparer));
            }
            else
            {
                IComparer<int[], int[]> comparator;
                comparator = (IComparer<int[], int[]>)comparer.Target;
                //// validation
                Sort(array, comparator);
            }
        }

        /// <summary>Sorts jagged integer array using mehtod for particular creterion in particular order.</summary>
        /// <param name="array"> An array to be sorted.</param>
        /// <param name="comparer"> Interface setting the logic of particular kind of sorting.</param>
        public static void Sort(int[][] array, IComparer<int[], int[]> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentException(nameof(comparer));
            }
            else
            {
                int i = 0;
                bool flag = true;
                while (flag)
                {
                    flag = false;
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (comparer.CompareTo(array[j], array[j + 1]))
                        {
                            Swap(ref array[j], ref array[j + 1]);
                            flag = true;
                        }
                    }

                    i++;
                }
            }
        }

        #region PrivateMethods
        /// <summary>Swaps two arrays.</summary>
        /// <param name="a"> Reference for the first array.</param>
        /// <param name="b"> Reference for the second array.</param>
        private static void Swap(ref int[] a, ref int[] b)
        {
            int[] temp = a;
            a = b;
            b = temp;
        }
        #endregion
    }
}
