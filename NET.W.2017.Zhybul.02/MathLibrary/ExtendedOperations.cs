using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibrary
{
    public class ExtendedOperations
    {

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

        public static int[] FilterDigit(int digit, params int[] value)
        {
            if ( digit / 10 != 0 )
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

            return Math.Floor((x1*precision + 0.5)) / precision;
        }

        private static void FillWithZeros(ref string number, int size)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('0', size);
            number += sb;
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

        private static double RelatedFunction(double root, int basis, double number)
        {
            return Math.Pow(root, basis) - number;
        }
        private static double RelatedDerivative(double root, int basis)
        {
            return Math.Pow(root, basis - 1) * basis;
        }
    }
}
