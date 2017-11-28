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
        public delegate Tuple<T,T> CreateNonStaticCoefSequence(T lhs, T rhs, T lhs_coef, T rhs_coef);

        private T firstMember;
        private T secondMember;
        private T fKoef;
        private T sKoef;

        public SequenceGenerator() { }

        public SequenceGenerator(T firstMember, T secondMember)
        {
            this.firstMember = firstMember;
            this.secondMember = secondMember;
        }

        public SequenceGenerator(T fKoef, T sKoef, T first, T second)
        {
            this.fKoef = fKoef;
            this.sKoef = sKoef;
            firstMember = first;
            secondMember = second;
        }

        public T FirstMember
        {
            get
            {
                return firstMember;
            }
            set
            {
                firstMember = value;
            }
        }

        public T SecondMember
        {
            get
            {
                return secondMember;
            }
            set
            {
                secondMember = value;
            }
        }

        public T FirstCoef
        {
            get
            {
                return fKoef;
            }
            set
            {
                fKoef = value;
            }
        }

        public T SecondCoef
        {
            get
            {
                return sKoef;
            }
            set
            {
                sKoef = value;
            }
        }
        
        public IEnumerable<T> GetStaticCoefSequence(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            T temp;

            for (int i = 0; i < length; i++)
            {
                yield return FirstMember;

                temp = FirstMember;
                FirstMember = SecondMember;
                SecondMember = InitSequence(temp, FirstMember);
            }
        }

        public IEnumerable<T> GetNonStaticSequence(int length, CreateNonStaticCoefSequence coefCreator)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            T temp;

            for (int i = 1; i < length; i++)
            {
                yield return FirstMember;

                temp = FirstMember;
                FirstMember = SecondMember;
                FirstCoef = coefCreator.Invoke(temp, FirstMember, this.FirstCoef, this.SecondCoef).Item1;
                SecondCoef = coefCreator.Invoke(temp, FirstMember, this.FirstCoef, this.SecondCoef).Item2;
                SecondMember = InitSequence(temp, FirstMember);
            }
        }

        public T InitSequence(T first, T second)
        {
            return Operator<T>.Add(Operator<T>.Multiply(this.fKoef, first), Operator<T>.Multiply(this.sKoef, second));
        }
    }

    public class CoeffincientGenerator<T>
    {
        public Tuple<T,T> Generate(T lhs, T rhs, T lhs_coef, T rhs_coef)
        {
            return new Tuple<T, T>(lhs, Operator<T>.Divide(rhs_coef, lhs));
        }
    }
}
