using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySortLibrary
{
    internal static class QuickSort
    {
        internal static void ToSort<T>(this T[] arr, int left, int right, Comparator.IComparable<T> comparer)
        {
            int index = Partition(arr, left, right, comparer);
            if (left < index - 1)
            {
                ToSort(arr, left, index - 1, comparer);
                ////arr.ToSort(left, index - 1);
            }

            if (index < right)
            {
                ToSort(arr, index, right, comparer);
                ////arr.ToSort(index, right);
            }
        }

        private static int Partition<T>(T[] arr, int left, int right, Comparator.IComparable<T> comparer)
        {
            int i = left, j = right;
            T tmp;
            T pivot = arr[(left + right) / 2];

            while (i <= j)
            {
                while (comparer.Compare(arr[i], pivot) == -1)
                {
                    i++;
                }

                while (comparer.Compare(arr[j], pivot) == 1)
                {
                    j--;
                }

                if (i <= j)
                {
                    tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                    i++;
                    j--;
                }
            }

            return i;
        }
    }
}
