using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArraySortLibrary.QuickSort;

namespace ArraySortLibrary
{
    public class BinarySearch
    {
        public static int DoSearch<T>(T[] array, int left, int right, T x, Comparator.IComparable<T> comparer = null)
        {
            // #############################

            // check null & type |
            //                   ^
            ////Type arrayType = A.GetType();
            ////arrayType.GetInterface("IComparer");
            array.ToSort(0, array.Length - 1, comparer);
            return Search(array, left, right, x, comparer);
        }

        public static int Search<T>(T[] array, int left, int right, T x, Comparator.IComparable<T> comparer)
        {
            if (left > right || comparer.Compare(x, array[left]) == -1/*x < A[left]*/ || comparer.Compare(x, array[left]) == 1/*x > A[right]*/)
            {
                return -1;
            }

            int mid = left + ((right - left) / 2);

            if (comparer.Compare(x, array[mid]) == 0)
            {
                return mid;
            }

            if (comparer.Compare(x, array[left]) == -1)
            {
                return Search(array, left, mid - 1, x, comparer);
            }
            else
            {
                return Search(array, mid + 1, right, x, comparer);
            }
        }
    }
}
