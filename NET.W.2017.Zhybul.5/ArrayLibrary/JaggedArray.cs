using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayLibrary
{
    /// <summary>
    /// Provides methods for sorting rows in two-dimaentional jagged array of integers.</summary>
    /// <remarks>
    /// Sorting creteria: 
    /// Sum of elements in the rows, Maximal or Minimal elements of the rows.</remarks>
    public class JaggedArray
    {
        /// <summary>Sorts jagged integer array by sum of the rows ascending.</summary>
        /// <param name="array"> An array to be sorted.</param>
        public static void SortBySumAsc(int[][] array)
        {
            int comparer = 1;

            SortBySum(array, comparer);
        }

        /// <summary>Sorts jagged integer array by sum of the rows descending.</summary>
        /// <param name="array"> An array to be sorted.</param>
        public static void SortBySumDesc(int[][] array)
        {
            int comparer = -1;

            SortBySum(array, comparer);
        }
        /// <summary>Sorts jagged integer array by sum of the rows in chosen order.</summary>
        /// <param name="array"> An array to be sorted.</param>
        /// <param name="comparer"> Flag setting the particular order of sorting.</param>
        private static void SortBySum(int[][] array, int comparer)
        {
            int[] lineSumsArray = SumByLines(array);

            int i = 0;
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (lineSumsArray[j].CompareTo(lineSumsArray[j + 1]) == comparer)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        Swap(ref lineSumsArray[j], ref lineSumsArray[j + 1]);
                        flag = true;
                    }
                }
                i = i + 1;
            }
        }

        /// <summary>Sorts jagged integer array by maximal elements of the rows ascending.</summary>
        /// <param name="array"> An array to be sorted.</param>
        public static void SortByMaxElementAsc(int[][] array)
        {
            int comparer = 1;

            SortByMaxElement(array, comparer);
        }
        /// <summary>Sorts jagged integer array by maximal elements of the rows descending.</summary>
        /// <param name="array"> An array to be sorted.</param>
        public static void SortByMaxElementDesc(int[][] array)
        {
            int comparer = -1;

            SortByMaxElement(array, comparer);
        }
        /// <summary>Sorts jagged integer array by maximal elements of the rows in chosen order.</summary>
        /// <param name="array"> An array to be sorted.</param>
        /// <param name="comparer"> Flag setting the particular order of sorting.</param>
        private static void SortByMaxElement(int[][] array, int comparer)
        {
            int[] linesMaxElementArray = MaxElementsByLines(array);

            int i = 0;
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (linesMaxElementArray[j].CompareTo(linesMaxElementArray[j + 1]) == comparer)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        Swap(ref linesMaxElementArray[j], ref linesMaxElementArray[j + 1]);
                        flag = true;
                    }
                }
                i = i + 1;
            }
        }

        /// <summary>Sorts jagged integer array by minimal elements of the rows ascending.</summary>
        /// <param name="array"> An array to be sorted.</param>
        public static void SortByMinElementAsc(int[][] array)
        {
            int comparer = 1;

            SortByMinElement(array, comparer);
        }
        /// <summary>Sorts jagged integer array by minimal elements of the rows descending.</summary>
        /// <param name="array"> An array to be sorted.</param>
        public static void SortByMinElementDesc(int[][] array)
        {
            int comparer = -1;

            SortByMinElement(array, comparer);
        }
        /// <summary>Sorts jagged integer array by minimal elements of the rows in chosen order.</summary>
        /// <param name="array"> An array to be sorted.</param>
        /// <param name="comparer"> Flag setting the particular order of sorting.</param>
        private static void SortByMinElement(int[][] array, int comparer)
        {
            int[] linesMinElementArray = MinElementsByLines(array);

            int i = 0;
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (linesMinElementArray[j].CompareTo(linesMinElementArray[j + 1]) == comparer)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        Swap(ref linesMinElementArray[j], ref linesMinElementArray[j + 1]);
                        flag = true;
                    }
                }
                i = i + 1;
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
        /// <summary>Swaps two integers.</summary>
        /// <param name="a"> Reference for the first number.</param>
        /// <param name="b"> Reference for the second number.</param>
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        /// <summary>Computes sums of rows' elements in array.</summary>
        /// <param name="array"> Original two-dimensional array.</param>
        /// <returns>Returns array composed of rows' elements sums. </returns>
        private static int[] SumByLines(int[][] array)
        {
            int[] result = new int[array.Length];
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }
                result[i] = sum;
                sum = 0;
            }

            return result;
        }
        /// <summary>Searches for the maximal elements of rows in array.</summary>
        /// <param name="array"> Original two-dimensional array.</param>
        /// <returns>Returns array composed of rows' maximal elements. </returns>
        private static int[] MaxElementsByLines(int[][] array)
        {
            int[] result = new int[array.Length];
            int max;

            for (int i = 0; i < array.Length; i++)
            {
                max = array[i][0];
                for (int j = 1; j < array[i].Length; j++)
                {
                    if (max < array[i][j])
                        max = array[i][j];
                }
                result[i] = max;
            }

            return result;
        }
        /// <summary>Searches for the minimal elements of rows in array.</summary>
        /// <param name="array"> Original two-dimensional array.</param>
        /// <returns>Returns array composed of rows' minimal elements. </returns>
        private static int[] MinElementsByLines(int[][] array)
        {
            int[] result = new int[array.Length];
            int min;

            for (int i = 0; i < array.Length; i++)
            {
                min = array[i][0];
                for (int j = 1; j < array[i].Length; j++)
                {
                    if (min > array[i][j])
                        min = array[i][j];
                }
                result[i] = min;
            }

            return result;
        } 
        #endregion
    }
}
