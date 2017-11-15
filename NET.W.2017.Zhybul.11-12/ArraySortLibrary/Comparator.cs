using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySortLibrary
{
    public class Comparator
    {
        public interface IComparable<in T>
        {
            int Compare(T lhs, T rhs);
        }
    }
}
