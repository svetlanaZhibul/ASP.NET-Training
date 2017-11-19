using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class Fibonacci
    {
        private static int fibPrev = 1;
        private static int fibNext = 1;

        public static int[] GetFibonacci(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            int fibFirst = 1;
            int fibSecond = 1;

            if (length == 1)
            {
                return new int[] { fibFirst };
            }

            if (length == 2)
            {
                return new int[] { fibFirst, fibSecond };
            }

            int[] sequence = new int[length];
            sequence[0] = fibFirst;
            sequence[1] = fibSecond;
            for (int i = 2; i < length; i++)
            {
                sequence[i] = sequence[i - 1] + sequence[i - 2];
            }

            return sequence;
        }

        public static IEnumerable<int> GetFibonacciS(int length)
        {
            if (length <= 0)
            {
                ////throw new ArgumentOutOfRangeException(nameof(length));
                yield break;
            }

            yield return fibPrev;

            for (int i = 1; i < length; i++)
            {
                yield return fibNext;
                fibNext = fibNext + fibPrev;
                fibPrev = fibNext - fibPrev;
            }
        }
    }
}
