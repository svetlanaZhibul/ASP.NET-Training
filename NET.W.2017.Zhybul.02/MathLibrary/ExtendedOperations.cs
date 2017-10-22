using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class ExtendedOperations
    {

        #region InsertNumberLogic
        public static int InsertNumber(int numberToBeSet, int source, int start, int end)
        {
            if (start > end)
            {
                throw new ArgumentException("Wrong indexes range");
            }

            if (start < 0 || end < 0)
            {
                throw new ArgumentException("Wrong indexes range");
            }

            string binaryString = new string(Convert.ToString(numberToBeSet, 2).Reverse().ToArray());
            string binarySourceString = new string(Convert.ToString(source, 2).Reverse().ToArray());

            if (binaryString.Length <= end)
            {
                FillWithZeros(ref binaryString, end + 1 - binaryString.Length);
            }

            if (binarySourceString.Length <= end)
            {
                FillWithZeros(ref binarySourceString, end + 1 - binarySourceString.Length);
            }

            char[] bs = binaryString.ToArray();
            binarySourceString.CopyTo(0, bs, start, end - start + 1);
            string binarystring = new string(bs.Reverse().ToArray());

            return Convert.ToInt32(binarystring, 2);
        }

        private static void FillWithZeros(ref string number, int size)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('0', size);
            number += sb;
        }
        #endregion

        #region NextBiggerNumberLogic
        public static List<object> NextBiggerNumberAndTimeWithList(long number)
        {
            var list = new List<object>();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            long nextBigger = NextBiggerNumber(number);

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            int totalMSec = (int)ts.TotalMilliseconds;

            list.Add(nextBigger);
            list.Add(totalMSec);

            return list;
        }

        public static IEnumerable<object> NextBiggerNumberAndTimeWithYield(long number)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            long nextBigger = NextBiggerNumber(number);

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            int totalMSec = (int)ts.TotalMilliseconds;

            yield return nextBigger;
            yield return totalMSec;
        }

        public static Tuple<long, int> NextBiggerNumberAndTimeWithTuple(long number)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            long nextBigger = NextBiggerNumber(number);

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            int totalMSec = (int)ts.TotalMilliseconds;

            return Tuple.Create(nextBigger, totalMSec);
        }

        public static long NextBiggerNumber(long number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }

            if (IsDecreasing(number))
            {
                return -1;
            }
            
            string snumber = ToSortedString(number);
            long next = ++number;
            string sNext = ToSortedString(next);

            while (snumber != sNext)
            {
                sNext = ToSortedString(++next);
            }
            
            return next;
        }

        private static string ToSortedString(long number)
        {
            var array = number.ToString().ToCharArray();
            Array.Sort(array);
            return new String(array);
        }

        private static bool IsDecreasing(long n)
        {
            int prevDigit = (int)n % 10;
            n = n / 10;
            while (n != 0)
            {
                if (prevDigit > n % 10) return false;
                prevDigit = (int)n % 10;
                n = n / 10;
            }

            return true;
        } 
        #endregion

        #region FilterDigitLogic
        public static int[] FilterDigit(int digit, params int[] value)
        {
            if (digit / 10 != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(digit));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            List<int> result = new List<int>();

            foreach (int number in value)
            {
                if (ContainsDigit(number, digit))
                {
                    result.Add(number);
                }
            }

            return result.ToArray();
        }

        private static bool ContainsDigit(int number, int digit)
        {
            if (number == 0 && digit == 0)
            {
                return true;
            }
            while (number > 0)
            {
                if (number % 10 == digit)
                    return true;
                number /= 10;
            }
            return false;
        }
        #endregion

        #region FindNthRootLogic
        public static double FindNthRoot(double number, int basis, double eps = 0.0001)
        {
            if (basis <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(basis));
            }

            if (number < 0 && basis % 2 == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }

            if (eps < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(eps));
            }

            return FindNthRoot(number, basis, number, eps);
        }
        public static double FindNthRoot(double number, int basis, double suspected, double eps = 0.0001)
        {
            double x0 = suspected;
            double x1 = x0 - RelatedFunction(x0, basis, number) / RelatedDerivative(x0, basis);
            while (Math.Abs(x0 - x1) > eps)
            {
                x0 = x1;
                x1 = x1 - RelatedFunction(x1, basis, number) / RelatedDerivative(x1, basis);
            }

            int precision = 1;
            while (eps < 1)
            {
                precision *= 10;
                eps *= 10;
            }

            return Math.Floor((x1 * precision + 0.5)) / precision;
        }

        private static double RelatedFunction(double root, int basis, double number)
        {
            return Math.Pow(root, basis) - number;
        }
        private static double RelatedDerivative(double root, int basis)
        {
            return Math.Pow(root, basis - 1) * basis;
        } 
        #endregion

    }
}
