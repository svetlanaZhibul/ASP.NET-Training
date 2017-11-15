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
        public static void DoSearch<T>(T[] A, int left, int right, T x, Comparator.IComparable<T> comparer = null)
        {

            // #############################

            // check null & type |
            //                   ^


            //Type arrayType = A.GetType();
            //arrayType.GetInterface("IComparer");
            A.ToSort(0, A.Length - 1, comparer);
            Search(A, left, right, x, comparer);
        }

        public static int Search<T>(T[] A, int left, int right, T x, Comparator.IComparable<T> comparer)
        {
            if (left > right || comparer.Compare(x, A[left]) == -1/*x < A[left]*/ || comparer.Compare(x, A[left]) == 1/*x > A[right]*/)
            {
                return -1;
            }

            int mid = left + ((right - left) / 2);

            if (comparer.Compare(x, A[mid]) == 0/*A[mid] == x*/)
            {
                //Console.Write("\t{0}", mid);
                return mid;
            }

            if (comparer.Compare(x, A[left]) == -1/*A[mid] > x*/)
            {
                return Search(A, left, mid - 1, x, comparer);
            }
            else
            {
                return Search(A, mid + 1, right, x, comparer);
            }
        }
    }
}
