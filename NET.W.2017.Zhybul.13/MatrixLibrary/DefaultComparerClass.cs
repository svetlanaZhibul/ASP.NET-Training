using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public interface IComparer<in T>
    {
        int Compare(T lhs, T rhs);
    }

    public class DefaultComparerClass<T> : IComparer<T>
        where T : struct
    {
        public int Compare(T lhs, T rhs)
        {
            throw new NotImplementedException();
        }
    }
}
