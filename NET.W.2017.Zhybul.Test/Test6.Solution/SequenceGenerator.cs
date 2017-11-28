using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6.Solution
{
    public class SequenceGenerator<T>
        where T : struct
    {
        public delegate T CreateNonStaticCoefSequence(T lhs, T rhs);
                
        public static IEnumerable<T> GetSequence(T first, T second, int length, CreateNonStaticCoefSequence seqCreator)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            if (seqCreator == null)
            {
                throw new ArgumentNullException(nameof(seqCreator));
            }

            return GetSequenceBasis(first, second, length, seqCreator);
        }

        private static IEnumerable<T> GetSequenceBasis(T first, T second, int length, CreateNonStaticCoefSequence seqCreator)
        {
            T temp;

            for (int i = 0; i < length; i++)
            {
                yield return first;
                temp = second;
                second = seqCreator.Invoke(first, second);
                first = temp;
            }
        }
    }

    public class CommonMemberGenerator<T>
    {
        public T GenerateForSequence1(T lhs, T rhs)
        {
            return Operator<T>.Add(rhs, lhs);
        }

        public T GenerateForSequence2(T lhs, T rhs)
        {
            return Operator<T>.Add(Operator<T>.Multiply(6, rhs), Operator<T>.Multiply(-8, lhs));
        }

        public T GenerateForSequence3(T lhs, T rhs)
        {
            return Operator<T>.Add(rhs, Operator<T>.Divide(lhs, rhs));
        }
    }
}
